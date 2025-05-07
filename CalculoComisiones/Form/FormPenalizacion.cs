using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoComisiones.Form
{
    public partial class FormPenalizacion : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static string compania = StaticData.oCnn.CompaniaActual;

        public FormPenalizacion()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CloseBox = false;
            CargarReglas();
        }

        private void FormPenalizacion_Load(object sender, EventArgs e)
        {

        }

        private static FormPenalizacion m_FormDefInstance;
        public static FormPenalizacion DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormPenalizacion();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }


        private void CargarReglas()
        {
            string sql = $@"
                    SELECT Id, DesdeDias, HastaDias, PorcentajePago
                    FROM {compania}.CS_CC_CONFIGURACION_PENALIZACION
                    ORDER BY DesdeDias
                ";

            try
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridView1.OptionsBehavior.Editable = false;

                DataTable dt = StaticData.oCnn.ExecuteDatatable(sql); 

                gridControl1.DataSource = dt;
                gridView1.OptionsBehavior.Editable = true;

                //Insertar nuevo registro
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;

                gridView1.Columns["Id"].Visible = false;

                gridView1.Columns["PorcentajePago"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridView1.Columns["PorcentajePago"].DisplayFormat.FormatString = "N2";

                gridView1.RefreshData();
                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las reglas de penalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefrescar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CargarReglas();
        }

        private void GuardarCambios()
        {
            DataTable dt = (DataTable)gridControl1.DataSource;

            if (!ValidarReglasNoSolapadas(dt))
            {
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;

                if (row["DesdeDias"] == DBNull.Value || row["HastaDias"] == DBNull.Value || row["PorcentajePago"] == DBNull.Value)
                {
                    MessageBox.Show("Hay campos vacíos. Por favor complete todos los valores.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int desdeDias = Convert.ToInt32(row["DesdeDias"]);
                int hastaDias = Convert.ToInt32(row["HastaDias"]);
                decimal porcentajePago = Convert.ToDecimal(row["PorcentajePago"]);
                int id = row["Id"] != DBNull.Value ? Convert.ToInt32(row["Id"]) : 0;

                if (id == 0)
                {
                    string insertSql = $@"
                        INSERT INTO {compania}.CS_CC_CONFIGURACION_PENALIZACION 
                        (DesdeDias, HastaDias, PorcentajePago)
                        VALUES ({desdeDias}, {hastaDias}, {porcentajePago.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)})
                    ";
                    try
                    {
                        StaticData.oCnn.ExecuteNonQuery(insertSql);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al insertar nueva regla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string updateSql = $@"
                        UPDATE {compania}.CS_CC_CONFIGURACION_PENALIZACION
                        SET DesdeDias = {desdeDias}, 
                            HastaDias = {hastaDias}, 
                            PorcentajePago = {porcentajePago.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)}
                        WHERE Id = {id}
                    ";
                    try
                    {
                        StaticData.oCnn.ExecuteNonQuery(updateSql);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar regla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarReglas();
        }

        private bool ValidarReglasNoSolapadas(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int desdeDias1 = (int)dt.Rows[i]["DesdeDias"];
                int hastaDias1 = (int)dt.Rows[i]["HastaDias"];


                if (desdeDias1 > hastaDias1)
                {
                    MessageBox.Show("El rango de días no es válido. 'Desde' no puede ser mayor que 'Hasta'.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //CargarReglas();
                    return false;
                }

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i != j)  
                    {
                        int desdeDias2 = (int)dt.Rows[j]["DesdeDias"];
                        int hastaDias2 = (int)dt.Rows[j]["HastaDias"];

                        if (desdeDias1 <= hastaDias2 && hastaDias1 >= desdeDias2)
                        {
                            MessageBox.Show("Los rangos de días se solapan. Corrija las fechas.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //CargarReglas();
                            return false;
                        }


                    }
                }
            }

            var listaOrdenada = dt.AsEnumerable()
                .OrderBy(r => r.Field<int>("DesdeDias"))
                .ToList();

            for (int i = 1; i < listaOrdenada.Count; i++)
            {
                int hastaAnterior = listaOrdenada[i - 1].Field<int>("HastaDias");
                int desdeActual = listaOrdenada[i].Field<int>("DesdeDias");

                if (desdeActual != hastaAnterior + 1)
                {
                    MessageBox.Show($"Hay un hueco entre los días {hastaAnterior} y {desdeActual}. Los rangos deben ser continuos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            GuardarCambios();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DialogResult confirm = MessageBox.Show(
                    "¿Desea eliminar esta fila?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    gridView1.DeleteRow(gridView1.FocusedRowHandle);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DialogResult confirm = MessageBox.Show(
                    "¿Desea eliminar esta fila?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    DataRowView rowView = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                    if (rowView != null)
                    {
                        DataRow row = rowView.Row;

                        if (row["Id"] != DBNull.Value)
                        {
                            int id = Convert.ToInt32(row["Id"]);
                            string deleteSql = $@"
                                DELETE FROM {compania}.CS_CC_CONFIGURACION_PENALIZACION
                                WHERE Id = {id}
                            ";

                            try
                            {
                                StaticData.oCnn.ExecuteNonQuery(deleteSql);
                                MessageBox.Show("Registro eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                btnEliminar_ItemClick(sender, null);
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                btnGuardar_ItemClick(sender, null);
                e.Handled = true;
            }

            if (e.Control && e.KeyCode == Keys.R)
            {
                btnRefrescar_ItemClick(sender, null);
                e.Handled = true;
            }
        }

    }
}