namespace mROOT._7.Muhasebe
{
    partial class IslemEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IslemEkle));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ttutar = new DevExpress.XtraEditors.TextEdit();
            this.ctur = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ckategori = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tkdv = new DevExpress.XtraEditors.TextEdit();
            this.ttoplam = new DevExpress.XtraEditors.TextEdit();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tfatura = new DevExpress.XtraEditors.TextEdit();
            this.tbanka = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.taciklama = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.codeme = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ttutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctur.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckategori.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkdv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttoplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tfatura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbanka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeme.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(64, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tür / Kategori:";
            // 
            // ttutar
            // 
            this.ttutar.Location = new System.Drawing.Point(138, 155);
            this.ttutar.Name = "ttutar";
            this.ttutar.Size = new System.Drawing.Size(94, 20);
            this.ttutar.TabIndex = 8;
            this.ttutar.TextChanged += new System.EventHandler(this.ttutar_TextChanged);
            this.ttutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttutar_KeyPress);
            // 
            // ctur
            // 
            this.ctur.Location = new System.Drawing.Point(140, 26);
            this.ctur.Name = "ctur";
            this.ctur.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ctur.Properties.Items.AddRange(new object[] {
            "Gelir",
            "Gider"});
            this.ctur.Size = new System.Drawing.Size(136, 20);
            this.ctur.TabIndex = 1;
            // 
            // ckategori
            // 
            this.ckategori.Location = new System.Drawing.Point(282, 26);
            this.ckategori.Name = "ckategori";
            this.ckategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ckategori.Properties.Items.AddRange(new object[] {
            "Aidat",
            "Demirbaş",
            "Diğer",
            "Fatura",
            "Kırtasiye",
            "Kira",
            "Komisyon",
            "Kredi Kartı",
            "Maaş",
            "Mutfak",
            "Satın Alma",
            "Sermaye",
            "SGK",
            "Test Satışı",
            "Teşvik",
            "Ürün Satışı",
            "Vergi",
            "Yakıt",
            "Ekstra",
            "Hizmet"});
            this.ckategori.Size = new System.Drawing.Size(148, 20);
            this.ckategori.TabIndex = 2;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(140, 57);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(136, 20);
            this.dateEdit1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(109, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Fatura / Ödeme Tarihi:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(29, 159);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(103, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Tutar / KDV / Toplam:";
            // 
            // tkdv
            // 
            this.tkdv.Location = new System.Drawing.Point(238, 155);
            this.tkdv.Name = "tkdv";
            this.tkdv.Size = new System.Drawing.Size(94, 20);
            this.tkdv.TabIndex = 9;
            this.tkdv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tkdv_KeyPress);
            // 
            // ttoplam
            // 
            this.ttoplam.Location = new System.Drawing.Point(338, 155);
            this.ttoplam.Name = "ttoplam";
            this.ttoplam.Size = new System.Drawing.Size(92, 20);
            this.ttoplam.TabIndex = 10;
            this.ttoplam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ttoplam_KeyPress);
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "Firma Seçiniz..";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(138, 91);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.NullText = "Firma seçiniz..";
            this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(292, 20);
            this.gridLookUpEdit1.TabIndex = 5;
            this.gridLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_QueryPopUp);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(100, 94);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(30, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Firma:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(41, 124);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(91, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Fatura No / Banka:";
            // 
            // tfatura
            // 
            this.tfatura.Location = new System.Drawing.Point(138, 121);
            this.tfatura.Name = "tfatura";
            this.tfatura.Size = new System.Drawing.Size(138, 20);
            this.tfatura.TabIndex = 6;
            // 
            // tbanka
            // 
            this.tbanka.Location = new System.Drawing.Point(282, 121);
            this.tbanka.Name = "tbanka";
            this.tbanka.Size = new System.Drawing.Size(148, 20);
            this.tbanka.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(85, 195);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Açıklama:";
            // 
            // taciklama
            // 
            this.taciklama.Location = new System.Drawing.Point(138, 192);
            this.taciklama.Name = "taciklama";
            this.taciklama.Size = new System.Drawing.Size(292, 20);
            this.taciklama.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(51, 230);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(78, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Ödeme Durumu:";
            // 
            // codeme
            // 
            this.codeme.Location = new System.Drawing.Point(138, 227);
            this.codeme.Name = "codeme";
            this.codeme.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.codeme.Properties.Items.AddRange(new object[] {
            "Ödeme Bekliyor",
            "Ödendi",
            "Fatura Kesilecek"});
            this.codeme.Size = new System.Drawing.Size(292, 20);
            this.codeme.TabIndex = 12;
            // 
            // btn_save
            // 
            this.btn_save.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_save.Appearance.Options.UseFont = true;
            this.btn_save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.ImageOptions.Image")));
            this.btn_save.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_save.ImageOptions.ImageToTextIndent = 15;
            this.btn_save.Location = new System.Drawing.Point(140, 269);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(292, 48);
            this.btn_save.TabIndex = 13;
            this.btn_save.Text = "Kaydet";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(282, 57);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(147, 20);
            this.dateEdit2.TabIndex = 4;
            // 
            // IslemEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 352);
            this.Controls.Add(this.dateEdit2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.gridLookUpEdit1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.ckategori);
            this.Controls.Add(this.codeme);
            this.Controls.Add(this.ctur);
            this.Controls.Add(this.ttoplam);
            this.Controls.Add(this.tbanka);
            this.Controls.Add(this.tfatura);
            this.Controls.Add(this.tkdv);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.taciklama);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.ttutar);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "IslemEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İşlem Ekleme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IslemEkle_FormClosing);
            this.Load += new System.EventHandler(this.IslemEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ttutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctur.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckategori.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkdv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttoplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tfatura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbanka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeme.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ttutar;
        private DevExpress.XtraEditors.ComboBoxEdit ctur;
        private DevExpress.XtraEditors.ComboBoxEdit ckategori;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tkdv;
        private DevExpress.XtraEditors.TextEdit ttoplam;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit tfatura;
        private DevExpress.XtraEditors.TextEdit tbanka;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit taciklama;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit codeme;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
    }
}