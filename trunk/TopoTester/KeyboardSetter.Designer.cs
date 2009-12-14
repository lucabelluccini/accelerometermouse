namespace GenericHid
{
    partial class KeyboardSetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardSetter));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gpbModifiers = new System.Windows.Forms.GroupBox();
            this.ckMod = new System.Windows.Forms.CheckedListBox();
            this.gpbK1 = new System.Windows.Forms.GroupBox();
            this.comboBox_TastoA = new System.Windows.Forms.ComboBox();
            this.gpbK2 = new System.Windows.Forms.GroupBox();
            this.comboBox_TastoB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbModifiers.SuspendLayout();
            this.gpbK1.SuspendLayout();
            this.gpbK2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(177, 201);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(263, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 20);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gpbModifiers
            // 
            this.gpbModifiers.Controls.Add(this.ckMod);
            this.gpbModifiers.Location = new System.Drawing.Point(16, 47);
            this.gpbModifiers.Name = "gpbModifiers";
            this.gpbModifiers.Size = new System.Drawing.Size(155, 174);
            this.gpbModifiers.TabIndex = 4;
            this.gpbModifiers.TabStop = false;
            this.gpbModifiers.Text = "Tasti speciali";
            // 
            // ckMod
            // 
            this.ckMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ckMod.FormattingEnabled = true;
            this.ckMod.Items.AddRange(new object[] {
            "LEFT CTRL",
            "LEFT SHIFT",
            "LEFT ALT",
            "LEFT WIN",
            "RIGHT CTRL",
            "RIGHT SHIFT",
            "RIGHT ALT",
            "RIGHT WIN"});
            this.ckMod.Location = new System.Drawing.Point(6, 33);
            this.ckMod.Name = "ckMod";
            this.ckMod.Size = new System.Drawing.Size(143, 124);
            this.ckMod.TabIndex = 0;
            this.ckMod.SelectedIndexChanged += new System.EventHandler(this.ckMod_SelectedIndexChanged);
            this.ckMod.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ckMod_ItemCheck);
            // 
            // gpbK1
            // 
            this.gpbK1.BackColor = System.Drawing.SystemColors.Control;
            this.gpbK1.Controls.Add(this.comboBox_TastoA);
            this.gpbK1.Location = new System.Drawing.Point(177, 47);
            this.gpbK1.Name = "gpbK1";
            this.gpbK1.Size = new System.Drawing.Size(168, 73);
            this.gpbK1.TabIndex = 4;
            this.gpbK1.TabStop = false;
            this.gpbK1.Text = "Tasto A";
            // 
            // comboBox_TastoA
            // 
            this.comboBox_TastoA.AutoCompleteCustomSource.AddRange(new string[] {
            "Keyboard a",
            "Keyboard b",
            "Keyboard c",
            "Keyboard d",
            "Keyboard e",
            "Keyboard f",
            "Keyboard g",
            "Keyboard h",
            "Keyboard i",
            "Keyboard j",
            "Keyboard k",
            "Keyboard l",
            "Keyboard m",
            "Keyboard n",
            "Keyboard o",
            "Keyboard p",
            "Keyboard q",
            "Keyboard r",
            "Keyboard s",
            "Keyboard t",
            "Keyboard u",
            "Keyboard v",
            "Keyboard w",
            "Keyboard x",
            "Keyboard y",
            "Keyboard z",
            "Keyboard 1",
            "Keyboard 2",
            "Keyboard 3",
            "Keyboard 4",
            "Keyboard 5",
            "Keyboard 6",
            "Keyboard 7",
            "Keyboard 8",
            "Keyboard 9",
            "Keyboard 0",
            "Keyboard Return (ENTER)",
            "Keyboard ESCAPE",
            "Keyboard DELETE (Backspace)",
            "Keyboard Tab",
            "Keyboard Spacebar",
            "Keyboard -",
            "Keyboard =",
            "Keyboard [",
            "Keyboard ]",
            "Keyboard \\",
            "Keyboard ;",
            "Keyboard ‘",
            "Keyboard \'",
            "Keyboard ,",
            "Keyboard .",
            "Keyboard /",
            "Keyboard Caps Lock",
            "Keyboard F1",
            "Keyboard F2",
            "Keyboard F3",
            "Keyboard F4",
            "Keyboard F5",
            "Keyboard F6",
            "Keyboard F7",
            "Keyboard F8",
            "Keyboard F9",
            "Keyboard F10",
            "Keyboard F11",
            "Keyboard F12",
            "Keyboard PrintScreen",
            "Keyboard Scroll Lock",
            "Keyboard Pause",
            "Keyboard Insert",
            "Keyboard Home",
            "Keyboard PageUp",
            "Keyboard Delete Forward",
            "Keyboard End",
            "Keyboard PageDown",
            "Keyboard RightArrow",
            "Keyboard LeftArrow",
            "Keyboard DownArrow",
            "Keyboard UpArrow",
            "Keypad /",
            "Keypad *",
            "Keypad -",
            "Keypad + ",
            "Keypad ENTER",
            "Keypad 1",
            "Keypad 2",
            "Keypad 3",
            "Keypad 4",
            "Keypad 5",
            "Keypad 6",
            "Keypad 7",
            "Keypad 8",
            "Keypad 9",
            "Keypad 0",
            "Keypad ."});
            this.comboBox_TastoA.FormattingEnabled = true;
            this.comboBox_TastoA.Items.AddRange(new object[] {
            "Non Impostato",
            "Keyboard a",
            "Keyboard b",
            "Keyboard c",
            "Keyboard d",
            "Keyboard e",
            "Keyboard f",
            "Keyboard g",
            "Keyboard h",
            "Keyboard i",
            "Keyboard j",
            "Keyboard k",
            "Keyboard l",
            "Keyboard m",
            "Keyboard n",
            "Keyboard o",
            "Keyboard p",
            "Keyboard q",
            "Keyboard r",
            "Keyboard s",
            "Keyboard t",
            "Keyboard u",
            "Keyboard v",
            "Keyboard w",
            "Keyboard x",
            "Keyboard y",
            "Keyboard z",
            "Keyboard 1",
            "Keyboard 2",
            "Keyboard 3",
            "Keyboard 4",
            "Keyboard 5",
            "Keyboard 6",
            "Keyboard 7",
            "Keyboard 8",
            "Keyboard 9",
            "Keyboard 0",
            "Keyboard Return (ENTER)",
            "Keyboard ESCAPE",
            "Keyboard DELETE (Backspace)",
            "Keyboard Tab",
            "Keyboard Spacebar",
            "Keyboard -",
            "Keyboard =",
            "Keyboard [",
            "Keyboard ]",
            "Keyboard \\",
            "Keyboard ;",
            "Keyboard ‘",
            "Keyboard \'",
            "Keyboard ,",
            "Keyboard .",
            "Keyboard /",
            "Keyboard Caps Lock",
            "Keyboard F1",
            "Keyboard F2",
            "Keyboard F3",
            "Keyboard F4",
            "Keyboard F5",
            "Keyboard F6",
            "Keyboard F7",
            "Keyboard F8",
            "Keyboard F9",
            "Keyboard F10",
            "Keyboard F11",
            "Keyboard F12",
            "Keyboard PrintScreen",
            "Keyboard Scroll Lock",
            "Keyboard Pause",
            "Keyboard Insert",
            "Keyboard Home",
            "Keyboard PageUp",
            "Keyboard Delete Forward",
            "Keyboard End",
            "Keyboard PageDown",
            "Keyboard RightArrow",
            "Keyboard LeftArrow",
            "Keyboard DownArrow",
            "Keyboard UpArrow",
            "Keypad /",
            "Keypad *",
            "Keypad -",
            "Keypad + ",
            "Keypad ENTER",
            "Keypad 1",
            "Keypad 2",
            "Keypad 3",
            "Keypad 4",
            "Keypad 5",
            "Keypad 6",
            "Keypad 7",
            "Keypad 8",
            "Keypad 9",
            "Keypad 0",
            "Keypad ."});
            this.comboBox_TastoA.Location = new System.Drawing.Point(6, 22);
            this.comboBox_TastoA.Name = "comboBox_TastoA";
            this.comboBox_TastoA.Size = new System.Drawing.Size(156, 21);
            this.comboBox_TastoA.TabIndex = 6;
            this.comboBox_TastoA.SelectedIndexChanged += new System.EventHandler(this.comboBox_TastoA_SelectedIndexChanged);
            // 
            // gpbK2
            // 
            this.gpbK2.BackColor = System.Drawing.SystemColors.Control;
            this.gpbK2.Controls.Add(this.comboBox_TastoB);
            this.gpbK2.Location = new System.Drawing.Point(178, 126);
            this.gpbK2.Name = "gpbK2";
            this.gpbK2.Size = new System.Drawing.Size(167, 69);
            this.gpbK2.TabIndex = 6;
            this.gpbK2.TabStop = false;
            this.gpbK2.Text = "Tasto B";
            // 
            // comboBox_TastoB
            // 
            this.comboBox_TastoB.AutoCompleteCustomSource.AddRange(new string[] {
            "Keyboard a",
            "Keyboard b",
            "Keyboard c",
            "Keyboard d",
            "Keyboard e",
            "Keyboard f",
            "Keyboard g",
            "Keyboard h",
            "Keyboard i",
            "Keyboard j",
            "Keyboard k",
            "Keyboard l",
            "Keyboard m",
            "Keyboard n",
            "Keyboard o",
            "Keyboard p",
            "Keyboard q",
            "Keyboard r",
            "Keyboard s",
            "Keyboard t",
            "Keyboard u",
            "Keyboard v",
            "Keyboard w",
            "Keyboard x",
            "Keyboard y",
            "Keyboard z",
            "Keyboard 1",
            "Keyboard 2",
            "Keyboard 3",
            "Keyboard 4",
            "Keyboard 5",
            "Keyboard 6",
            "Keyboard 7",
            "Keyboard 8",
            "Keyboard 9",
            "Keyboard 0",
            "Keyboard Return (ENTER)",
            "Keyboard ESCAPE",
            "Keyboard DELETE (Backspace)",
            "Keyboard Tab",
            "Keyboard Spacebar",
            "Keyboard -",
            "Keyboard =",
            "Keyboard [",
            "Keyboard ]",
            "Keyboard \\",
            "Keyboard ;",
            "Keyboard ‘",
            "Keyboard \'",
            "Keyboard ,",
            "Keyboard .",
            "Keyboard /",
            "Keyboard Caps Lock",
            "Keyboard F1",
            "Keyboard F2",
            "Keyboard F3",
            "Keyboard F4",
            "Keyboard F5",
            "Keyboard F6",
            "Keyboard F7",
            "Keyboard F8",
            "Keyboard F9",
            "Keyboard F10",
            "Keyboard F11",
            "Keyboard F12",
            "Keyboard PrintScreen",
            "Keyboard Scroll Lock",
            "Keyboard Pause",
            "Keyboard Insert",
            "Keyboard Home",
            "Keyboard PageUp",
            "Keyboard Delete Forward",
            "Keyboard End",
            "Keyboard PageDown",
            "Keyboard RightArrow",
            "Keyboard LeftArrow",
            "Keyboard DownArrow",
            "Keyboard UpArrow",
            "Keypad /",
            "Keypad *",
            "Keypad -",
            "Keypad + ",
            "Keypad ENTER",
            "Keypad 1",
            "Keypad 2",
            "Keypad 3",
            "Keypad 4",
            "Keypad 5",
            "Keypad 6",
            "Keypad 7",
            "Keypad 8",
            "Keypad 9",
            "Keypad 0",
            "Keypad ."});
            this.comboBox_TastoB.FormattingEnabled = true;
            this.comboBox_TastoB.Items.AddRange(new object[] {
            "Non Impostato",
            "Keyboard a",
            "Keyboard b",
            "Keyboard c",
            "Keyboard d",
            "Keyboard e",
            "Keyboard f",
            "Keyboard g",
            "Keyboard h",
            "Keyboard i",
            "Keyboard j",
            "Keyboard k",
            "Keyboard l",
            "Keyboard m",
            "Keyboard n",
            "Keyboard o",
            "Keyboard p",
            "Keyboard q",
            "Keyboard r",
            "Keyboard s",
            "Keyboard t",
            "Keyboard u",
            "Keyboard v",
            "Keyboard w",
            "Keyboard x",
            "Keyboard y",
            "Keyboard z",
            "Keyboard 1",
            "Keyboard 2",
            "Keyboard 3",
            "Keyboard 4",
            "Keyboard 5",
            "Keyboard 6",
            "Keyboard 7",
            "Keyboard 8",
            "Keyboard 9",
            "Keyboard 0",
            "Keyboard Return (ENTER)",
            "Keyboard ESCAPE",
            "Keyboard DELETE (Backspace)",
            "Keyboard Tab",
            "Keyboard Spacebar",
            "Keyboard -",
            "Keyboard =",
            "Keyboard [",
            "Keyboard ]",
            "Keyboard \\",
            "Keyboard ;",
            "Keyboard ‘",
            "Keyboard \'",
            "Keyboard ,",
            "Keyboard .",
            "Keyboard /",
            "Keyboard Caps Lock",
            "Keyboard F1",
            "Keyboard F2",
            "Keyboard F3",
            "Keyboard F4",
            "Keyboard F5",
            "Keyboard F6",
            "Keyboard F7",
            "Keyboard F8",
            "Keyboard F9",
            "Keyboard F10",
            "Keyboard F11",
            "Keyboard F12",
            "Keyboard PrintScreen",
            "Keyboard Scroll Lock",
            "Keyboard Pause",
            "Keyboard Insert",
            "Keyboard Home",
            "Keyboard PageUp",
            "Keyboard Delete Forward",
            "Keyboard End",
            "Keyboard PageDown",
            "Keyboard RightArrow",
            "Keyboard LeftArrow",
            "Keyboard DownArrow",
            "Keyboard UpArrow",
            "Keypad /",
            "Keypad *",
            "Keypad -",
            "Keypad + ",
            "Keypad ENTER",
            "Keypad 1",
            "Keypad 2",
            "Keypad 3",
            "Keypad 4",
            "Keypad 5",
            "Keypad 6",
            "Keypad 7",
            "Keypad 8",
            "Keypad 9",
            "Keypad 0",
            "Keypad ."});
            this.comboBox_TastoB.Location = new System.Drawing.Point(6, 19);
            this.comboBox_TastoB.Name = "comboBox_TastoB";
            this.comboBox_TastoB.Size = new System.Drawing.Size(155, 21);
            this.comboBox_TastoB.TabIndex = 7;
            this.comboBox_TastoB.SelectedIndexChanged += new System.EventHandler(this.comboBox_TastoB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Settare uno o più tasti come modificatori e completare la combinazione con uno o " +
                "due tasti standard.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KeyboardSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 227);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpbK2);
            this.Controls.Add(this.gpbK1);
            this.Controls.Add(this.gpbModifiers);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(366, 255);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(366, 255);
            this.Name = "KeyboardSetter";
            this.Text = "Configurazione della funzione Shake";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.KeyboardSetter_Load);
            this.gpbModifiers.ResumeLayout(false);
            this.gpbK1.ResumeLayout(false);
            this.gpbK2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gpbModifiers;
        private System.Windows.Forms.CheckedListBox ckMod;
        private System.Windows.Forms.GroupBox gpbK1;
        private System.Windows.Forms.GroupBox gpbK2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_TastoA;
        private System.Windows.Forms.ComboBox comboBox_TastoB;
    }
}