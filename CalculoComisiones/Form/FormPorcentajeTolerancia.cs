using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace CalculoComisiones.Form
{
    public partial class FormPorcentajeTolerancia : XtraForm
    {
        static string compania = StaticData.oCnn.CompaniaActual;

        public FormPorcentajeTolerancia()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            txtTolerancia.Properties.Mask.EditMask = "n2";
            txtTolerancia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtTolerancia.Properties.Mask.UseMaskAsDisplayFormat = true;
            LoadTolerancia();
        }

        private static FormPorcentajeTolerancia m_FormDefInstance;
        public static FormPorcentajeTolerancia DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new FormPorcentajeTolerancia();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }


        private void LoadTolerancia()
        {
            string sql = $@"SELECT TOP 1 ToleranciaPorcentaje FROM {compania}.CS_CC_CONFIGURACION_TOLERANCIA";
            try
            {
                DataTable dt = StaticData.oCnn.ExecuteDatatable(sql);
                if (dt.Rows.Count > 0)
                {
                    decimal valor = Convert.ToDecimal(dt.Rows[0]["ToleranciaPorcentaje"]);
                    txtTolerancia.Text = valor.ToString("N2", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la configuración: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTolerancia.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                MessageBox.Show("Ingrese un valor numérico válido para la tolerancia.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"
                UPDATE {compania}.CS_CC_CONFIGURACION_TOLERANCIA
                SET ToleranciaPorcentaje = {valor.ToString("0.##", CultureInfo.InvariantCulture)}
            ";

            try
            {
                StaticData.oCnn.ExecuteNonQuery(sql);
                MessageBox.Show("Tolerancia guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la tolerancia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
