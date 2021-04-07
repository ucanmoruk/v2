namespace StokTakip
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.btn_giris = new DevExpress.XtraEditors.SimpleButton();
            this.txt_parola = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_ad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_parola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_giris
            // 
            this.btn_giris.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_giris.Appearance.Options.UseFont = true;
            this.btn_giris.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_giris.ImageOptions.Image")));
            this.btn_giris.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_giris.ImageOptions.ImageToTextIndent = 10;
            this.btn_giris.Location = new System.Drawing.Point(527, 405);
            this.btn_giris.Margin = new System.Windows.Forms.Padding(4);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(151, 60);
            this.btn_giris.TabIndex = 3;
            this.btn_giris.Text = "Giriş Yap";
            this.btn_giris.Click += new System.EventHandler(this.btn_giris_Click);
            // 
            // txt_parola
            // 
            this.txt_parola.Location = new System.Drawing.Point(187, 440);
            this.txt_parola.Margin = new System.Windows.Forms.Padding(4);
            this.txt_parola.Name = "txt_parola";
            this.txt_parola.Properties.PasswordChar = '*';
            this.txt_parola.Size = new System.Drawing.Size(317, 22);
            this.txt_parola.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(125, 444);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Parola :";
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(187, 406);
            this.txt_ad.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(317, 22);
            this.txt_ad.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 410);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 16);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Kullanıcı Adı :";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(-140, -18);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(1080, 400);
            this.pictureEdit1.TabIndex = 4;
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.txt_parola);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "Giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoşgeldiniz..";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Giris_FormClosing);
            this.Load += new System.EventHandler(this.Giris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_parola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_giris;
        private DevExpress.XtraEditors.TextEdit txt_parola;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_ad;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}