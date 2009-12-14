namespace GenericHid
{
    partial class KeyboardSelector
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
            this.kcontrol = new KeyboardClassLibrary.Keyboardcontrol();
            this.SuspendLayout();
            // 
            // kcontrol
            // 
            this.kcontrol.AutoSize = true;
            this.kcontrol.KeyboardType = KeyboardClassLibrary.BoW.Standard;
            this.kcontrol.Location = new System.Drawing.Point(0, 1);
            this.kcontrol.Name = "kcontrol";
            this.kcontrol.Size = new System.Drawing.Size(607, 178);
            this.kcontrol.TabIndex = 0;
            this.kcontrol.Load += new System.EventHandler(this.kcontrol_Load);
            this.kcontrol.UserKeyPressed += new KeyboardClassLibrary.KeyboardDelegate(this.kcontrol_UserKeyPressed);
            // 
            // KeyboardSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(609, 179);
            this.Controls.Add(this.kcontrol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(615, 207);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 207);
            this.Name = "KeyboardSelector";
            this.Text = "Seleziona un tasto";
            this.Load += new System.EventHandler(this.KeyboardSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KeyboardClassLibrary.Keyboardcontrol kcontrol;
    }
}