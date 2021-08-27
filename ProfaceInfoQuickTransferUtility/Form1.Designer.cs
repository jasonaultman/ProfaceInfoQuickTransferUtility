
namespace ProfaceInfoQuickTransferUtility
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbProgress.ForeColor = System.Drawing.Color.LawnGreen;
            this.pbProgress.Location = new System.Drawing.Point(12, 516);
            this.pbProgress.Maximum = 1000;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(430, 29);
            this.pbProgress.TabIndex = 0;
            this.pbProgress.Visible = false;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(12, 34);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(430, 309);
            this.rtbConsole.TabIndex = 1;
            this.rtbConsole.Text = "";
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoadSettings.Location = new System.Drawing.Point(12, 349);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(212, 136);
            this.btnLoadSettings.TabIndex = 2;
            this.btnLoadSettings.Text = "&Load From PLCs";
            this.btnLoadSettings.UseVisualStyleBackColor = false;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(230, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 136);
            this.button1.TabIndex = 3;
            this.button1.Text = "&Send To PLCs";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 577);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.pbProgress);
            this.Name = "FrmMain";
            this.Text = "Proface Info Quick Transfer Utility v1.0.0";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.Button button1;
    }
}

