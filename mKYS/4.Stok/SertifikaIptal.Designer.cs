namespace mKYS
{
    partial class SertifikaIptal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SertifikaIptal));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.combo_marka = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnadd = new DevExpress.XtraEditors.SimpleButton();
            this.btn_iptal = new DevExpress.XtraEditors.SimpleButton();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Stok Kodu:";
            // 
            // combo_marka
            // 
            this.combo_marka.Location = new System.Drawing.Point(86, 57);
            this.combo_marka.Name = "combo_marka";
            this.combo_marka.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.combo_marka.Size = new System.Drawing.Size(174, 20);
            this.combo_marka.TabIndex = 2;
            this.combo_marka.SelectedIndexChanged += new System.EventHandler(this.combo_marka_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Sertifika:";
            // 
            // btnadd
            // 
            this.btnadd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnadd.Appearance.Options.UseFont = true;
            this.btnadd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnadd.ImageOptions.Image")));
            this.btnadd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnadd.ImageOptions.ImageToTextIndent = 10;
            this.btnadd.Location = new System.Drawing.Point(86, 94);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(174, 34);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Sertifika Görüntüle";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btn_iptal
            // 
            this.btn_iptal.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_iptal.Appearance.Options.UseFont = true;
            this.btn_iptal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_iptal.ImageOptions.Image")));
            this.btn_iptal.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_iptal.ImageOptions.ImageToTextIndent = 10;
            this.btn_iptal.Location = new System.Drawing.Point(86, 143);
            this.btn_iptal.Name = "btn_iptal";
            this.btn_iptal.Size = new System.Drawing.Size(174, 34);
            this.btn_iptal.TabIndex = 4;
            this.btn_iptal.Text = "Sertifika İptal";
            this.btn_iptal.Click += new System.EventHandler(this.btn_iptal_Click);
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "Analiz seçiniz..";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(86, 22);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.gridLookUpEdit1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEdit1.Properties.NullText = "Stok seçiniz..";
            this.gridLookUpEdit1.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Size = new System.Drawing.Size(174, 20);
            this.gridLookUpEdit1.TabIndex = 21;
            this.gridLookUpEdit1.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.gridLookUpEdit1_QueryPopUp);
            this.gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.gridLookUpEdit1_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // SertifikaIptal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 212);
            this.Controls.Add(this.gridLookUpEdit1);
            this.Controls.Add(this.btn_iptal);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.combo_marka);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "SertifikaIptal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sertifika İptal";
            this.Load += new System.EventHandler(this.SertifikaIptal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.combo_marka.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit combo_marka;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnadd;
        private DevExpress.XtraEditors.SimpleButton btn_iptal;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}