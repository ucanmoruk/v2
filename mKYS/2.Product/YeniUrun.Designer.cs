namespace mKYS.Analiz
{
    partial class YeniUrun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniUrun));
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ozelik = new DevExpress.XtraEditors.MemoEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btn_logo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_marka = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.t_barkod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.t_hacim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.c_kategori = new DevExpress.XtraEditors.ComboBoxEdit();
            this.t_seri = new DevExpress.XtraEditors.TextEdit();
            this.txt_fiyat = new DevExpress.XtraEditors.TextEdit();
            this.t_tesf = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ozelik.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_marka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_barkod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_hacim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_kategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_seri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_tesf.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(126, 26);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Size = new System.Drawing.Size(88, 20);
            this.txt_kod.TabIndex = 0;
            this.txt_kod.EditValueChanged += new System.EventHandler(this.txt_kod_EditValueChanged);
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(126, 123);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(318, 20);
            this.txt_ad.TabIndex = 5;
            // 
            // btn_add
            // 
            this.btn_add.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_add.ImageOptions.ImageToTextIndent = 10;
            this.btn_add.Location = new System.Drawing.Point(126, 346);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(318, 46);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Ürün Ekle";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(52, 29);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Kod / Barkod:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(83, 154);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Özellik:";
            // 
            // txt_ozelik
            // 
            this.txt_ozelik.Location = new System.Drawing.Point(126, 153);
            this.txt_ozelik.Name = "txt_ozelik";
            this.txt_ozelik.Size = new System.Drawing.Size(318, 57);
            this.txt_ozelik.TabIndex = 6;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(126, 255);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(174, 77);
            this.pictureEdit1.TabIndex = 9;
            // 
            // btn_logo
            // 
            this.btn_logo.Location = new System.Drawing.Point(306, 255);
            this.btn_logo.Name = "btn_logo";
            this.btn_logo.Size = new System.Drawing.Size(138, 77);
            this.btn_logo.TabIndex = 10;
            this.btn_logo.Text = "Ürün Fotoğrafı Seç";
            this.btn_logo.Click += new System.EventHandler(this.btn_logo_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(73, 258);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Fotoğraf:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(36, 357);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(72, 35);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "pdf seç";
            this.simpleButton1.Visible = false;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(100, 126);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(17, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Ad:";
            // 
            // txt_marka
            // 
            this.txt_marka.Location = new System.Drawing.Point(126, 90);
            this.txt_marka.Name = "txt_marka";
            this.txt_marka.Size = new System.Drawing.Size(149, 20);
            this.txt_marka.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(56, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Marka / Seri:";
            // 
            // t_barkod
            // 
            this.t_barkod.Location = new System.Drawing.Point(220, 26);
            this.t_barkod.Name = "t_barkod";
            this.t_barkod.Size = new System.Drawing.Size(224, 20);
            this.t_barkod.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 223);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(101, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Miktar / Fiyat / TESF:";
            // 
            // t_hacim
            // 
            this.t_hacim.Location = new System.Drawing.Point(126, 220);
            this.t_hacim.Name = "t_hacim";
            this.t_hacim.Size = new System.Drawing.Size(96, 20);
            this.t_hacim.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(73, 60);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(44, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Kategori:";
            // 
            // c_kategori
            // 
            this.c_kategori.Location = new System.Drawing.Point(126, 57);
            this.c_kategori.Name = "c_kategori";
            this.c_kategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_kategori.Properties.Items.AddRange(new object[] {
            "Üretim",
            "Fason",
            "Aksesuar"});
            this.c_kategori.Size = new System.Drawing.Size(316, 20);
            this.c_kategori.TabIndex = 2;
            // 
            // t_seri
            // 
            this.t_seri.Location = new System.Drawing.Point(281, 90);
            this.t_seri.Name = "t_seri";
            this.t_seri.Size = new System.Drawing.Size(161, 20);
            this.t_seri.TabIndex = 4;
            // 
            // txt_fiyat
            // 
            this.txt_fiyat.Location = new System.Drawing.Point(228, 220);
            this.txt_fiyat.Name = "txt_fiyat";
            this.txt_fiyat.Size = new System.Drawing.Size(96, 20);
            this.txt_fiyat.TabIndex = 8;
            // 
            // t_tesf
            // 
            this.t_tesf.Location = new System.Drawing.Point(330, 220);
            this.t_tesf.Name = "t_tesf";
            this.t_tesf.Size = new System.Drawing.Size(114, 20);
            this.t_tesf.TabIndex = 9;
            // 
            // YeniUrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 418);
            this.Controls.Add(this.c_kategori);
            this.Controls.Add(this.t_tesf);
            this.Controls.Add(this.txt_fiyat);
            this.Controls.Add(this.t_hacim);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_logo);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.txt_ozelik);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.t_seri);
            this.Controls.Add(this.txt_marka);
            this.Controls.Add(this.t_barkod);
            this.Controls.Add(this.txt_kod);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Name = "YeniUrun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Ürün";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnalizYeni_FormClosing);
            this.Load += new System.EventHandler(this.AnalizYeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ozelik.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_marka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_barkod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_hacim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_kategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_seri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_fiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_tesf.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txt_ozelik;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_logo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_marka;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit t_barkod;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit t_hacim;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit c_kategori;
        private DevExpress.XtraEditors.TextEdit t_seri;
        private DevExpress.XtraEditors.TextEdit txt_fiyat;
        private DevExpress.XtraEditors.TextEdit t_tesf;
    }
}