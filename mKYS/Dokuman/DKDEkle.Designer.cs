namespace mKYS.Dokuman
{
    partial class DKDEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DKDEkle));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_dokuman = new DevExpress.XtraEditors.TextEdit();
            this.txt_kaynak = new DevExpress.XtraEditors.TextEdit();
            this.combo_tur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.lbl_bas = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btn_sec = new DevExpress.XtraEditors.SimpleButton();
            this.txt_tarih = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txt_link = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dokuman.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kaynak.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_link.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 114);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Doküman Adı:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(249, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Kaynak:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(79, 22);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Tür:";
            // 
            // txt_dokuman
            // 
            this.txt_dokuman.Location = new System.Drawing.Point(107, 111);
            this.txt_dokuman.Name = "txt_dokuman";
            this.txt_dokuman.Size = new System.Drawing.Size(296, 20);
            this.txt_dokuman.TabIndex = 5;
            // 
            // txt_kaynak
            // 
            this.txt_kaynak.Location = new System.Drawing.Point(294, 19);
            this.txt_kaynak.Name = "txt_kaynak";
            this.txt_kaynak.Size = new System.Drawing.Size(109, 20);
            this.txt_kaynak.TabIndex = 2;
            // 
            // combo_tur
            // 
            this.combo_tur.Location = new System.Drawing.Point(107, 19);
            this.combo_tur.Name = "combo_tur";
            this.combo_tur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_tur.Properties.Items.AddRange(new object[] {
            "Elektronik",
            "Kağıt"});
            this.combo_tur.Size = new System.Drawing.Size(122, 20);
            this.combo_tur.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 180);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Geçerli Tarih:";
            // 
            // btn_ekle
            // 
            this.btn_ekle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_ekle.Appearance.Options.UseFont = true;
            this.btn_ekle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ekle.ImageOptions.Image")));
            this.btn_ekle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ekle.ImageOptions.ImageToTextIndent = 10;
            this.btn_ekle.Location = new System.Drawing.Point(107, 250);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(296, 45);
            this.btn_ekle.TabIndex = 9;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(77, 84);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(22, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Kod:";
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(107, 81);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Size = new System.Drawing.Size(296, 20);
            this.txt_kod.TabIndex = 4;
            // 
            // lbl_bas
            // 
            this.lbl_bas.Location = new System.Drawing.Point(203, 215);
            this.lbl_bas.Name = "lbl_bas";
            this.lbl_bas.Size = new System.Drawing.Size(115, 13);
            this.lbl_bas.TabIndex = 15;
            this.lbl_bas.Text = "Doküman seçimi başarılı.";
            this.lbl_bas.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(29, 215);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Doküman Seç:";
            // 
            // btn_sec
            // 
            this.btn_sec.Location = new System.Drawing.Point(107, 210);
            this.btn_sec.Name = "btn_sec";
            this.btn_sec.Size = new System.Drawing.Size(85, 23);
            this.btn_sec.TabIndex = 8;
            this.btn_sec.Text = "Doküman Seç";
            this.btn_sec.Click += new System.EventHandler(this.btn_sec_Click);
            // 
            // txt_tarih
            // 
            this.txt_tarih.Location = new System.Drawing.Point(107, 177);
            this.txt_tarih.Name = "txt_tarih";
            this.txt_tarih.Size = new System.Drawing.Size(191, 20);
            this.txt_tarih.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(75, 146);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(22, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Link:";
            // 
            // txt_link
            // 
            this.txt_link.Location = new System.Drawing.Point(107, 143);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(296, 20);
            this.txt_link.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(73, 54);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(26, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(107, 51);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(296, 20);
            this.combo_birim.TabIndex = 3;
            // 
            // DKDEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 322);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.lbl_bas);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btn_sec);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.combo_tur);
            this.Controls.Add(this.txt_kod);
            this.Controls.Add(this.txt_tarih);
            this.Controls.Add(this.txt_kaynak);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.txt_dokuman);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "DKDEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dış Kaynaklı Doküman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DKDEkle_FormClosing);
            this.Load += new System.EventHandler(this.DKDEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_dokuman.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kaynak.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_link.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_dokuman;
        private DevExpress.XtraEditors.TextEdit txt_kaynak;
        private DevExpress.XtraEditors.ComboBoxEdit combo_tur;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.LabelControl lbl_bas;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btn_sec;
        private DevExpress.XtraEditors.TextEdit txt_tarih;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txt_link;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
    }
}