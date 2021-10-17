namespace StokTakip.Dokuman
{
    partial class DokumanYeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DokumanYeni));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_tur = new DevExpress.XtraEditors.TextEdit();
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_rev = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.date_yayin = new DevExpress.XtraEditors.DateEdit();
            this.date_rev = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_sec = new DevExpress.XtraEditors.SimpleButton();
            this.btn_yukle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.combo_durum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbl_bas = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_durum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Doküman Tür:";
            // 
            // txt_tur
            // 
            this.txt_tur.Location = new System.Drawing.Point(131, 21);
            this.txt_tur.Name = "txt_tur";
            this.txt_tur.Size = new System.Drawing.Size(268, 20);
            this.txt_tur.TabIndex = 1;
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(131, 81);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Size = new System.Drawing.Size(124, 20);
            this.txt_kod.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(58, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Doküman Ad:";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(131, 51);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(268, 20);
            this.txt_ad.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 115);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Revizyon No / Tarih:";
            // 
            // txt_rev
            // 
            this.txt_rev.Location = new System.Drawing.Point(131, 112);
            this.txt_rev.Name = "txt_rev";
            this.txt_rev.Size = new System.Drawing.Size(124, 20);
            this.txt_rev.TabIndex = 5;
            this.txt_rev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_rev_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(35, 84);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(87, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Kod / Yayın Tarihi:";
            // 
            // date_yayin
            // 
            this.date_yayin.EditValue = null;
            this.date_yayin.Location = new System.Drawing.Point(261, 81);
            this.date_yayin.Name = "date_yayin";
            this.date_yayin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_yayin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_yayin.Size = new System.Drawing.Size(138, 20);
            this.date_yayin.TabIndex = 4;
            // 
            // date_rev
            // 
            this.date_rev.EditValue = null;
            this.date_rev.Location = new System.Drawing.Point(261, 112);
            this.date_rev.Name = "date_rev";
            this.date_rev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_rev.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_rev.Size = new System.Drawing.Size(138, 20);
            this.date_rev.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(54, 177);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(68, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Doküman Seç:";
            // 
            // btn_sec
            // 
            this.btn_sec.Location = new System.Drawing.Point(131, 172);
            this.btn_sec.Name = "btn_sec";
            this.btn_sec.Size = new System.Drawing.Size(124, 23);
            this.btn_sec.TabIndex = 8;
            this.btn_sec.Text = "Doküman Seç";
            this.btn_sec.Click += new System.EventHandler(this.btn_sec_Click);
            // 
            // btn_yukle
            // 
            this.btn_yukle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_yukle.Appearance.Options.UseFont = true;
            this.btn_yukle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_yukle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_yukle.ImageOptions.ImageToTextIndent = 10;
            this.btn_yukle.Location = new System.Drawing.Point(131, 210);
            this.btn_yukle.Name = "btn_yukle";
            this.btn_yukle.Size = new System.Drawing.Size(268, 46);
            this.btn_yukle.TabIndex = 9;
            this.btn_yukle.Text = "Doküman Ekle";
            this.btn_yukle.Click += new System.EventHandler(this.btn_yukle_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(81, 144);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(41, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Durumu:";
            // 
            // combo_durum
            // 
            this.combo_durum.EditValue = "Yayında";
            this.combo_durum.Location = new System.Drawing.Point(131, 141);
            this.combo_durum.Name = "combo_durum";
            this.combo_durum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_durum.Properties.Items.AddRange(new object[] {
            "Yayında",
            "Yayından Kaldırıldı"});
            this.combo_durum.Size = new System.Drawing.Size(268, 20);
            this.combo_durum.TabIndex = 7;
            // 
            // lbl_bas
            // 
            this.lbl_bas.Location = new System.Drawing.Point(261, 177);
            this.lbl_bas.Name = "lbl_bas";
            this.lbl_bas.Size = new System.Drawing.Size(67, 13);
            this.lbl_bas.TabIndex = 13;
            this.lbl_bas.Text = "Seçim başarılı!";
            this.lbl_bas.Visible = false;
            // 
            // DokumanYeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 274);
            this.Controls.Add(this.lbl_bas);
            this.Controls.Add(this.combo_durum);
            this.Controls.Add(this.btn_yukle);
            this.Controls.Add(this.btn_sec);
            this.Controls.Add(this.date_rev);
            this.Controls.Add(this.date_yayin);
            this.Controls.Add(this.txt_kod);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_rev);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_tur);
            this.Controls.Add(this.labelControl1);
            this.Name = "DokumanYeni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doküman Ekleme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DokumanYeni_FormClosing);
            this.Load += new System.EventHandler(this.DokumanYeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_tur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_rev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_yayin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_rev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_durum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_tur;
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_rev;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit date_yayin;
        private DevExpress.XtraEditors.DateEdit date_rev;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_sec;
        private DevExpress.XtraEditors.SimpleButton btn_yukle;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit combo_durum;
        private DevExpress.XtraEditors.LabelControl lbl_bas;
    }
}