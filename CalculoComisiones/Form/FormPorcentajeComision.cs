using DevExpress.Utils;
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
    public partial class FormPorcentajeComision : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static string compania = StaticData.oCnn.CompaniaActual;

        public FormPorcentajeComision()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CloseBox = false;
            CargarDatos();
        }

        private void FormPenalizacion_Load(object sender, EventArgs e)
        {

        }

        private static FormPorcentajeComision m_FormDefInstance;
        public static FormPorcentajeComision DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormPorcentajeComision();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }


        private void CargarDatos()
        {
            string sql = $@"
                SELECT Clasificacion Codigo, Descripcion, 
                       ISNULL(PorcentajeContado, 0) AS PorcentajeContado,
                       ISNULL(PorcentajeCredito, 0) AS PorcentajeCredito,
                       ISNULL(PorcentajeCredito1Dia, 0) AS PorcentajeCredito1Dia
                FROM {compania}.Clasificacion
                Where AGRUPACION = 1
	            ORDER BY CLASIFICACION";

            try
            {
                DataTable dt = StaticData.oCnn.ExecuteDatatable(sql);

                gridControl1.DataSource = null;
                gridView1.Columns.Clear();

                gridControl1.DataSource = dt;
                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;

                gridView1.Columns["Codigo"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["Descripcion"].OptionsColumn.AllowEdit = false;

                gridView1.Columns["PorcentajeContado"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["PorcentajeContado"].DisplayFormat.FormatString = "N2";

                gridView1.Columns["PorcentajeCredito"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["PorcentajeCredito"].DisplayFormat.FormatString = "N2";

                gridView1.Columns["PorcentajeCredito1Dia"].DisplayFormat.FormatType = FormatType.Numeric;
                gridView1.Columns["PorcentajeCredito1Dia"].DisplayFormat.FormatString = "N2";

                gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las clasificaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefrescar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CargarDatos();
        }

        private void GuardarCambios()
        {
            DataTable dt = (DataTable)gridControl1.DataSource;

            foreach (DataRow row in dt.Rows)
            {
                string codigo = row["Codigo"].ToString();
                decimal contado = Convert.ToDecimal(row["PorcentajeContado"]);
                decimal credito = Convert.ToDecimal(row["PorcentajeCredito"]);
                decimal credito1Dia = Convert.ToDecimal(row["PorcentajeCredito1Dia"]);

                string sql = $@"
                    UPDATE {compania}.Clasificacion
                    SET PorcentajeContado = {contado.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)},
                        PorcentajeCredito = {credito.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)},
                        PorcentajeCredito1Dia = {credito1Dia.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)}
                    WHERE Clasificacion = '{codigo}'
                ";

                try
                {
                    StaticData.oCnn.ExecuteNonQuery(sql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el código {codigo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDatos();
        }



        private void btnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            GuardarCambios();
        }
                  

    }
}