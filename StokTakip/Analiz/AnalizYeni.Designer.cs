namespace StokTakip.Analiz
{
    partial class AnalizYeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalizYeni));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_kod = new DevExpress.XtraEditors.TextEdit();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_metot = new DevExpress.XtraEditors.TextEdit();
            this.txt_matriks = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_akre = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_metot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matriks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_akre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(235, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kod:";
            // 
            // txt_kod
            // 
            this.txt_kod.Location = new System.Drawing.Point(266, 55);
            this.txt_kod.Name = "txt_kod";
            this.txt_kod.Size = new System.Drawing.Size(156, 20);
            this.txt_kod.TabIndex = 3;
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(104, 86);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(318, 20);
            this.txt_ad.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(60, 119);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Metot:";
            // 
            // txt_metot
            // 
            this.txt_metot.Location = new System.Drawing.Point(104, 116);
            this.txt_metot.Name = "txt_metot";
            this.txt_metot.Size = new System.Drawing.Size(318, 20);
            this.txt_metot.TabIndex = 5;
            // 
            // txt_matriks
            // 
            this.txt_matriks.Location = new System.Drawing.Point(104, 147);
            this.txt_matriks.Name = "txt_matriks";
            this.txt_matriks.Size = new System.Drawing.Size(318, 20);
            this.txt_matriks.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Akreditasyon:";
            // 
            // combo_akre
            // 
            this.combo_akre.Location = new System.Drawing.Point(104, 55);
            this.combo_akre.Name = "combo_akre";
            this.combo_akre.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_akre.Properties.Items.AddRange(new object[] {
            "Var",
            "Yok"});
            this.combo_akre.Size = new System.Drawing.Size(112, 20);
            this.combo_akre.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(75, 89);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(17, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Ad:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(60, 150);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Matriks:";
            // 
            // btn_add
            // 
            this.btn_add.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_add.Appearance.Options.UseFont = true;
            this.btn_add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_add.ImageOptions.Image")));
            this.btn_add.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_add.ImageOptions.ImageToTextIndent = 10;
            this.btn_add.Location = new System.Drawing.Point(104, 185);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(318, 46);
            this.btn_add.TabIndex = 7;
            this.btn_add.Text = "Analiz Ekle";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(66, 26);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(104, 22);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(318, 20);
            this.combo_birim.TabIndex = 1;
            this.combo_birim.SelectedIndexChanged += new System.EventHandler(this.combo_birim_SelectedIndexChanged);
            // 
            // AnalizYeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 257);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.combo_akre);
            this.Controls.Add(this.txt_matriks);
            this.Controls.Add(this.txt_metot);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.txt_kod);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Name = "AnalizYeni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analiz Ekleme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnalizYeni_FormClosing);
            this.Load += new System.EventHandler(this.AnalizYeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_kod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_metot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matriks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_akre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_kod;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_metot;
        private DevExpress.XtraEditors.TextEdit txt_matriks;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit combo_akre;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
    }
}