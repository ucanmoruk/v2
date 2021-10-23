namespace mKYS.Talep
{
    partial class TalepMaliyet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalepMaliyet));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEdit2 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_tl = new DevExpress.XtraEditors.TextEdit();
            this.txt_dolar = new DevExpress.XtraEditors.TextEdit();
            this.txt_euro = new DevExpress.XtraEditors.TextEdit();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.gridLookUpEdit3 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txt_tutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_stok = new DevExpress.XtraEditors.TextEdit();
            this.txt_birim = new DevExpress.XtraEditors.TextEdit();
            this.combo_no = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_euro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_stok.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_no.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Talep No / Talep:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(82, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Firma:";
            // 
            // gridLookUpEdit2
            // 
            this.gridLookUpEdit2.Location = new System.Drawing.Point(119, 46);
            this.gridLookUpEdit2.Name = "gridLookUpEdit2";
            this.gridLookUpEdit2.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.gridLookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.gridLookUpEdit2.Properties.NullText = "Firma seçiniz..";
            this.gridLookUpEdit2.Properties.PopupView = this.gridView1;
            this.gridLookUpEdit2.Size = new System.Drawing.Size(215, 20);
            this.gridLookUpEdit2.TabIndex = 3;
            this.gridLookUpEdit2.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit2_QueryPopUp);
            this.gridLookUpEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit2_ButtonClick);
            this.gridLookUpEdit2.EditValueChanged += new System.EventHandler(this.gridLookUpEdit2_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(31, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(81, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Teklif Birim Fiyat:";
            // 
            // txt_tl
            // 
            this.txt_tl.EditValue = "₺";
            this.txt_tl.Location = new System.Drawing.Point(119, 74);
            this.txt_tl.Name = "txt_tl";
            this.txt_tl.Size = new System.Drawing.Size(66, 20);
            this.txt_tl.TabIndex = 4;
            this.txt_tl.Enter += new System.EventHandler(this.txt_tl_Enter);
            this.txt_tl.Leave += new System.EventHandler(this.txt_tl_Leave);
            // 
            // txt_dolar
            // 
            this.txt_dolar.EditValue = "$";
            this.txt_dolar.Location = new System.Drawing.Point(191, 74);
            this.txt_dolar.Name = "txt_dolar";
            this.txt_dolar.Size = new System.Drawing.Size(68, 20);
            this.txt_dolar.TabIndex = 5;
            this.txt_dolar.Enter += new System.EventHandler(this.txt_dolar_Enter);
            this.txt_dolar.Leave += new System.EventHandler(this.txt_dolar_Leave);
            // 
            // txt_euro
            // 
            this.txt_euro.EditValue = "€";
            this.txt_euro.Location = new System.Drawing.Point(265, 74);
            this.txt_euro.Name = "txt_euro";
            this.txt_euro.Size = new System.Drawing.Size(69, 20);
            this.txt_euro.TabIndex = 6;
            this.txt_euro.Enter += new System.EventHandler(this.txt_euro_Enter);
            this.txt_euro.Leave += new System.EventHandler(this.txt_euro_Leave);
            // 
            // btn_save
            // 
            this.btn_save.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_save.ImageOptions.ImageToTextIndent = 15;
            this.btn_save.Location = new System.Drawing.Point(119, 173);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(215, 44);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Kaydet";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 139);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(99, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Fatura Tarih / Tutar:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(119, 136);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(97, 20);
            this.dateEdit1.TabIndex = 9;
            // 
            // gridLookUpEdit3
            // 
            this.gridLookUpEdit3.Location = new System.Drawing.Point(191, 19);
            this.gridLookUpEdit3.Name = "gridLookUpEdit3";
            this.gridLookUpEdit3.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridLookUpEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.gridLookUpEdit3.Properties.NullText = "Talep Adı";
            this.gridLookUpEdit3.Properties.PopupView = this.gridView2;
            this.gridLookUpEdit3.Size = new System.Drawing.Size(143, 20);
            this.gridLookUpEdit3.TabIndex = 2;
            this.gridLookUpEdit3.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit3_QueryPopUp);
            this.gridLookUpEdit3.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit3_ButtonClick);
            this.gridLookUpEdit3.EditValueChanged += new System.EventHandler(this.gridLookUpEdit3_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // txt_tutar
            // 
            this.txt_tutar.EditValue = "₺ (KDV Hariç)";
            this.txt_tutar.Location = new System.Drawing.Point(222, 136);
            this.txt_tutar.Name = "txt_tutar";
            this.txt_tutar.Size = new System.Drawing.Size(112, 20);
            this.txt_tutar.TabIndex = 10;
            this.txt_tutar.Enter += new System.EventHandler(this.txt_tutar_Enter);
            this.txt_tutar.Leave += new System.EventHandler(this.txt_tutar_Leave);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Satın Alım Miktarı:";
            // 
            // txt_stok
            // 
            this.txt_stok.Location = new System.Drawing.Point(119, 105);
            this.txt_stok.Name = "txt_stok";
            this.txt_stok.Size = new System.Drawing.Size(97, 20);
            this.txt_stok.TabIndex = 7;
            // 
            // txt_birim
            // 
            this.txt_birim.Enabled = false;
            this.txt_birim.Location = new System.Drawing.Point(222, 105);
            this.txt_birim.Name = "txt_birim";
            this.txt_birim.Size = new System.Drawing.Size(112, 20);
            this.txt_birim.TabIndex = 8;
            // 
            // combo_no
            // 
            this.combo_no.Location = new System.Drawing.Point(119, 19);
            this.combo_no.Name = "combo_no";
            this.combo_no.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_no.Size = new System.Drawing.Size(66, 20);
            this.combo_no.TabIndex = 12;
            this.combo_no.EditValueChanged += new System.EventHandler(this.combo_no_EditValueChanged);
            // 
            // TalepMaliyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 231);
            this.Controls.Add(this.combo_no);
            this.Controls.Add(this.txt_birim);
            this.Controls.Add(this.txt_stok);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_euro);
            this.Controls.Add(this.txt_dolar);
            this.Controls.Add(this.txt_tutar);
            this.Controls.Add(this.txt_tl);
            this.Controls.Add(this.gridLookUpEdit2);
            this.Controls.Add(this.gridLookUpEdit3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Name = "TalepMaliyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talep Maliyet Ekleme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TalepMaliyet_FormClosed);
            this.Load += new System.EventHandler(this.CihazMaliyet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_dolar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_euro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_stok.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_birim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_no.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txt_tl;
        private DevExpress.XtraEditors.TextEdit txt_dolar;
        private DevExpress.XtraEditors.TextEdit txt_euro;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.TextEdit txt_tutar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txt_stok;
        private DevExpress.XtraEditors.TextEdit txt_birim;
        private DevExpress.XtraEditors.ComboBoxEdit combo_no;
    }
}