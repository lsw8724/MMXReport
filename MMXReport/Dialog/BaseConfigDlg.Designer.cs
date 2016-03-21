namespace MMXReport.Dialog
{
    partial class BaseConfigDlg
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
            this.Btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Btn_Close.Location = new System.Drawing.Point(0, 340);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(453, 23);
            this.Btn_Close.TabIndex = 0;
            this.Btn_Close.Text = "닫기";
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // BaseConfigDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 363);
            this.Controls.Add(this.Btn_Close);
            this.LookAndFeel.SkinName = "Office 2013";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "BaseConfigDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BaseConfigDlg";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Btn_Close;
    }
}