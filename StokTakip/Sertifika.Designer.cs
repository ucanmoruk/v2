namespace StokTakip
{
    partial class Sertifika
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sertifika));
            this.dateskt = new DevExpress.XtraEditors.DateEdit();
            this.txtlot = new DevExpress.XtraEditors.TextEdit();
            this.txtmarka = new DevExpress.XtraEditors.TextEdit();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.combokod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnsertifika = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateskt
            // 
            this.dateskt.EditValue = null;
            this.dateskt.Location = new System.Drawing.Point(171, 174);
            this.dateskt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateskt.Name = "dateskt";
            this.dateskt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateskt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateskt.Size = new System.Drawing.Size(203, 22);
            this.dateskt.TabIndex = 5;
            // 
            // txtlot
            // 
            this.txtlot.Location = new System.Drawing.Point(171, 137);
            this.txtlot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtlot.Name = "txtlot";
            this.txtlot.Size = new System.Drawing.Size(203, 22);
            this.txtlot.TabIndex = 4;
            // 
            // txtmarka
            // 
            this.txtmarka.Location = new System.Drawing.Point(171, 100);
            this.txtmarka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmarka.Name = "txtmarka";
            this.txtmarka.Size = new System.Drawing.Size(203, 22);
            this.txtmarka.TabIndex = 3;
            // 
            // btnadd
            // 
            this.btnadd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadd.Appearance.Options.UseFont = true;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnadd.ImageOptions.ImageToTextIndent = 10;
            this.btnadd.Location = new System.Drawing.Point(171, 258);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(203, 42);
            this.btnadd.TabIndex = 7;
            this.btnadd.Text = "Sertifika Ekle";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // combokod
            // 
            this.combokod.Location = new System.Drawing.Point(171, 31);
            this.combokod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combokod.Name = "combokod";
            this.combokod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combokod.Size = new System.Drawing.Size(203, 22);
            this.combokod.TabIndex = 1;
            this.combokod.SelectedIndexChanged += new System.EventHandler(this.combokod_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(40, 178);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(116, 16);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Son Kullanım Tarihi:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(116, 141);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(41, 16);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Lot No:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(119, 104);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 16);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Marka:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(93, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Stok Kodu:";
            // 
            // btnsertifika
            // 
            this.btnsertifika.Location = new System.Drawing.Point(171, 211);
            this.btnsertifika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsertifika.Name = "btnsertifika";
            this.btnsertifika.Size = new System.Drawing.Size(203, 28);
            this.btnsertifika.TabIndex = 6;
            this.btnsertifika.Text = "Sertifika Seç";
            this.btnsertifika.Click += new System.EventHandler(this.btnsertifika_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(68, 217);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(86, 16);
            this.labelControl7.TabIndex = 17;
            this.labelControl7.Text = "Sertifika Yükle:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(123, 68);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 16);
            this.labelControl4.TabIndex = 16;
            this.labelControl4.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(171, 65);
            this.combo_birim.Margin = new System.Windows.Forms.Padding(4);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(203, 22);
            this.combo_birim.TabIndex = 2;
            this.combo_birim.SelectedIndexChanged += new System.EventHandler(this.combokod_SelectedIndexChanged);
            // 
            // Sertifika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 341);
            this.Controls.Add(this.btnsertifika);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.dateskt);
            this.Controls.Add(this.txtlot);
            this.Controls.Add(this.txtmarka);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.combokod);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Sertifika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sertifika";
            this.Load += new System.EventHandler(this.Sertifika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateskt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtlot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmarka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.DateEdit dateskt;
        private DevExpress.XtraEditors.TextEdit txtlot;
        private DevExpress.XtraEditors.TextEdit txtmarka;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.ComboBoxEdit combokod;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnsertifika;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
    }
}