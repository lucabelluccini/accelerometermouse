namespace GenericHid
{
    partial class Calibrazione
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calibrazione));
            this.tkbDx = new System.Windows.Forms.TrackBar();
            this.tkbDy = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnShake = new System.Windows.Forms.Button();
            this.auto_offset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_mirrorY = new System.Windows.Forms.CheckBox();
            this.cb_mirrorX = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblMy = new System.Windows.Forms.Label();
            this.txtMy = new System.Windows.Forms.TextBox();
            this.lblMx = new System.Windows.Forms.Label();
            this.txtMx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbAngolo = new System.Windows.Forms.GroupBox();
            this.txtRad = new System.Windows.Forms.TextBox();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbOffset = new System.Windows.Forms.GroupBox();
            this.lblDX = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblDY = new System.Windows.Forms.Label();
            this.angleSelector = new AngleAltitudeControls.AngleSelector();
            this.gpbScalamento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tkbScalamentoY = new System.Windows.Forms.TrackBar();
            this.tkbScalamentoX = new System.Windows.Forms.TrackBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAnteprima = new System.Windows.Forms.Button();
            this.btnScrivi = new System.Windows.Forms.Button();
            this.tttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CancelExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tkbDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbDy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gpbAngolo.SuspendLayout();
            this.gpbOffset.SuspendLayout();
            this.gpbScalamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbScalamentoY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbScalamentoX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tkbDx
            // 
            this.tkbDx.Location = new System.Drawing.Point(36, 168);
            this.tkbDx.Maximum = 200;
            this.tkbDx.Minimum = -200;
            this.tkbDx.Name = "tkbDx";
            this.tkbDx.Size = new System.Drawing.Size(146, 45);
            this.tkbDx.TabIndex = 0;
            this.tkbDx.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tttInfo.SetToolTip(this.tkbDx, "Regola l\'offset dell\'asse X");
            this.tkbDx.Scroll += new System.EventHandler(this.tkbDx_Scroll);
            // 
            // tkbDy
            // 
            this.tkbDy.Location = new System.Drawing.Point(6, 19);
            this.tkbDy.Maximum = 200;
            this.tkbDy.Minimum = -200;
            this.tkbDy.Name = "tkbDy";
            this.tkbDy.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbDy.Size = new System.Drawing.Size(45, 143);
            this.tkbDy.TabIndex = 1;
            this.tkbDy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tttInfo.SetToolTip(this.tkbDy, "Regola l\'offset dell\'asse Y");
            this.tkbDy.Scroll += new System.EventHandler(this.tkbDy_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.gpbAngolo);
            this.groupBox1.Controls.Add(this.gpbOffset);
            this.groupBox1.Controls.Add(this.angleSelector);
            this.groupBox1.Controls.Add(this.tkbDx);
            this.groupBox1.Controls.Add(this.tkbDy);
            this.groupBox1.Controls.Add(this.gpbScalamento);
            this.groupBox1.Location = new System.Drawing.Point(412, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 277);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impostazione Parametri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnShake);
            this.groupBox4.Controls.Add(this.auto_offset);
            this.groupBox4.Location = new System.Drawing.Point(198, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(92, 74);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(6, 42);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(80, 25);
            this.btnShake.TabIndex = 24;
            this.btnShake.Text = "Shake Key";
            this.tttInfo.SetToolTip(this.btnShake, "Assegna la combinazione di tasti eseguita al verificarsi dell\'evento Shake.");
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // auto_offset
            // 
            this.auto_offset.Location = new System.Drawing.Point(6, 13);
            this.auto_offset.Name = "auto_offset";
            this.auto_offset.Size = new System.Drawing.Size(80, 25);
            this.auto_offset.TabIndex = 23;
            this.auto_offset.Text = "Auto-Offset";
            this.tttInfo.SetToolTip(this.auto_offset, "Permette di impostare gli offset lasciando il mouse in una posizione arbitraria");
            this.auto_offset.UseVisualStyleBackColor = true;
            this.auto_offset.Click += new System.EventHandler(this.auto_offset_Click);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(198, 16);
            this.label2.MaximumSize = new System.Drawing.Size(100, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 67);
            this.label2.TabIndex = 22;
            this.label2.Text = "Puntare il mouse sui controlli per visualizzare l\'aiuto in linea";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_mirrorY);
            this.groupBox2.Controls.Add(this.cb_mirrorX);
            this.groupBox2.Location = new System.Drawing.Point(198, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 68);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mirroring";
            this.tttInfo.SetToolTip(this.groupBox2, "Imposta il mirroring");
            // 
            // cb_mirrorY
            // 
            this.cb_mirrorY.AutoSize = true;
            this.cb_mirrorY.Location = new System.Drawing.Point(10, 42);
            this.cb_mirrorY.Name = "cb_mirrorY";
            this.cb_mirrorY.Size = new System.Drawing.Size(81, 17);
            this.cb_mirrorY.TabIndex = 1;
            this.cb_mirrorY.Text = "Specchia Y";
            this.tttInfo.SetToolTip(this.cb_mirrorY, "Specchia l\'asse Y");
            this.cb_mirrorY.UseVisualStyleBackColor = true;
            // 
            // cb_mirrorX
            // 
            this.cb_mirrorX.AutoSize = true;
            this.cb_mirrorX.Location = new System.Drawing.Point(10, 19);
            this.cb_mirrorX.Name = "cb_mirrorX";
            this.cb_mirrorX.Size = new System.Drawing.Size(81, 17);
            this.cb_mirrorX.TabIndex = 0;
            this.cb_mirrorX.Text = "Specchia X";
            this.tttInfo.SetToolTip(this.cb_mirrorX, "Specchia l\'asse X");
            this.cb_mirrorX.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Asse X";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblMy);
            this.groupBox5.Controls.Add(this.txtMy);
            this.groupBox5.Controls.Add(this.lblMx);
            this.groupBox5.Controls.Add(this.txtMx);
            this.groupBox5.Location = new System.Drawing.Point(294, 197);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(117, 74);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            // 
            // lblMy
            // 
            this.lblMy.AutoSize = true;
            this.lblMy.Location = new System.Drawing.Point(5, 48);
            this.lblMy.Name = "lblMy";
            this.lblMy.Size = new System.Drawing.Size(40, 13);
            this.lblMy.TabIndex = 8;
            this.lblMy.Text = "Asse Y";
            // 
            // txtMy
            // 
            this.txtMy.Location = new System.Drawing.Point(55, 45);
            this.txtMy.Name = "txtMy";
            this.txtMy.ReadOnly = true;
            this.txtMy.Size = new System.Drawing.Size(56, 20);
            this.txtMy.TabIndex = 11;
            this.txtMy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMy.TextChanged += new System.EventHandler(this.txtMy_TextChanged);
            // 
            // lblMx
            // 
            this.lblMx.AutoSize = true;
            this.lblMx.Location = new System.Drawing.Point(5, 22);
            this.lblMx.Name = "lblMx";
            this.lblMx.Size = new System.Drawing.Size(40, 13);
            this.lblMx.TabIndex = 7;
            this.lblMx.Text = "Asse X";
            // 
            // txtMx
            // 
            this.txtMx.Location = new System.Drawing.Point(55, 18);
            this.txtMx.Name = "txtMx";
            this.txtMx.ReadOnly = true;
            this.txtMx.Size = new System.Drawing.Size(56, 20);
            this.txtMx.TabIndex = 10;
            this.txtMx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMx.TextChanged += new System.EventHandler(this.txtMx_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Asse Y";
            // 
            // gpbAngolo
            // 
            this.gpbAngolo.Controls.Add(this.txtRad);
            this.gpbAngolo.Controls.Add(this.txtGrad);
            this.gpbAngolo.Controls.Add(this.label3);
            this.gpbAngolo.Controls.Add(this.label4);
            this.gpbAngolo.Location = new System.Drawing.Point(107, 197);
            this.gpbAngolo.Name = "gpbAngolo";
            this.gpbAngolo.Size = new System.Drawing.Size(88, 74);
            this.gpbAngolo.TabIndex = 12;
            this.gpbAngolo.TabStop = false;
            this.gpbAngolo.Text = "Angolazione";
            this.tttInfo.SetToolTip(this.gpbAngolo, "Ruota il sistema di riferimento esterno rispetto a quello intrinseco all’accelero" +
                    "metro così\r\nda permettere di tenere il dispositivo leggermente obliquo rispetto " +
                    "all’utilizzatore.");
            // 
            // txtRad
            // 
            this.txtRad.Location = new System.Drawing.Point(38, 45);
            this.txtRad.Name = "txtRad";
            this.txtRad.ReadOnly = true;
            this.txtRad.Size = new System.Drawing.Size(42, 20);
            this.txtRad.TabIndex = 11;
            this.txtRad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tttInfo.SetToolTip(this.txtRad, "Rotazione in Radianti");
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(38, 23);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(42, 20);
            this.txtGrad.TabIndex = 10;
            this.txtGrad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tttInfo.SetToolTip(this.txtGrad, "Rotazione in Gradi");
            this.txtGrad.TextChanged += new System.EventHandler(this.txtGrad_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.MaximumSize = new System.Drawing.Size(30, 13);
            this.label3.MinimumSize = new System.Drawing.Size(30, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.MaximumSize = new System.Drawing.Size(40, 13);
            this.label4.MinimumSize = new System.Drawing.Size(30, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gradi:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpbOffset
            // 
            this.gpbOffset.Controls.Add(this.lblDX);
            this.gpbOffset.Controls.Add(this.txtY);
            this.gpbOffset.Controls.Add(this.txtX);
            this.gpbOffset.Controls.Add(this.lblDY);
            this.gpbOffset.Location = new System.Drawing.Point(6, 197);
            this.gpbOffset.Name = "gpbOffset";
            this.gpbOffset.Size = new System.Drawing.Size(95, 74);
            this.gpbOffset.TabIndex = 3;
            this.gpbOffset.TabStop = false;
            this.gpbOffset.Text = "Offset";
            this.tttInfo.SetToolTip(this.gpbOffset, "Corregge il non perfetto allineamento tra l’asse dell’accelerometro e la \r\nvertic" +
                    "ale.");
            this.gpbOffset.Enter += new System.EventHandler(this.gpbOffset_Enter);
            // 
            // lblDX
            // 
            this.lblDX.AutoSize = true;
            this.lblDX.Location = new System.Drawing.Point(5, 22);
            this.lblDX.Name = "lblDX";
            this.lblDX.Size = new System.Drawing.Size(40, 13);
            this.lblDX.TabIndex = 12;
            this.lblDX.Text = "Asse X";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(52, 45);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(37, 20);
            this.txtY.TabIndex = 11;
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtY.TextChanged += new System.EventHandler(this.txtY_TextChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(52, 19);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(37, 20);
            this.txtX.TabIndex = 10;
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtX.TextChanged += new System.EventHandler(this.txtX_TextChanged);
            // 
            // lblDY
            // 
            this.lblDY.AutoSize = true;
            this.lblDY.Location = new System.Drawing.Point(5, 48);
            this.lblDY.Name = "lblDY";
            this.lblDY.Size = new System.Drawing.Size(40, 13);
            this.lblDY.TabIndex = 8;
            this.lblDY.Text = "Asse Y";
            // 
            // angleSelector
            // 
            this.angleSelector.Angle = 180;
            this.angleSelector.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.angleSelector.Location = new System.Drawing.Point(36, 19);
            this.angleSelector.Name = "angleSelector";
            this.angleSelector.Size = new System.Drawing.Size(143, 143);
            this.angleSelector.TabIndex = 2;
            this.tttInfo.SetToolTip(this.angleSelector, "Regola l\'angolazione. Il centro del cerchio corrisponde al pulsante destro del mo" +
                    "use.");
            this.angleSelector.AngleChanged += new AngleAltitudeControls.AngleSelector.AngleChangedDelegate(this.angleSelector_AngleChanged);
            // 
            // gpbScalamento
            // 
            this.gpbScalamento.Controls.Add(this.label1);
            this.gpbScalamento.Controls.Add(this.label5);
            this.gpbScalamento.Controls.Add(this.tkbScalamentoY);
            this.gpbScalamento.Controls.Add(this.tkbScalamentoX);
            this.gpbScalamento.Location = new System.Drawing.Point(294, 10);
            this.gpbScalamento.Name = "gpbScalamento";
            this.gpbScalamento.Size = new System.Drawing.Size(117, 188);
            this.gpbScalamento.TabIndex = 12;
            this.gpbScalamento.TabStop = false;
            this.gpbScalamento.Text = "Sensibilità";
            this.tttInfo.SetToolTip(this.gpbScalamento, "Regola il guadagno in modo da evitare effetti eccessivi causati da piccoli movime" +
                    "nti oppure movivemti troppo marcati della mano per eseguire l\'azione desiderata." +
                    "\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Asse Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Asse X";
            // 
            // tkbScalamentoY
            // 
            this.tkbScalamentoY.Cursor = System.Windows.Forms.Cursors.Default;
            this.tkbScalamentoY.Location = new System.Drawing.Point(69, 19);
            this.tkbScalamentoY.Maximum = 100;
            this.tkbScalamentoY.Minimum = 1;
            this.tkbScalamentoY.Name = "tkbScalamentoY";
            this.tkbScalamentoY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbScalamentoY.Size = new System.Drawing.Size(45, 143);
            this.tkbScalamentoY.TabIndex = 14;
            this.tkbScalamentoY.TickFrequency = 10;
            this.tkbScalamentoY.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tttInfo.SetToolTip(this.tkbScalamentoY, "Regola il guadagno dell\'asse Y");
            this.tkbScalamentoY.Value = 10;
            this.tkbScalamentoY.Scroll += new System.EventHandler(this.tkbScalamentoY_Scroll);
            // 
            // tkbScalamentoX
            // 
            this.tkbScalamentoX.Cursor = System.Windows.Forms.Cursors.Default;
            this.tkbScalamentoX.LargeChange = 1;
            this.tkbScalamentoX.Location = new System.Drawing.Point(9, 19);
            this.tkbScalamentoX.Maximum = 100;
            this.tkbScalamentoX.Minimum = 1;
            this.tkbScalamentoX.Name = "tkbScalamentoX";
            this.tkbScalamentoX.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkbScalamentoX.Size = new System.Drawing.Size(45, 143);
            this.tkbScalamentoX.TabIndex = 20;
            this.tkbScalamentoX.TickFrequency = 10;
            this.tkbScalamentoX.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tttInfo.SetToolTip(this.tkbScalamentoX, "Regola il guadagno dell\'asse X");
            this.tkbScalamentoX.Value = 10;
            this.tkbScalamentoX.Scroll += new System.EventHandler(this.tkbScalamentoX_Scroll);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(512, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Annulla";
            this.tttInfo.SetToolTip(this.btnCancel, "Annulla le modifiche caricando le ultime impostazioni salvate.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAnteprima
            // 
            this.btnAnteprima.AutoSize = true;
            this.btnAnteprima.Location = new System.Drawing.Point(603, 294);
            this.btnAnteprima.Name = "btnAnteprima";
            this.btnAnteprima.Size = new System.Drawing.Size(112, 23);
            this.btnAnteprima.TabIndex = 6;
            this.btnAnteprima.Text = "Anteprima modifiche";
            this.tttInfo.SetToolTip(this.btnAnteprima, "Applica le modifiche effettuate nell\'interfaccia. ");
            this.btnAnteprima.UseVisualStyleBackColor = true;
            this.btnAnteprima.Click += new System.EventHandler(this.btnAnteprima_Click);
            // 
            // btnScrivi
            // 
            this.btnScrivi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScrivi.Location = new System.Drawing.Point(721, 294);
            this.btnScrivi.Name = "btnScrivi";
            this.btnScrivi.Size = new System.Drawing.Size(108, 23);
            this.btnScrivi.TabIndex = 7;
            this.btnScrivi.Text = "Salva modifiche";
            this.tttInfo.SetToolTip(this.btnScrivi, "Salva le impostazioni di cui si è effettuata l\'anteprima sul dispositivo connesso" +
                    ".");
            this.btnScrivi.UseVisualStyleBackColor = true;
            this.btnScrivi.Click += new System.EventHandler(this.btnScrivi_Click);
            // 
            // tttInfo
            // 
            this.tttInfo.Active = false;
            this.tttInfo.IsBalloon = true;
            this.tttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tttInfo.ToolTipTitle = "Aiuto in linea";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::GenericHid.Properties.Resources.topo1;
            this.pictureBox1.Location = new System.Drawing.Point(6, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.tttInfo.SetToolTip(this.pictureBox1, "Istruzioni");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 305);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // CancelExit
            // 
            this.CancelExit.Location = new System.Drawing.Point(412, 294);
            this.CancelExit.Name = "CancelExit";
            this.CancelExit.Size = new System.Drawing.Size(95, 23);
            this.CancelExit.TabIndex = 9;
            this.CancelExit.Text = "Annulla ed esci";
            this.CancelExit.UseVisualStyleBackColor = true;
            this.CancelExit.Click += new System.EventHandler(this.CancelExit_Click);
            // 
            // Calibrazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 320);
            this.Controls.Add(this.CancelExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnScrivi);
            this.Controls.Add(this.btnAnteprima);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(848, 358);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(848, 358);
            this.Name = "Calibrazione";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Calibrazione";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Calibrazione_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tkbDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbDy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gpbAngolo.ResumeLayout(false);
            this.gpbAngolo.PerformLayout();
            this.gpbOffset.ResumeLayout(false);
            this.gpbOffset.PerformLayout();
            this.gpbScalamento.ResumeLayout(false);
            this.gpbScalamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tkbScalamentoY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkbScalamentoX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tkbDx;
        private System.Windows.Forms.TrackBar tkbDy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAnteprima;
        private System.Windows.Forms.Button btnScrivi;
        private AngleAltitudeControls.AngleSelector angleSelector;
        private System.Windows.Forms.GroupBox gpbAngolo;
        private System.Windows.Forms.TextBox txtGrad;
        private System.Windows.Forms.GroupBox gpbOffset;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lblDY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpbScalamento;
        private System.Windows.Forms.TextBox txtMy;
        private System.Windows.Forms.TextBox txtMx;
        private System.Windows.Forms.Label lblMy;
        private System.Windows.Forms.Label lblMx;
        private System.Windows.Forms.TrackBar tkbScalamentoX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDX;
        private System.Windows.Forms.ToolTip tttInfo;
        private System.Windows.Forms.TrackBar tkbScalamentoY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb_mirrorY;
        private System.Windows.Forms.CheckBox cb_mirrorX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button auto_offset;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button CancelExit;
    }
}