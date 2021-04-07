namespace StokTakip
{
    partial class Personel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personel));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.txt_soyad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_gorev = new DevExpress.XtraEditors.TextEdit();
            this.txt_email = new DevExpress.XtraEditors.TextEdit();
            this.txt_telefon = new DevExpress.XtraEditors.TextEdit();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_gorev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_telefon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ad / Soyad:";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(112, 32);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(143, 22);
            this.txt_ad.TabIndex = 1;
            // 
            // txt_soyad
            // 
            this.txt_soyad.Location = new System.Drawing.Point(261, 32);
            this.txt_soyad.Name = "txt_soyad";
            this.txt_soyad.Size = new System.Drawing.Size(140, 22);
            this.txt_soyad.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(62, 107);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Görev:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 141);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "E-Mail:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(52, 176);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Telefon:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(64, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(112, 69);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(289, 22);
            this.combo_birim.TabIndex = 3;
            // 
            // txt_gorev
            // 
            this.txt_gorev.Location = new System.Drawing.Point(112, 104);
            this.txt_gorev.Name = "txt_gorev";
            this.txt_gorev.Size = new System.Drawing.Size(289, 22);
            this.txt_gorev.TabIndex = 4;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(112, 138);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(289, 22);
            this.txt_email.TabIndex = 5;
            // 
            // txt_telefon
            // 
            this.txt_telefon.Location = new System.Drawing.Point(112, 173);
            this.txt_telefon.Name = "txt_telefon";
            this.txt_telefon.Size = new System.Drawing.Size(289, 22);
            this.txt_telefon.TabIndex = 6;
            // 
            // btn_ekle
            // 
            this.btn_ekle.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btn_ekle.Appearance.Options.UseFont = true;
            this.btn_ekle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_ekle.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ekle.ImageOptions.ImageToTextIndent = 5;
            this.btn_ekle.Location = new System.Drawing.Point(112, 219);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(289, 50);
            this.btn_ekle.TabIndex = 3;
            this.btn_ekle.Text = "Personel Ekle";
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // Personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 314);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.txt_soyad);
            this.Controls.Add(this.txt_telefon);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_gorev);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Personel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personel Bilgileri";
            this.Load += new System.EventHandler(this.Personel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_gorev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_telefon.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.TextEdit txt_soyad;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
        private DevExpress.XtraEditors.TextEdit txt_gorev;
        private DevExpress.XtraEditors.TextEdit txt_email;
        private DevExpress.XtraEditors.TextEdit txt_telefon;
        private DevExpress.XtraEditors.SimpleButton btn_ekle;
    }
}