namespace StokTakip.Talep
{
    partial class MaaliyetEkle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaaliyetEkle));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_maaliyet = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTalepNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzellik = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_maaliyet);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 331);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(698, 106);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_maaliyet
            // 
            this.btn_maaliyet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_maaliyet.Appearance.Options.UseFont = true;
            this.btn_maaliyet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_maaliyet.ImageOptions.Image")));
            this.btn_maaliyet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_maaliyet.ImageOptions.ImageToTextIndent = 20;
            this.btn_maaliyet.Location = new System.Drawing.Point(417, 24);
            this.btn_maaliyet.Name = "btn_maaliyet";
            this.btn_maaliyet.Size = new System.Drawing.Size(269, 58);
            this.btn_maaliyet.TabIndex = 0;
            this.btn_maaliyet.Text = "Maaliyet Ekle";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(698, 331);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTalepNo,
            this.colStokKod,
            this.colMiktar,
            this.colBirim,
            this.colMarka,
            this.colOzellik,
            this.colDurum});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colTalepNo
            // 
            this.colTalepNo.FieldName = "TalepNo";
            this.colTalepNo.Name = "colTalepNo";
            this.colTalepNo.Visible = true;
            this.colTalepNo.VisibleIndex = 1;
            // 
            // colStokKod
            // 
            this.colStokKod.FieldName = "StokKod";
            this.colStokKod.Name = "colStokKod";
            this.colStokKod.Visible = true;
            this.colStokKod.VisibleIndex = 2;
            // 
            // colMiktar
            // 
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 3;
            // 
            // colBirim
            // 
            this.colBirim.FieldName = "Birim";
            this.colBirim.Name = "colBirim";
            this.colBirim.Visible = true;
            this.colBirim.VisibleIndex = 4;
            // 
            // colMarka
            // 
            this.colMarka.FieldName = "Marka";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 5;
            // 
            // colOzellik
            // 
            this.colOzellik.FieldName = "Ozellik";
            this.colOzellik.Name = "colOzellik";
            this.colOzellik.Visible = true;
            this.colOzellik.VisibleIndex = 6;
            // 
            // colDurum
            // 
            this.colDurum.FieldName = "Durum";
            this.colDurum.Name = "colDurum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 7;
            // 
            // MaaliyetEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 437);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "MaaliyetEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MaaliyetEkle";
            this.Load += new System.EventHandler(this.MaaliyetEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_maaliyet;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTalepNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStokKod;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colOzellik;
        private DevExpress.XtraGrid.Columns.GridColumn colDurum;
    }
}