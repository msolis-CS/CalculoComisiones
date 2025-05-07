using CalculoComisiones.Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculoComisiones
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CloseBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private static MainForm m_FormDefInstance;
        public static MainForm DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new MainForm();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void btnReiniciar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void btnSaliir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnReglas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPenalizacion.DefInstance.StartPosition = FormStartPosition.CenterScreen;
            FormPenalizacion.DefInstance.Show();
            FormPenalizacion.DefInstance.BringToFront();
        }

        private void btnComisiones_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPorcentajeComision.DefInstance.StartPosition = FormStartPosition.CenterScreen;
            FormPorcentajeComision.DefInstance.Show();
            FormPorcentajeComision.DefInstance.BringToFront();
        }

        private void btnTolerancia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPorcentajeTolerancia.DefInstance.StartPosition = FormStartPosition.CenterScreen;
            FormPorcentajeTolerancia.DefInstance.Show();
            FormPorcentajeTolerancia.DefInstance.BringToFront();
        }
    }
}
