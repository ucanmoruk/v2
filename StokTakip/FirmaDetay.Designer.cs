namespace StokTakip
{
    partial class FirmaDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirmaDetay));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.txt_adres = new DevExpress.XtraEditors.TextEdit();
            this.txt_path = new DevExpress.XtraEditors.TextEdit();
            this.txt_birim = new DevExpress.XtraEditors.TextEdit();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_guncelle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_path.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(70, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Firma Adı:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(89, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Adresi:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 99);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Dosya Kayıt Yolu:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(68, 134);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Birim Ekle:";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(137, 24);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(499, 22);
            this.txt_ad.TabIndex = 1;
            // 
            // txt_adres
            // 
            this.txt_adres.Location = new System.Drawing.Point(137, 60);
            this.txt_adres.Name = "txt_adres";
            this.txt_adres.Size = new System.Drawing.Size(499, 22);
            this.txt_adres.TabIndex = 2;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(137, 95);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(381, 22);
            this.txt_path.TabIndex = 3;
            // 
            // txt_birim
            // 
            this.txt_birim.Location = new System.Drawing.Point(138, 131);
            this.txt_birim.Name = "txt_birim";
            this.txt_birim.Size = new System.Drawing.Size(380, 22);
            this.txt_birim.TabIndex = 5;
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(524, 131);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(112, 22);
            this.btn_ekle.TabIndex = 6;
            this.btn_ekle.Text = "Ekle";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.Location = new System.Drawing.Point(0, 182);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(675, 351);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(675, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 533);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(675, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(675, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Sil";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btn_guncelle
            // 
            this.btn_guncelle.Location = new System.Drawing.Point(524, 95);
            this.btn_guncelle.Name = "btn_guncelle";
            this.btn_guncelle.Size = new System.Drawing.Size(112, 22);
            this.btn_guncelle.TabIndex = 4;
            this.btn_guncelle.Text = "Güncelle";
            this.btn_guncelle.Click += new System.EventHandler(this.btn_guncelle_Click);
            // 
            // FirmaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 533);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btn_guncelle);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.txt_birim);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.txt_adres);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FirmaDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firma Detayları";
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_path.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.TextEdit txt_adres;
        private DevExpress.XtraEditors.TextEdit txt_path;
        private DevExpress.XtraEditors.TextEdit txt_birim;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btn_guncelle;
    }
}