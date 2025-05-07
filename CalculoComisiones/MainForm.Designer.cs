namespace CalculoComisiones
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.btnPorcentajes = new DevExpress.XtraBars.BarSubItem();
            this.btnReglas = new DevExpress.XtraBars.BarButtonItem();
            this.btnReiniciar = new DevExpress.XtraBars.BarButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnComisiones = new DevExpress.XtraBars.BarButtonItem();
            this.btnTolerancia = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonGroup1,
            this.btnPorcentajes,
            this.btnReglas,
            this.btnReiniciar,
            this.btnSalir,
            this.btnComisiones,
            this.btnTolerancia});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(758, 158);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Períodos";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Listado de Facturas";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 3;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // btnPorcentajes
            // 
            this.btnPorcentajes.Caption = "Porcentaje de comisiones y de tolerancia";
            this.btnPorcentajes.Id = 5;
            this.btnPorcentajes.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.btnPorcentajes.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.btnPorcentajes.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnComisiones),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTolerancia)});
            this.btnPorcentajes.Name = "btnPorcentajes";
            // 
            // btnReglas
            // 
            this.btnReglas.Caption = "Reglas de penalización";
            this.btnReglas.Id = 6;
            this.btnReglas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReglas.ImageOptions.Image")));
            this.btnReglas.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReglas.ImageOptions.LargeImage")));
            this.btnReglas.Name = "btnReglas";
            this.btnReglas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReglas_ItemClick);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Caption = "Reiniciar";
            this.btnReiniciar.Id = 8;
            this.btnReiniciar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReiniciar.ImageOptions.Image")));
            this.btnReiniciar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReiniciar.ImageOptions.LargeImage")));
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReiniciar_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 9;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaliir_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menú";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Procesamiento";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPorcentajes);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnReglas);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Mantenimiento";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Reportes";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnReiniciar);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnSalir);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Opciones";
            // 
            // btnComisiones
            // 
            this.btnComisiones.Caption = "Comisiones";
            this.btnComisiones.Id = 10;
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnComisiones_ItemClick);
            // 
            // btnTolerancia
            // 
            this.btnTolerancia.Caption = "Tolerancia";
            this.btnTolerancia.Id = 11;
            this.btnTolerancia.Name = "btnTolerancia";
            this.btnTolerancia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTolerancia_ItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 360);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainForm.IconOptions.Icon")));
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarSubItem btnPorcentajes;
        private DevExpress.XtraBars.BarButtonItem btnReglas;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnReiniciar;
        private DevExpress.XtraBars.BarButtonItem btnSalir;
        private DevExpress.XtraBars.BarButtonItem btnComisiones;
        private DevExpress.XtraBars.BarButtonItem btnTolerancia;
    }
}

