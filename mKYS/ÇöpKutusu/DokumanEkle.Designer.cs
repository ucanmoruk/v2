namespace mKYS.Dokuman
{
    partial class DokumanEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DokumanEkle));
            this.lbl_bas = new DevExpress.XtraEditors.LabelControl();
            this.btn_yukle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sec = new DevExpress.XtraEditors.SimpleButton();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.date_yayin = new DevExpress.XtraEditors.DateEdit();
            this.combo_tur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_rev = new DevExpress.XtraEditors.TextEdit();
            this.date_rev = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_aciklama = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.combo_durum = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_durum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_bas
            // 
            this.lbl_bas.Location = new System.Drawing.Point(240, 12);
            this.lbl_bas.Name = "lbl_bas";
            this.lbl_bas.Size = new System.Drawing.Size(115, 13);
            this.lbl_bas.TabIndex = 12;
            this.lbl_bas.Text = "Doküman seçimi başarılı.";
            this.lbl_bas.Visible = false;
            // 
            // btn_yukle
            // 
            this.btn_yukle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_yukle.Appearance.Options.UseFont = true;
            this.btn_yukle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_yukle.ImageOptions.Image")));
            this.btn_yukle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_yukle.ImageOptions.ImageToTextIndent = 10;
            this.btn_yukle.Location = new System.Drawing.Point(145, 45);
            this.btn_yukle.Name = "btn_yukle";
            this.btn_yukle.Size = new System.Drawing.Size(384, 38);
            this.btn_yukle.TabIndex = 9;
            this.btn_yukle.Text = "Yeni Doküman Ekle";
            this.btn_yukle.Click += new System.EventHandler(this.btn_yukle_Click);
            // 
            // btn_sec
            // 
            this.btn_sec.Location = new System.Drawing.Point(144, 7);
            this.btn_sec.Name = "btn_sec";
            this.btn_sec.Size = new System.Drawing.Size(85, 23);
            this.btn_sec.TabIndex = 8;
            this.btn_sec.Text = "Doküman Seç";
            this.btn_sec.Click += new System.EventHandler(this.btn_sec_Click);
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(145, 53);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(384, 20);
            this.txt_ad.TabIndex = 4;
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(268, 22);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Size = new System.Drawing.Size(138, 20);
            this.txt_kod.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(66, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Doküman Seç:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Tür / Kod / Yayın Tarihi:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(118, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(17, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Ad:";
            // 
            // date_yayin
            // 
            this.date_yayin.EditValue = null;
            this.date_yayin.Location = new System.Drawing.Point(412, 22);
            this.date_yayin.Name = "date_yayin";
            this.date_yayin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_yayin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_yayin.Size = new System.Drawing.Size(117, 20);
            this.date_yayin.TabIndex = 3;
            // 
            // combo_tur
            // 
            this.combo_tur.Location = new System.Drawing.Point(144, 22);
            this.combo_tur.Name = "combo_tur";
            this.combo_tur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_tur.Properties.Items.AddRange(new object[] {
            "El Kitabı",
            "Prosedür",
            "Talimat",
            "Çizelge",
            "Ek",
            "Analiz Talimatı",
            "Cihaz Kullanım Talimatı"});
            this.combo_tur.Size = new System.Drawing.Size(118, 20);
            this.combo_tur.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(39, 86);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Revizyon No / Tarih:";
            // 
            // txt_rev
            // 
            this.txt_rev.Location = new System.Drawing.Point(145, 83);
            this.txt_rev.Name = "txt_rev";
            this.txt_rev.Size = new System.Drawing.Size(75, 20);
            this.txt_rev.TabIndex = 5;
            this.txt_rev.ToolTip = "Sadece sayı girebilirsiniz";
            this.txt_rev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rev_KeyPress);
            // 
            // date_rev
            // 
            this.date_rev.EditValue = null;
            this.date_rev.Location = new System.Drawing.Point(226, 83);
            this.date_rev.Name = "date_rev";
            this.date_rev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_rev.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_rev.Size = new System.Drawing.Size(144, 20);
            this.date_rev.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(88, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Açıklama:";
            // 
            // txt_aciklama
            // 
            this.txt_aciklama.Location = new System.Drawing.Point(143, 7);
            this.txt_aciklama.Name = "txt_aciklama";
            this.txt_aciklama.Size = new System.Drawing.Size(384, 20);
            this.txt_aciklama.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Right;
            this.groupControl1.Controls.Add(this.combo_durum);
            this.groupControl1.Controls.Add(this.txt_ad);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.date_rev);
            this.groupControl1.Controls.Add(this.date_yayin);
            this.groupControl1.Controls.Add(this.txt_rev);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.combo_tur);
            this.groupControl1.Controls.Add(this.txt_kod);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(566, 107);
            this.groupControl1.TabIndex = 16;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Controls.Add(this.txt_aciklama);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(0, 107);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(566, 34);
            this.groupControl2.TabIndex = 17;
            this.groupControl2.Visible = false;
            // 
            // groupControl3
            // 
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.lbl_bas);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.btn_sec);
            this.groupControl3.Controls.Add(this.btn_yukle);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl3.Location = new System.Drawing.Point(0, 141);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(566, 156);
            this.groupControl3.TabIndex = 18;
            // 
            // combo_durum
            // 
            this.combo_durum.Location = new System.Drawing.Point(376, 83);
            this.combo_durum.Name = "combo_durum";
            this.combo_durum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_durum.Properties.Items.AddRange(new object[] {
            "Yayında",
            "Yayından Kaldırıldı"});
            this.combo_durum.Size = new System.Drawing.Size(153, 20);
            this.combo_durum.TabIndex = 8;
            // 
            // DokumanEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 243);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "DokumanEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Doküman";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DokumanEkle_FormClosing);
            this.Load += new System.EventHandler(this.DokumanEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_aciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo_durum.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_bas;
        private DevExpress.XtraEditors.SimpleButton btn_yukle;
        private DevExpress.XtraEditors.SimpleButton btn_sec;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit date_yayin;
        private DevExpress.XtraEditors.ComboBoxEdit combo_tur;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_rev;
        private DevExpress.XtraEditors.DateEdit date_rev;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_aciklama;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit combo_durum;
    }
}