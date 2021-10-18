namespace mKYS.Duyuru
{
    partial class Duyuru
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
            this.txt_mesaj = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_mesaj.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_mesaj
            // 
            this.txt_mesaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_mesaj.Location = new System.Drawing.Point(0, 0);
            this.txt_mesaj.Name = "txt_mesaj";
            this.txt_mesaj.Properties.Appearance.Options.UseTextOptions = true;
            this.txt_mesaj.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.txt_mesaj.Properties.Padding = new System.Windows.Forms.Padding(10, 25, 10, 10);
            this.txt_mesaj.Size = new System.Drawing.Size(653, 162);
            this.txt_mesaj.TabIndex = 0;
            // 
            // Duyuru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 162);
            this.Controls.Add(this.txt_mesaj);
            this.Name = "Duyuru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyuru";
            this.Load += new System.EventHandler(this.Duyuru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_mesaj.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txt_mesaj;
    }
}