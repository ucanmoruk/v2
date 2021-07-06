namespace StokTakip
{
    partial class TalepListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalepListesi));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bar_talepdurum = new DevExpress.XtraBars.BarSubItem();
            this.bar_taleponay = new DevExpress.XtraBars.BarButtonItem();
            this.bar_talepred = new DevExpress.XtraBars.BarButtonItem();
            this.bar_talepiptal = new DevExpress.XtraBars.BarButtonItem();
            this.bar_talepisle = new DevExpress.XtraBars.BarButtonItem();
            this.bar_taleptamam = new DevExpress.XtraBars.BarButtonItem();
            this.guncelle = new DevExpress.XtraBars.BarButtonItem();
            this.bar_detay = new DevExpress.XtraBars.BarButtonItem();
            this.bar_talepkabul = new DevExpress.XtraBars.BarButtonItem();
            this.bar_yenile = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar_degerlendirme = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(677, 440);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Arama Yapabilirsiniz...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsFind.ShowSearchNavButtons = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_talepdurum),
            new DevExpress.XtraBars.LinkPersistInfo(this.guncelle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_detay),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_talepkabul),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_degerlendirme),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_yenile)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // bar_talepdurum
            // 
            this.bar_talepdurum.Caption = "Talep Durumu";
            this.bar_talepdurum.Id = 2;
            this.bar_talepdurum.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_talepdurum.ImageOptions.Image")));
            this.bar_talepdurum.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_talepdurum.ImageOptions.LargeImage")));
            this.bar_talepdurum.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_taleponay),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_talepred),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_talepiptal),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_talepisle),
            new DevExpress.XtraBars.LinkPersistInfo(this.bar_taleptamam)});
            this.bar_talepdurum.Name = "bar_talepdurum";
            this.bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bar_taleponay
            // 
            this.bar_taleponay.Caption = "Talebi Onayla";
            this.bar_taleponay.Id = 3;
            this.bar_taleponay.Name = "bar_taleponay";
            this.bar_taleponay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_taleponay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bar_talepred
            // 
            this.bar_talepred.Caption = "Talebi Reddet";
            this.bar_talepred.Id = 5;
            this.bar_talepred.Name = "bar_talepred";
            this.bar_talepred.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_talepred.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // bar_talepiptal
            // 
            this.bar_talepiptal.Caption = "Talebi İptal Et";
            this.bar_talepiptal.Id = 6;
            this.bar_talepiptal.Name = "bar_talepiptal";
            this.bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_talepiptal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bar_talepisle
            // 
            this.bar_talepisle.Caption = "Talebi İşleme Al";
            this.bar_talepisle.Id = 4;
            this.bar_talepisle.Name = "bar_talepisle";
            this.bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_talepisle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bar_taleptamam
            // 
            this.bar_taleptamam.Caption = "Talebi Tamamla";
            this.bar_taleptamam.Id = 9;
            this.bar_taleptamam.Name = "bar_taleptamam";
            this.bar_taleptamam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_taleptamam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // guncelle
            // 
            this.guncelle.Caption = "Güncelle";
            this.guncelle.Id = 11;
            this.guncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("guncelle.ImageOptions.Image")));
            this.guncelle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("guncelle.ImageOptions.LargeImage")));
            this.guncelle.Name = "guncelle";
            this.guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.guncelle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.guncelle_ItemClick);
            // 
            // bar_detay
            // 
            this.bar_detay.Caption = "Talep Detayları";
            this.bar_detay.Id = 7;
            this.bar_detay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_detay.ImageOptions.Image")));
            this.bar_detay.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_detay.ImageOptions.LargeImage")));
            this.bar_detay.Name = "bar_detay";
            this.bar_detay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bar_talepkabul
            // 
            this.bar_talepkabul.Caption = "Talep Kabul Etme";
            this.bar_talepkabul.Id = 8;
            this.bar_talepkabul.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_talepkabul.ImageOptions.Image")));
            this.bar_talepkabul.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_talepkabul.ImageOptions.LargeImage")));
            this.bar_talepkabul.Name = "bar_talepkabul";
            this.bar_talepkabul.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_talepkabul.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // bar_yenile
            // 
            this.bar_yenile.Caption = "Yenile";
            this.bar_yenile.Id = 10;
            this.bar_yenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_yenile.ImageOptions.Image")));
            this.bar_yenile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_yenile.ImageOptions.LargeImage")));
            this.bar_yenile.Name = "bar_yenile";
            this.bar_yenile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bar_talepdurum,
            this.bar_taleponay,
            this.bar_talepisle,
            this.bar_talepred,
            this.bar_talepiptal,
            this.bar_detay,
            this.bar_talepkabul,
            this.bar_taleptamam,
            this.bar_yenile,
            this.guncelle,
            this.bar_degerlendirme});
            this.barManager1.MaxItemId = 13;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(677, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 440);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(677, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 440);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(677, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 440);
            // 
            // bar_degerlendirme
            // 
            this.bar_degerlendirme.Caption = "Talep Değerlendirme";
            this.bar_degerlendirme.Id = 12;
            this.bar_degerlendirme.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_degerlendirme.ImageOptions.Image")));
            this.bar_degerlendirme.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_degerlendirme.ImageOptions.LargeImage")));
            this.bar_degerlendirme.Name = "bar_degerlendirme";
            this.bar_degerlendirme.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bar_degerlendirme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_degerlendirme_ItemClick);
            // 
            // TalepListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 440);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TalepListesi";
            this.Text = "Talep Listesi";
            this.Load += new System.EventHandler(this.TalepListesi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TalepListesi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarSubItem bar_talepdurum;
        private DevExpress.XtraBars.BarButtonItem bar_taleponay;
        private DevExpress.XtraBars.BarButtonItem bar_talepiptal;
        private DevExpress.XtraBars.BarButtonItem bar_talepred;
        private DevExpress.XtraBars.BarButtonItem bar_talepisle;
        private DevExpress.XtraBars.BarButtonItem bar_detay;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bar_talepkabul;
        private DevExpress.XtraBars.BarButtonItem bar_taleptamam;
        private DevExpress.XtraBars.BarButtonItem bar_yenile;
        private DevExpress.XtraBars.BarButtonItem guncelle;
        private DevExpress.XtraBars.BarButtonItem bar_degerlendirme;
    }
}