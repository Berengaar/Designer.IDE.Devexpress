
namespace BdkAutomation.Scada.UI.HelperForms
{
    partial class TabPageNamePopUp
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
            this.lblTabPageWarn = new DevExpress.XtraEditors.LabelControl();
            this.btnTabPageName = new DevExpress.XtraEditors.SimpleButton();
            this.txtTabPageName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTabPageName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTabPageWarn
            // 
            this.lblTabPageWarn.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTabPageWarn.Appearance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTabPageWarn.Appearance.Options.UseFont = true;
            this.lblTabPageWarn.Appearance.Options.UseForeColor = true;
            this.lblTabPageWarn.Location = new System.Drawing.Point(12, 33);
            this.lblTabPageWarn.Name = "lblTabPageWarn";
            this.lblTabPageWarn.Size = new System.Drawing.Size(346, 22);
            this.lblTabPageWarn.TabIndex = 0;
            this.lblTabPageWarn.Text = "Lütfen sayfanızın görevi için bir isim giriniz :";
            // 
            // btnTabPageName
            // 
            this.btnTabPageName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTabPageName.Location = new System.Drawing.Point(0, 94);
            this.btnTabPageName.Name = "btnTabPageName";
            this.btnTabPageName.Size = new System.Drawing.Size(811, 44);
            this.btnTabPageName.TabIndex = 1;
            this.btnTabPageName.Text = "OK";
            this.btnTabPageName.Click += new System.EventHandler(this.btnTabPageName_Click);
            // 
            // txtTabPageName
            // 
            this.txtTabPageName.Location = new System.Drawing.Point(379, 35);
            this.txtTabPageName.Name = "txtTabPageName";
            this.txtTabPageName.Size = new System.Drawing.Size(420, 22);
            this.txtTabPageName.TabIndex = 2;
            // 
            // TabPageNamePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(811, 138);
            this.Controls.Add(this.txtTabPageName);
            this.Controls.Add(this.btnTabPageName);
            this.Controls.Add(this.lblTabPageWarn);
            this.Name = "TabPageNamePopUp";
            this.Text = "Mission Name";
            ((System.ComponentModel.ISupportInitialize)(this.txtTabPageName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTabPageWarn;
        private DevExpress.XtraEditors.SimpleButton btnTabPageName;
        private DevExpress.XtraEditors.TextEdit txtTabPageName;
    }
}