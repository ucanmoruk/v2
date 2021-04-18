namespace StokTakip
{
    partial class StokEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokEkle));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.combokod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.txtmarka = new DevExpress.XtraEditors.TextEdit();
            this.txtlot = new DevExpress.XtraEditors.TextEdit();
            this.txtmiktar = new DevExpress.XtraEditors.TextEdit();
            this.txtbirim = new DevExpress.XtraEditors.TextEdit();
            this.dateskt = new DevExpress.XtraEditors.DateEdit();
            this.dategiris = new DevExpress.XtraEditors.DateEdit();
            this.btnsertifika = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Stok Kodu:";
            // 
            // combokod
            // 
            this.combokod.Location = new System.Drawing.Point(125, 21);
            this.combokod.Name = "combokod";
            this.combokod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combokod.Size = new System.Drawing.Size(152, 20);
            this.combokod.TabIndex = 1;
            this.combokod.SelectedIndexChanged += new System.EventHandler(this.combokod_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(86, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Marka:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(84, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Lot No:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(59, 140);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Miktar/Birim:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(26, 170);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(92, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Son Kullanım Tarihi:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(42, 200);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Stok Giriş Tarihi:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(47, 232);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(71, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Sertifika Yükle:";
            // 
            // btnadd
            // 
            this.btnadd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadd.Appearance.Options.UseFont = true;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnadd.ImageOptions.ImageToTextIndent = 10;
            this.btnadd.Location = new System.Drawing.Point(125, 265);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(152, 34);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "Stok Ekle";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtmarka
            // 
            this.txtmarka.Location = new System.Drawing.Point(125, 77);
            this.txtmarka.Name = "txtmarka";
            this.txtmarka.Size = new System.Drawing.Size(152, 20);
            this.txtmarka.TabIndex = 3;
            // 
            // txtlot
            // 
            this.txtlot.Location = new System.Drawing.Point(125, 106);
            this.txtlot.Name = "txtlot";
            this.txtlot.Size = new System.Drawing.Size(152, 20);
            this.txtlot.TabIndex = 4;
            // 
            // txtmiktar
            // 
            this.txtmiktar.Location = new System.Drawing.Point(125, 136);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(77, 20);
            this.txtmiktar.TabIndex = 5;
            // 
            // txtbirim
            // 
            this.txtbirim.Enabled = false;
            this.txtbirim.Location = new System.Drawing.Point(208, 136);
            this.txtbirim.Name = "txtbirim";
            this.txtbirim.Size = new System.Drawing.Size(69, 20);
            this.txtbirim.TabIndex = 6;
            // 
            // dateskt
            // 
            this.dateskt.EditValue = null;
            this.dateskt.Location = new System.Drawing.Point(125, 167);
            this.dateskt.Name = "dateskt";
            this.dateskt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateskt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateskt.Size = new System.Drawing.Size(152, 20);
            this.dateskt.TabIndex = 7;
            // 
            // dategiris
            // 
            this.dategiris.EditValue = null;
            this.dategiris.Location = new System.Drawing.Point(125, 197);
            this.dategiris.Name = "dategiris";
            this.dategiris.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dategiris.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dategiris.Size = new System.Drawing.Size(152, 20);
            this.dategiris.TabIndex = 8;
            // 
            // btnsertifika
            // 
            this.btnsertifika.Location = new System.Drawing.Point(125, 227);
            this.btnsertifika.Name = "btnsertifika";
            this.btnsertifika.Size = new System.Drawing.Size(152, 23);
            this.btnsertifika.TabIndex = 9;
            this.btnsertifika.Text = "Sertifika Seç";
            this.btnsertifika.Click += new System.EventHandler(this.btnsertifika_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(89, 51);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(26, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(125, 48);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(152, 20);
            this.combo_birim.TabIndex = 2;
            this.combo_birim.SelectedIndexChanged += new System.EventHandler(this.combo_birim_SelectedIndexChanged);
            // 
            // StokEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 331);
            this.Controls.Add(this.btnsertifika);
            this.Controls.Add(this.dategiris);
            this.Controls.Add(this.dateskt);
            this.Controls.Add(this.txtbirim);
            this.Controls.Add(this.txtmiktar);
            this.Controls.Add(this.txtlot);
            this.Controls.Add(this.txtmarka);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.combokod);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "StokEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Ekle";
            this.Load += new System.EventHandler(this.StokEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combokod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.TextEdit txtmarka;
        private DevExpress.XtraEditors.TextEdit txtlot;
        private DevExpress.XtraEditors.TextEdit txtmiktar;
        private DevExpress.XtraEditors.TextEdit txtbirim;
        private DevExpress.XtraEditors.DateEdit dateskt;
        private DevExpress.XtraEditors.DateEdit dategiris;
        private DevExpress.XtraEditors.SimpleButton btnsertifika;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
    }
}