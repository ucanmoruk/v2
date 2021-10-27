namespace mKYS.Talep
{
    partial class TedarikciEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TedarikciEkle));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_adres = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_tel = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_email = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_yetkili = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btn_ok = new DevExpress.XtraEditors.SimpleButton();
            this.txt_tur = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yetkili.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tur.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Firma Adı:";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(90, 22);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(339, 20);
            this.txt_ad.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(50, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Adres:";
            // 
            // txt_adres
            // 
            this.txt_adres.Location = new System.Drawing.Point(90, 50);
            this.txt_adres.Name = "txt_adres";
            this.txt_adres.Size = new System.Drawing.Size(339, 20);
            this.txt_adres.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(43, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Telefon:";
            // 
            // txt_tel
            // 
            this.txt_tel.Location = new System.Drawing.Point(90, 79);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(141, 20);
            this.txt_tel.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(250, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "E-Mail:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(288, 79);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(141, 20);
            this.txt_email.TabIndex = 4;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(52, 110);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(31, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Yetkili:";
            // 
            // txt_yetkili
            // 
            this.txt_yetkili.Location = new System.Drawing.Point(90, 107);
            this.txt_yetkili.Name = "txt_yetkili";
            this.txt_yetkili.Size = new System.Drawing.Size(339, 20);
            this.txt_yetkili.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(64, 140);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Tür:";
            // 
            // btn_ok
            // 
            this.btn_ok.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_ok.Appearance.Options.UseFont = true;
            this.btn_ok.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ok.ImageOptions.Image")));
            this.btn_ok.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ok.ImageOptions.ImageToTextIndent = 10;
            this.btn_ok.Location = new System.Drawing.Point(90, 174);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(339, 39);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "Tedarikçi Firma Ekle";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_tur
            // 
            this.txt_tur.Location = new System.Drawing.Point(90, 137);
            this.txt_tur.Name = "txt_tur";
            this.txt_tur.Size = new System.Drawing.Size(339, 20);
            this.txt_tur.TabIndex = 7;
            // 
            // TedarikciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 238);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txt_tur);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txt_yetkili);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txt_adres);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TedarikciEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Onaylı Tedarikçi Firma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TedarikciEkle_FormClosing);
            this.Load += new System.EventHandler(this.TedarikciEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_adres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_yetkili.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tur.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_adres;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_tel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_yetkili;
        private DevExpress.XtraEditors.TextEdit txt_email;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btn_ok;
        private DevExpress.XtraEditors.TextEdit txt_tur;
    }
}