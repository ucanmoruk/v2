namespace mKYS
{
    partial class TalepKabul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalepKabul));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_miktar = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_miktar = new DevExpress.XtraEditors.TextEdit();
            this.txt_birim = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btn_kabul = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sertifika = new DevExpress.XtraEditors.SimpleButton();
            this.combo_marka = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_tarih = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_sertifika = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_genel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbl_9 = new DevExpress.XtraEditors.LabelControl();
            this.txt_9 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.datekabul = new DevExpress.XtraEditors.DateEdit();
            this.txt_no = new DevExpress.XtraEditors.TextEdit();
            this.txt_detay = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_miktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_miktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_sertifika.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_genel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekabul.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekabul.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_no.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_detay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Talep Numarası:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(233, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Talep Detay:";
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(30, 49);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(492, 23);
            this.separatorControl1.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 120);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(131, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "İstenilen miktarda geldi mi ?";
            // 
            // combo_miktar
            // 
            this.combo_miktar.EditValue = "Evet";
            this.combo_miktar.Location = new System.Drawing.Point(237, 116);
            this.combo_miktar.Name = "combo_miktar";
            this.combo_miktar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_miktar.Properties.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.combo_miktar.Size = new System.Drawing.Size(86, 20);
            this.combo_miktar.TabIndex = 3;
            this.combo_miktar.SelectedIndexChanged += new System.EventHandler(this.combo_miktar_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(220, 84);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Kabul Şartları";
            // 
            // txt_miktar
            // 
            this.txt_miktar.Location = new System.Drawing.Point(353, 116);
            this.txt_miktar.Name = "txt_miktar";
            this.txt_miktar.Size = new System.Drawing.Size(69, 20);
            this.txt_miktar.TabIndex = 4;
            this.txt_miktar.Visible = false;
            // 
            // txt_birim
            // 
            this.txt_birim.Enabled = false;
            this.txt_birim.Location = new System.Drawing.Point(428, 116);
            this.txt_birim.Name = "txt_birim";
            this.txt_birim.Size = new System.Drawing.Size(56, 20);
            this.txt_birim.TabIndex = 4;
            this.txt_birim.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 151);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(189, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "İstenilen marka ve özelliklerde geldi mi ?";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(30, 211);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(122, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Sertifika gerektiriyor mu ?";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(30, 182);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(143, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Son kullanım tarihi uygun mu ?";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(30, 244);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(102, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Genel değerlendirme:";
            // 
            // btn_kabul
            // 
            this.btn_kabul.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_kabul.Appearance.Options.UseFont = true;
            this.btn_kabul.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_kabul.ImageOptions.Image")));
            this.btn_kabul.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_kabul.ImageOptions.ImageToTextIndent = 15;
            this.btn_kabul.Location = new System.Drawing.Point(237, 286);
            this.btn_kabul.Name = "btn_kabul";
            this.btn_kabul.Size = new System.Drawing.Size(247, 35);
            this.btn_kabul.TabIndex = 10;
            this.btn_kabul.Text = "Talebi Kabul Et";
            this.btn_kabul.Click += new System.EventHandler(this.btn_kabul_Click);
            // 
            // btn_sertifika
            // 
            this.btn_sertifika.Location = new System.Drawing.Point(353, 208);
            this.btn_sertifika.Name = "btn_sertifika";
            this.btn_sertifika.Size = new System.Drawing.Size(131, 20);
            this.btn_sertifika.TabIndex = 8;
            this.btn_sertifika.Text = "Sertifika Seç";
            this.btn_sertifika.Visible = false;
            this.btn_sertifika.Click += new System.EventHandler(this.btn_sertifika_Click);
            // 
            // combo_marka
            // 
            this.combo_marka.EditValue = "Evet";
            this.combo_marka.Location = new System.Drawing.Point(237, 147);
            this.combo_marka.Name = "combo_marka";
            this.combo_marka.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_marka.Properties.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.combo_marka.Size = new System.Drawing.Size(86, 20);
            this.combo_marka.TabIndex = 5;
            this.combo_marka.SelectedIndexChanged += new System.EventHandler(this.combo_marka_SelectedIndexChanged);
            // 
            // combo_tarih
            // 
            this.combo_tarih.EditValue = "Evet";
            this.combo_tarih.Location = new System.Drawing.Point(237, 178);
            this.combo_tarih.Name = "combo_tarih";
            this.combo_tarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_tarih.Properties.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.combo_tarih.Size = new System.Drawing.Size(86, 20);
            this.combo_tarih.TabIndex = 6;
            this.combo_tarih.SelectedIndexChanged += new System.EventHandler(this.combo_tarih_SelectedIndexChanged);
            // 
            // combo_sertifika
            // 
            this.combo_sertifika.EditValue = "Hayır";
            this.combo_sertifika.Location = new System.Drawing.Point(237, 208);
            this.combo_sertifika.Name = "combo_sertifika";
            this.combo_sertifika.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_sertifika.Properties.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.combo_sertifika.Size = new System.Drawing.Size(86, 20);
            this.combo_sertifika.TabIndex = 7;
            this.combo_sertifika.SelectedIndexChanged += new System.EventHandler(this.combo_sertifika_SelectedIndexChanged);
            // 
            // combo_genel
            // 
            this.combo_genel.EditValue = "Kabul";
            this.combo_genel.Location = new System.Drawing.Point(237, 240);
            this.combo_genel.Name = "combo_genel";
            this.combo_genel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_genel.Properties.Items.AddRange(new object[] {
            "Kabul",
            "Şartlı Kabul",
            "Red"});
            this.combo_genel.Size = new System.Drawing.Size(86, 20);
            this.combo_genel.TabIndex = 9;
            // 
            // lbl_9
            // 
            this.lbl_9.Location = new System.Drawing.Point(30, 304);
            this.lbl_9.Name = "lbl_9";
            this.lbl_9.Size = new System.Drawing.Size(114, 13);
            this.lbl_9.TabIndex = 0;
            this.lbl_9.Text = "Değerlendirmeyi Yapan:";
            this.lbl_9.Visible = false;
            // 
            // txt_9
            // 
            this.txt_9.Location = new System.Drawing.Point(237, 303);
            this.txt_9.Name = "txt_9";
            this.txt_9.Size = new System.Drawing.Size(256, 20);
            this.txt_9.TabIndex = 11;
            this.txt_9.Visible = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(30, 274);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(59, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Kabul Tarihi:";
            this.labelControl9.Visible = false;
            // 
            // datekabul
            // 
            this.datekabul.EditValue = null;
            this.datekabul.Location = new System.Drawing.Point(237, 271);
            this.datekabul.Name = "datekabul";
            this.datekabul.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datekabul.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datekabul.Size = new System.Drawing.Size(86, 20);
            this.datekabul.TabIndex = 12;
            this.datekabul.Visible = false;
            // 
            // txt_no
            // 
            this.txt_no.Location = new System.Drawing.Point(115, 18);
            this.txt_no.Name = "txt_no";
            this.txt_no.Size = new System.Drawing.Size(68, 20);
            this.txt_no.TabIndex = 13;
            // 
            // txt_detay
            // 
            this.txt_detay.Location = new System.Drawing.Point(301, 18);
            this.txt_detay.Name = "txt_detay";
            this.txt_detay.Size = new System.Drawing.Size(192, 20);
            this.txt_detay.TabIndex = 13;
            // 
            // TalepKabul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 355);
            this.Controls.Add(this.txt_detay);
            this.Controls.Add(this.txt_no);
            this.Controls.Add(this.datekabul);
            this.Controls.Add(this.txt_9);
            this.Controls.Add(this.btn_sertifika);
            this.Controls.Add(this.btn_kabul);
            this.Controls.Add(this.txt_birim);
            this.Controls.Add(this.txt_miktar);
            this.Controls.Add(this.separatorControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.combo_genel);
            this.Controls.Add(this.combo_sertifika);
            this.Controls.Add(this.combo_tarih);
            this.Controls.Add(this.combo_marka);
            this.Controls.Add(this.combo_miktar);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lbl_9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TalepKabul";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talep Değerlendirme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TalepKabul_FormClosing);
            this.Load += new System.EventHandler(this.TalepKabul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_miktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_miktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_tarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_sertifika.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_genel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekabul.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datekabul.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_no.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_detay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit combo_miktar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_miktar;
        private DevExpress.XtraEditors.TextEdit txt_birim;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btn_kabul;
        private DevExpress.XtraEditors.SimpleButton btn_sertifika;
        private DevExpress.XtraEditors.ComboBoxEdit combo_marka;
        private DevExpress.XtraEditors.ComboBoxEdit combo_tarih;
        private DevExpress.XtraEditors.ComboBoxEdit combo_sertifika;
        private DevExpress.XtraEditors.ComboBoxEdit combo_genel;
        private DevExpress.XtraEditors.LabelControl lbl_9;
        private DevExpress.XtraEditors.TextEdit txt_9;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.DateEdit datekabul;
        private DevExpress.XtraEditors.TextEdit txt_no;
        private DevExpress.XtraEditors.TextEdit txt_detay;
    }
}