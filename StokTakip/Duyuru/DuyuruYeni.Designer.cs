namespace StokTakip.Duyuru
{
    partial class DuyuruYeni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuyuruYeni));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.memo_mesaj = new DevExpress.XtraEditors.MemoEdit();
            this.btn_yayin = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Combo_alici = new DevExpress.XtraEditors.ComboBoxEdit();
            this.combo_personel = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memo_mesaj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combo_alici.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_personel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mesajınız:";
            // 
            // memo_mesaj
            // 
            this.memo_mesaj.Location = new System.Drawing.Point(86, 23);
            this.memo_mesaj.Name = "memo_mesaj";
            this.memo_mesaj.Size = new System.Drawing.Size(341, 69);
            this.memo_mesaj.TabIndex = 1;
            // 
            // btn_yayin
            // 
            this.btn_yayin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_yayin.Appearance.Options.UseFont = true;
            this.btn_yayin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_yayin.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_yayin.ImageOptions.ImageToTextIndent = 15;
            this.btn_yayin.Location = new System.Drawing.Point(86, 170);
            this.btn_yayin.Name = "btn_yayin";
            this.btn_yayin.Size = new System.Drawing.Size(341, 51);
            this.btn_yayin.TabIndex = 4;
            this.btn_yayin.Text = "Yayınla";
            this.btn_yayin.Click += new System.EventHandler(this.btn_yayin_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(45, 106);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Alıcılar:";
            // 
            // Combo_alici
            // 
            this.Combo_alici.Location = new System.Drawing.Point(86, 103);
            this.Combo_alici.Name = "Combo_alici";
            this.Combo_alici.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Combo_alici.Properties.Items.AddRange(new object[] {
            "Herkese ulaşsın",
            "Sadece seçtiğim personele ulaşsın"});
            this.Combo_alici.Size = new System.Drawing.Size(341, 20);
            this.Combo_alici.TabIndex = 2;
            this.Combo_alici.SelectedIndexChanged += new System.EventHandler(this.Combo_alici_SelectedIndexChanged);
            // 
            // combo_personel
            // 
            this.combo_personel.Enabled = false;
            this.combo_personel.Location = new System.Drawing.Point(86, 133);
            this.combo_personel.Name = "combo_personel";
            this.combo_personel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_personel.Size = new System.Drawing.Size(341, 20);
            this.combo_personel.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Personel:";
            // 
            // DuyuruYeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 252);
            this.Controls.Add(this.combo_personel);
            this.Controls.Add(this.Combo_alici);
            this.Controls.Add(this.btn_yayin);
            this.Controls.Add(this.memo_mesaj);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuyuruYeni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Duyuru!";
            this.Load += new System.EventHandler(this.DuyuruYeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memo_mesaj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Combo_alici.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_personel.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memo_mesaj;
        private DevExpress.XtraEditors.SimpleButton btn_yayin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit Combo_alici;
        private DevExpress.XtraEditors.CheckedComboBoxEdit combo_personel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}