namespace StokTakip.Cihaz
{
    partial class CihazListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CihazListesi));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_sil = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_yenile = new DevExpress.XtraBars.BarButtonItem();
            this.btn_sicil = new DevExpress.XtraBars.BarButtonItem();
            this.btn_kullanim = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btn_chzbilgi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_chzkal = new DevExpress.XtraBars.BarButtonItem();
            this.btn_chzanaliz = new DevExpress.XtraBars.BarButtonItem();
            this.btn_kalibrasyon = new DevExpress.XtraBars.BarButtonItem();
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
            this.gridControl1.Size = new System.Drawing.Size(800, 450);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Arama yapabilirsiniz..";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsFind.ShowSearchNavButtons = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.RowHeight = 22;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_sicil),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_kalibrasyon),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_kullanim),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_yenile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_sil)});
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
            this.btn_sil,
            this.barButtonItem2,
            this.btn_yenile,
            this.btn_sicil,
            this.btn_kullanim,
            this.barSubItem1,
            this.btn_chzbilgi,
            this.btn_chzkal,
            this.btn_chzanaliz,
            this.btn_kalibrasyon});
            this.barManager1.MaxItemId = 10;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 450);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 450);
            // 
            // btn_sil
            // 
            this.btn_sil.Caption = "Sil";
            this.btn_sil.Id = 0;
            this.btn_sil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btn_sil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_sil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_sil_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Güncelle";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btn_yenile
            // 
            this.btn_yenile.Caption = "Yenile     (F5)";
            this.btn_yenile.Id = 2;
            this.btn_yenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.btn_yenile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_yenile_ItemClick);
            // 
            // btn_sicil
            // 
            this.btn_sicil.Caption = "Cihaz Sicil Kartı";
            this.btn_sicil.Id = 3;
            this.btn_sicil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.btn_sicil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.btn_sicil.Name = "btn_sicil";
            this.btn_sicil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_sicil_ItemClick);
            // 
            // btn_kullanim
            // 
            this.btn_kullanim.Caption = "Kullanım Dışı";
            this.btn_kullanim.Id = 4;
            this.btn_kullanim.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.Image")));
            this.btn_kullanim.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem5.ImageOptions.LargeImage")));
            this.btn_kullanim.Name = "btn_kullanim";
            this.btn_kullanim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btn_kullanim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_kullanim_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Güncelle";
            this.barSubItem1.Id = 5;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_chzbilgi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_chzkal),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_chzanaliz)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btn_chzbilgi
            // 
            this.btn_chzbilgi.Caption = "Cihaz Bilgileri Güncelle";
            this.btn_chzbilgi.Id = 6;
            this.btn_chzbilgi.Name = "btn_chzbilgi";
            this.btn_chzbilgi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_chzbilgi_ItemClick);
            // 
            // btn_chzkal
            // 
            this.btn_chzkal.Caption = "Kalibrasyon ve Bakım Bilgilerini Güncelle";
            this.btn_chzkal.Id = 7;
            this.btn_chzkal.Name = "btn_chzkal";
            this.btn_chzkal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_chzkal_ItemClick);
            // 
            // btn_chzanaliz
            // 
            this.btn_chzanaliz.Caption = "Yetkili Kişi ve Analiz Bilgilerini Güncelle";
            this.btn_chzanaliz.Id = 8;
            this.btn_chzanaliz.Name = "btn_chzanaliz";
            this.btn_chzanaliz.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_chzanaliz_ItemClick);
            // 
            // btn_kalibrasyon
            // 
            this.btn_kalibrasyon.Caption = "Kalibrasyon / Bakım / Onarım Ekle";
            this.btn_kalibrasyon.Id = 9;
            this.btn_kalibrasyon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.ImageOptions.Image")));
            this.btn_kalibrasyon.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem9.ImageOptions.LargeImage")));
            this.btn_kalibrasyon.Name = "btn_kalibrasyon";
            this.btn_kalibrasyon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_kalibrasyon_ItemClick);
            // 
            // CihazListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "CihazListesi";
            this.Text = "Cihaz Listesi";
            this.Load += new System.EventHandler(this.CihazListesi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CihazListesi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btn_sicil;
        private DevExpress.XtraBars.BarButtonItem btn_kalibrasyon;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btn_chzbilgi;
        private DevExpress.XtraBars.BarButtonItem btn_chzkal;
        private DevExpress.XtraBars.BarButtonItem btn_chzanaliz;
        private DevExpress.XtraBars.BarButtonItem btn_kullanim;
        private DevExpress.XtraBars.BarButtonItem btn_yenile;
        private DevExpress.XtraBars.BarButtonItem btn_sil;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
    }
}