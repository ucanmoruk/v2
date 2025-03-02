namespace mROOT.Numune
{
    partial class TopluEkleme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopluEkleme));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gproje = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gfirma = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_kontrol = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ac = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gproje.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.btn_kontrol);
            this.panelControl1.Controls.Add(this.btn_ac);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.gproje);
            this.panelControl1.Controls.Add(this.gfirma);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 106);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 106);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 344);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gproje
            // 
            this.gproje.Location = new System.Drawing.Point(86, 56);
            this.gproje.Name = "gproje";
            this.gproje.Properties.AutoHeight = false;
            this.gproje.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gproje.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gproje.Properties.NullText = "";
            this.gproje.Properties.PopupView = this.gridView8;
            this.gproje.Size = new System.Drawing.Size(280, 26);
            this.gproje.TabIndex = 10;
            this.gproje.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gproje_QueryPopUp);
            // 
            // gridView8
            // 
            this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView8.Name = "gridView8";
            this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView8.OptionsView.ShowGroupPanel = false;
            // 
            // gfirma
            // 
            this.gfirma.Location = new System.Drawing.Point(86, 20);
            this.gfirma.Name = "gfirma";
            this.gfirma.Properties.AutoHeight = false;
            this.gfirma.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gfirma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gfirma.Properties.NullText = "";
            this.gfirma.Properties.PopupView = this.gridView7;
            this.gfirma.Size = new System.Drawing.Size(280, 26);
            this.gfirma.TabIndex = 9;
            this.gfirma.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gfirma_QueryPopUp);
            // 
            // gridView7
            // 
            this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView7.Name = "gridView7";
            this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView7.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(24, 61);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(32, 14);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "Proje:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(24, 25);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Firma Adı:";
            // 
            // btn_kontrol
            // 
            this.btn_kontrol.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_kontrol.Appearance.Options.UseFont = true;
            this.btn_kontrol.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_kontrol.ImageOptions.Image")));
            this.btn_kontrol.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_kontrol.ImageOptions.ImageToTextIndent = 10;
            this.btn_kontrol.Location = new System.Drawing.Point(541, 25);
            this.btn_kontrol.Name = "btn_kontrol";
            this.btn_kontrol.Size = new System.Drawing.Size(112, 50);
            this.btn_kontrol.TabIndex = 13;
            this.btn_kontrol.Text = "Kaydet";
            this.btn_kontrol.Click += new System.EventHandler(this.btn_kontrol_Click);
            // 
            // btn_ac
            // 
            this.btn_ac.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_ac.Appearance.Options.UseFont = true;
            this.btn_ac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ac.ImageOptions.Image")));
            this.btn_ac.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_ac.ImageOptions.ImageToTextIndent = 10;
            this.btn_ac.Location = new System.Drawing.Point(390, 25);
            this.btn_ac.Name = "btn_ac";
            this.btn_ac.Size = new System.Drawing.Size(133, 50);
            this.btn_ac.TabIndex = 14;
            this.btn_ac.Text = "Dosya Seç";
            this.btn_ac.Click += new System.EventHandler(this.btn_ac_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton2.ImageOptions.ImageToTextIndent = 10;
            this.simpleButton2.Location = new System.Drawing.Point(668, 25);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(108, 50);
            this.simpleButton2.TabIndex = 15;
            this.simpleButton2.Text = "Temizle";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // TopluEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "TopluEkleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toplu Ürün Ekle";
            this.Load += new System.EventHandler(this.TopluEkleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gproje.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit gproje;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraEditors.GridLookUpEdit gfirma;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_kontrol;
        private DevExpress.XtraEditors.SimpleButton btn_ac;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}