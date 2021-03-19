namespace Asteroids
{
    partial class FormGeral
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
            this.SuspendLayout();
            // 
            // FormGeral
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormGeral";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGeral_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGeral_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGeral_KeyUp);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += FormGeral_Load;
            this.ResumeLayout(false);

        }

        #endregion
    }
}

