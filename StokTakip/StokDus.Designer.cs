﻿namespace StokTakip
{
    partial class StokDus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokDus));
            this.dategiris = new DevExpress.XtraEditors.DateEdit();
            this.txtbirim = new DevExpress.XtraEditors.TextEdit();
            this.txtmiktar = new DevExpress.XtraEditors.TextEdit();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.combokod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.combo_marka = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.combo_birim = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dategiris
            // 
            this.dategiris.EditValue = null;
            this.dategiris.Location = new System.Drawing.Point(160, 167);
            this.dategiris.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dategiris.Name = "dategiris";
            this.dategiris.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dategiris.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dategiris.Size = new System.Drawing.Size(203, 22);
            this.dategiris.TabIndex = 6;
            // 
            // txtbirim
            // 
            this.txtbirim.Enabled = false;
            this.txtbirim.Location = new System.Drawing.Point(271, 130);
            this.txtbirim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbirim.Name = "txtbirim";
            this.txtbirim.Size = new System.Drawing.Size(92, 22);
            this.txtbirim.TabIndex = 5;
            // 
            // txtmiktar
            // 
            this.txtmiktar.Location = new System.Drawing.Point(160, 130);
            this.txtmiktar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtmiktar.Name = "txtmiktar";
            this.txtmiktar.Size = new System.Drawing.Size(103, 22);
            this.txtmiktar.TabIndex = 4;
            // 
            // btnadd
            // 
            this.btnadd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadd.Appearance.Options.UseFont = true;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnadd.ImageOptions.ImageToTextIndent = 10;
            this.btnadd.Location = new System.Drawing.Point(160, 207);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(203, 42);
            this.btnadd.TabIndex = 7;
            this.btnadd.Text = "Stok Düş";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // combokod
            // 
            this.combokod.Location = new System.Drawing.Point(160, 28);
            this.combokod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combokod.Name = "combokod";
            this.combokod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combokod.Size = new System.Drawing.Size(203, 22);
            this.combokod.TabIndex = 1;
            this.combokod.SelectedIndexChanged += new System.EventHandler(this.combokod_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(51, 170);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(93, 16);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Harcama Tarihi:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(72, 132);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 16);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Miktar/Birim:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(83, 96);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Marka/Lot:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(83, 30);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 16);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Stok Kodu:";
            // 
            // combo_marka
            // 
            this.combo_marka.Location = new System.Drawing.Point(160, 94);
            this.combo_marka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combo_marka.Name = "combo_marka";
            this.combo_marka.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_marka.Size = new System.Drawing.Size(203, 22);
            this.combo_marka.TabIndex = 3;
            this.combo_marka.SelectedIndexChanged += new System.EventHandler(this.combo_marka_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(111, 62);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Birim:";
            // 
            // combo_birim
            // 
            this.combo_birim.Location = new System.Drawing.Point(160, 59);
            this.combo_birim.Margin = new System.Windows.Forms.Padding(4);
            this.combo_birim.Name = "combo_birim";
            this.combo_birim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_birim.Size = new System.Drawing.Size(203, 22);
            this.combo_birim.TabIndex = 2;
            this.combo_birim.SelectedIndexChanged += new System.EventHandler(this.combokod_SelectedIndexChanged);
            // 
            // StokDus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 282);
            this.Controls.Add(this.dategiris);
            this.Controls.Add(this.txtbirim);
            this.Controls.Add(this.txtmiktar);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.combo_marka);
            this.Controls.Add(this.combo_birim);
            this.Controls.Add(this.combokod);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StokDus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Düş";
            this.Load += new System.EventHandler(this.StokDus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dategiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combokod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_birim.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.DateEdit dategiris;
        private DevExpress.XtraEditors.TextEdit txtbirim;
        private DevExpress.XtraEditors.TextEdit txtmiktar;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.ComboBoxEdit combokod;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_marka;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit combo_birim;
    }
}