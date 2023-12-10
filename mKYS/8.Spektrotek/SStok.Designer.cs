namespace mROOT._8.Spektrotek
{
    partial class SStok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SStok));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.t_kod = new DevExpress.XtraEditors.TextEdit();
            this.t_barkod = new DevExpress.XtraEditors.TextEdit();
            this.c_kategori = new DevExpress.XtraEditors.ComboBoxEdit();
            this.t_ad = new DevExpress.XtraEditors.TextEdit();
            this.t_stok = new DevExpress.XtraEditors.TextEdit();
            this.c_miktar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.b_kaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tmarka = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.t_lot = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.tsatis = new DevExpress.XtraEditors.TextEdit();
            this.tpara = new DevExpress.XtraEditors.ComboBoxEdit();
            this.tkdv = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.t_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_barkod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_kategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_stok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_miktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_lot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsatis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkdv.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kod / Barkod:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(65, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Kategori:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(62, 123);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Ürün Adı:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(47, 154);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(59, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Stok Miktarı:";
            // 
            // t_kod
            // 
            this.t_kod.Location = new System.Drawing.Point(116, 26);
            this.t_kod.Name = "t_kod";
            this.t_kod.Size = new System.Drawing.Size(124, 20);
            this.t_kod.TabIndex = 1;
            // 
            // t_barkod
            // 
            this.t_barkod.Location = new System.Drawing.Point(246, 26);
            this.t_barkod.Name = "t_barkod";
            this.t_barkod.Size = new System.Drawing.Size(143, 20);
            this.t_barkod.TabIndex = 2;
            // 
            // c_kategori
            // 
            this.c_kategori.Location = new System.Drawing.Point(116, 58);
            this.c_kategori.Name = "c_kategori";
            this.c_kategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_kategori.Properties.Items.AddRange(new object[] {
            "Cihaz - Enstrumantal",
            "Cihaz - Yedek Parça",
            "Cihaz - Temel Lab.",
            "Cihaz - Sarf",
            "Sarf Malzeme",
            "Kimyasal",
            "Standart",
            "Diğer"});
            this.c_kategori.Size = new System.Drawing.Size(273, 20);
            this.c_kategori.TabIndex = 3;
            // 
            // t_ad
            // 
            this.t_ad.Location = new System.Drawing.Point(116, 119);
            this.t_ad.Name = "t_ad";
            this.t_ad.Size = new System.Drawing.Size(273, 20);
            this.t_ad.TabIndex = 5;
            // 
            // t_stok
            // 
            this.t_stok.Location = new System.Drawing.Point(116, 150);
            this.t_stok.Name = "t_stok";
            this.t_stok.Size = new System.Drawing.Size(124, 20);
            this.t_stok.TabIndex = 6;
            // 
            // c_miktar
            // 
            this.c_miktar.Location = new System.Drawing.Point(246, 150);
            this.c_miktar.Name = "c_miktar";
            this.c_miktar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.c_miktar.Properties.Items.AddRange(new object[] {
            "Adet",
            "Paket",
            "Kutu",
            "mL",
            "L",
            "g"});
            this.c_miktar.Size = new System.Drawing.Size(143, 20);
            this.c_miktar.TabIndex = 7;
            this.c_miktar.SelectedIndexChanged += new System.EventHandler(this.c_miktar_SelectedIndexChanged);
            // 
            // b_kaydet
            // 
            this.b_kaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.b_kaydet.Appearance.Options.UseFont = true;
            this.b_kaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("b_kaydet.ImageOptions.Image")));
            this.b_kaydet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.b_kaydet.ImageOptions.ImageToTextIndent = 10;
            this.b_kaydet.Location = new System.Drawing.Point(246, 311);
            this.b_kaydet.Name = "b_kaydet";
            this.b_kaydet.Size = new System.Drawing.Size(143, 41);
            this.b_kaydet.TabIndex = 13;
            this.b_kaydet.Text = "Kaydet";
            this.b_kaydet.Click += new System.EventHandler(this.b_kaydet_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(72, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Marka:";
            // 
            // tmarka
            // 
            this.tmarka.Location = new System.Drawing.Point(116, 89);
            this.tmarka.Name = "tmarka";
            this.tmarka.Size = new System.Drawing.Size(273, 20);
            this.tmarka.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(42, 183);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(63, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Seri / Lot No:";
            // 
            // t_lot
            // 
            this.t_lot.Location = new System.Drawing.Point(116, 180);
            this.t_lot.Name = "t_lot";
            this.t_lot.Size = new System.Drawing.Size(273, 20);
            this.t_lot.TabIndex = 8;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(72, 246);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Notlar:";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(116, 246);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(273, 54);
            this.memoEdit1.TabIndex = 12;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(19, 214);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(87, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Satış Tutarı / KDV:";
            // 
            // tsatis
            // 
            this.tsatis.Location = new System.Drawing.Point(116, 211);
            this.tsatis.Name = "tsatis";
            this.tsatis.Size = new System.Drawing.Size(124, 20);
            this.tsatis.TabIndex = 9;
            // 
            // tpara
            // 
            this.tpara.Location = new System.Drawing.Point(246, 211);
            this.tpara.Name = "tpara";
            this.tpara.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tpara.Properties.Items.AddRange(new object[] {
            "₺",
            "$",
            "€"});
            this.tpara.Size = new System.Drawing.Size(61, 20);
            this.tpara.TabIndex = 10;
            // 
            // tkdv
            // 
            this.tkdv.Location = new System.Drawing.Point(313, 211);
            this.tkdv.Name = "tkdv";
            this.tkdv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tkdv.Properties.Items.AddRange(new object[] {
            "0",
            "1",
            "10",
            "20"});
            this.tkdv.Size = new System.Drawing.Size(76, 20);
            this.tkdv.TabIndex = 11;
            // 
            // SStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 375);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.b_kaydet);
            this.Controls.Add(this.tkdv);
            this.Controls.Add(this.tpara);
            this.Controls.Add(this.c_miktar);
            this.Controls.Add(this.c_kategori);
            this.Controls.Add(this.t_barkod);
            this.Controls.Add(this.tsatis);
            this.Controls.Add(this.t_lot);
            this.Controls.Add(this.t_stok);
            this.Controls.Add(this.tmarka);
            this.Controls.Add(this.t_ad);
            this.Controls.Add(this.t_kod);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SStok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Ekleme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SStok_FormClosed);
            this.Load += new System.EventHandler(this.SStok_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_barkod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_kategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_stok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c_miktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_lot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsatis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tpara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkdv.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit t_kod;
        private DevExpress.XtraEditors.TextEdit t_barkod;
        private DevExpress.XtraEditors.ComboBoxEdit c_kategori;
        private DevExpress.XtraEditors.TextEdit t_ad;
        private DevExpress.XtraEditors.TextEdit t_stok;
        private DevExpress.XtraEditors.ComboBoxEdit c_miktar;
        private DevExpress.XtraEditors.SimpleButton b_kaydet;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tmarka;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit t_lot;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit tsatis;
        private DevExpress.XtraEditors.ComboBoxEdit tpara;
        private DevExpress.XtraEditors.ComboBoxEdit tkdv;
    }
}