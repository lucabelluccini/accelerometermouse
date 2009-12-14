using Microsoft.Win32.SafeHandles; 
using System.Runtime.InteropServices; 
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GenericHid;

namespace GenericHid
{
    /*internal*/ class TopoTester 
        
        : System.Windows.Forms.Form 
    {         
        #region '"Windows Form Designer generated code "' 
        public TopoTester() : base() 
        {   
            
            // This call is required by the Windows Form Designer.
            InitializeComponent(); 
        } 
        // Form overrides dispose to clean up the component list.
        protected override void Dispose( bool Disposing ) 
        { 
            if ( Disposing ) 
            { 
                if ( !( components == null ) ) 
                { 
                    components.Dispose(); 
                } 
            } 
            base.Dispose( Disposing ); 
        } 
        
        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components; 
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Timer tmrContinuousDataCollect;
        public System.Windows.Forms.Timer tmrDelay; 
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.      
        internal System.Windows.Forms.GroupBox fraDeviceIdentifiers;
        internal System.Windows.Forms.Label lblVendorID; 
        internal System.Windows.Forms.Label lblProductID;
        internal System.Windows.Forms.TextBox txtProductID;
        internal TextBox txtVendorID;
        private GroupBox extraCommands;
        private GroupBox gpbAdvanced;
        internal GroupBox fraInputReportBufferSize;
        internal Button cmdInputReportBufferSize;
        internal TextBox txtInputReportBufferSize;
        internal GroupBox fraReportTypes;
        internal CheckBox chkUseControlTransfersOnly;
        internal RadioButton optFeature;
        internal RadioButton optInputOutput;
        public GroupBox fraSendAndReceive;
        public Button cmdContinuous;
        public Button cmdOnce;
        public GroupBox fraBytesReceived;
        public TextBox txtBytesReceived;
        public GroupBox fraBytesToSend;
        public CheckBox chkAutoincrement;
        public ComboBox cboByte1;
        public ComboBox cboByte0;
        public ListBox lstResults;
        internal Button cmdFindDevice;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private PictureBox pctStatus;
        private PictureBox pictureBox3;
        private CheckBox ckbAutoReveal;
        private Button button1;
        private Button btnCalibrazione; 
       
        [ System.Diagnostics.DebuggerStepThrough() ]
        private void InitializeComponent() 
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopoTester));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrContinuousDataCollect = new System.Windows.Forms.Timer(this.components);
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.fraDeviceIdentifiers = new System.Windows.Forms.GroupBox();
            this.ckbAutoReveal = new System.Windows.Forms.CheckBox();
            this.cmdFindDevice = new System.Windows.Forms.Button();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.extraCommands = new System.Windows.Forms.GroupBox();
            this.btnCalibrazione = new System.Windows.Forms.Button();
            this.gpbAdvanced = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fraInputReportBufferSize = new System.Windows.Forms.GroupBox();
            this.cmdInputReportBufferSize = new System.Windows.Forms.Button();
            this.txtInputReportBufferSize = new System.Windows.Forms.TextBox();
            this.fraReportTypes = new System.Windows.Forms.GroupBox();
            this.chkUseControlTransfersOnly = new System.Windows.Forms.CheckBox();
            this.optFeature = new System.Windows.Forms.RadioButton();
            this.optInputOutput = new System.Windows.Forms.RadioButton();
            this.fraSendAndReceive = new System.Windows.Forms.GroupBox();
            this.cmdContinuous = new System.Windows.Forms.Button();
            this.cmdOnce = new System.Windows.Forms.Button();
            this.fraBytesReceived = new System.Windows.Forms.GroupBox();
            this.txtBytesReceived = new System.Windows.Forms.TextBox();
            this.fraBytesToSend = new System.Windows.Forms.GroupBox();
            this.chkAutoincrement = new System.Windows.Forms.CheckBox();
            this.cboByte1 = new System.Windows.Forms.ComboBox();
            this.cboByte0 = new System.Windows.Forms.ComboBox();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pctStatus = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.fraDeviceIdentifiers.SuspendLayout();
            this.extraCommands.SuspendLayout();
            this.gpbAdvanced.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.fraInputReportBufferSize.SuspendLayout();
            this.fraReportTypes.SuspendLayout();
            this.fraSendAndReceive.SuspendLayout();
            this.fraBytesReceived.SuspendLayout();
            this.fraBytesToSend.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctStatus)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrContinuousDataCollect
            // 
            this.tmrContinuousDataCollect.Interval = 1;
            this.tmrContinuousDataCollect.Tick += new System.EventHandler(this.tmrContinuousDataCollect_Tick);
            // 
            // tmrDelay
            // 
            this.tmrDelay.Interval = 1;
            // 
            // fraDeviceIdentifiers
            // 
            this.fraDeviceIdentifiers.Controls.Add(this.ckbAutoReveal);
            this.fraDeviceIdentifiers.Controls.Add(this.cmdFindDevice);
            this.fraDeviceIdentifiers.Controls.Add(this.txtProductID);
            this.fraDeviceIdentifiers.Controls.Add(this.lblProductID);
            this.fraDeviceIdentifiers.Controls.Add(this.txtVendorID);
            this.fraDeviceIdentifiers.Controls.Add(this.lblVendorID);
            this.fraDeviceIdentifiers.Location = new System.Drawing.Point(12, 21);
            this.fraDeviceIdentifiers.Name = "fraDeviceIdentifiers";
            this.fraDeviceIdentifiers.Size = new System.Drawing.Size(186, 101);
            this.fraDeviceIdentifiers.TabIndex = 10;
            this.fraDeviceIdentifiers.TabStop = false;
            this.fraDeviceIdentifiers.Text = "Connessione";
            // 
            // ckbAutoReveal
            // 
            this.ckbAutoReveal.AutoSize = true;
            this.ckbAutoReveal.Location = new System.Drawing.Point(19, 73);
            this.ckbAutoReveal.Name = "ckbAutoReveal";
            this.ckbAutoReveal.Size = new System.Drawing.Size(49, 18);
            this.ckbAutoReveal.TabIndex = 2;
            this.ckbAutoReveal.Text = "Auto";
            this.ckbAutoReveal.UseVisualStyleBackColor = true;
            this.ckbAutoReveal.CheckedChanged += new System.EventHandler(this.ckbAutoReveal_CheckedChanged);
            // 
            // cmdFindDevice
            // 
            this.cmdFindDevice.Location = new System.Drawing.Point(74, 70);
            this.cmdFindDevice.Name = "cmdFindDevice";
            this.cmdFindDevice.Size = new System.Drawing.Size(99, 23);
            this.cmdFindDevice.TabIndex = 1;
            this.cmdFindDevice.Text = "Connetti";
            this.cmdFindDevice.Click += new System.EventHandler(this.cmdFindDevice_Click);
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtProductID.Location = new System.Drawing.Point(120, 44);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(53, 20);
            this.txtProductID.TabIndex = 20;
            this.txtProductID.Text = "0012";
            this.txtProductID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProductID.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            // 
            // lblProductID
            // 
            this.lblProductID.Location = new System.Drawing.Point(16, 47);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(112, 23);
            this.lblProductID.TabIndex = 2;
            this.lblProductID.Text = "Product ID (hex):";
            // 
            // txtVendorID
            // 
            this.txtVendorID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVendorID.Location = new System.Drawing.Point(120, 21);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(53, 20);
            this.txtVendorID.TabIndex = 19;
            this.txtVendorID.Text = "04D8";
            this.txtVendorID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorID.TextChanged += new System.EventHandler(this.txtVendorID_TextChanged);
            // 
            // lblVendorID
            // 
            this.lblVendorID.Location = new System.Drawing.Point(16, 24);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(112, 23);
            this.lblVendorID.TabIndex = 0;
            this.lblVendorID.Text = "Vendor ID (hex):";
            // 
            // extraCommands
            // 
            this.extraCommands.Controls.Add(this.btnCalibrazione);
            this.extraCommands.Location = new System.Drawing.Point(12, 128);
            this.extraCommands.Name = "extraCommands";
            this.extraCommands.Size = new System.Drawing.Size(251, 60);
            this.extraCommands.TabIndex = 11;
            this.extraCommands.TabStop = false;
            this.extraCommands.Text = "Configurazione del dispositivo";
            // 
            // btnCalibrazione
            // 
            this.btnCalibrazione.Location = new System.Drawing.Point(5, 25);
            this.btnCalibrazione.Name = "btnCalibrazione";
            this.btnCalibrazione.Size = new System.Drawing.Size(240, 27);
            this.btnCalibrazione.TabIndex = 0;
            this.btnCalibrazione.Text = "Calibrazione";
            this.btnCalibrazione.UseVisualStyleBackColor = true;
            this.btnCalibrazione.Click += new System.EventHandler(this.btnCalibrazione_Click);
            // 
            // gpbAdvanced
            // 
            this.gpbAdvanced.Controls.Add(this.groupBox3);
            this.gpbAdvanced.Controls.Add(this.fraInputReportBufferSize);
            this.gpbAdvanced.Controls.Add(this.fraReportTypes);
            this.gpbAdvanced.Controls.Add(this.fraSendAndReceive);
            this.gpbAdvanced.Controls.Add(this.fraBytesReceived);
            this.gpbAdvanced.Controls.Add(this.fraBytesToSend);
            this.gpbAdvanced.Controls.Add(this.lstResults);
            this.gpbAdvanced.Location = new System.Drawing.Point(12, 205);
            this.gpbAdvanced.Name = "gpbAdvanced";
            this.gpbAdvanced.Size = new System.Drawing.Size(559, 399);
            this.gpbAdvanced.TabIndex = 12;
            this.gpbAdvanced.TabStop = false;
            this.gpbAdvanced.Text = "Funzionalità avanzate (MadMouse Debug)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(23, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(127, 127);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenericHid.Properties.Resources.madmouse;
            this.pictureBox1.Location = new System.Drawing.Point(6, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 111);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fraInputReportBufferSize
            // 
            this.fraInputReportBufferSize.Controls.Add(this.cmdInputReportBufferSize);
            this.fraInputReportBufferSize.Controls.Add(this.txtInputReportBufferSize);
            this.fraInputReportBufferSize.Location = new System.Drawing.Point(387, 22);
            this.fraInputReportBufferSize.Name = "fraInputReportBufferSize";
            this.fraInputReportBufferSize.Size = new System.Drawing.Size(153, 86);
            this.fraInputReportBufferSize.TabIndex = 15;
            this.fraInputReportBufferSize.TabStop = false;
            this.fraInputReportBufferSize.Text = "Input Report Buffer Size";
            // 
            // cmdInputReportBufferSize
            // 
            this.cmdInputReportBufferSize.AutoSize = true;
            this.cmdInputReportBufferSize.Location = new System.Drawing.Point(11, 54);
            this.cmdInputReportBufferSize.Name = "cmdInputReportBufferSize";
            this.cmdInputReportBufferSize.Size = new System.Drawing.Size(136, 25);
            this.cmdInputReportBufferSize.TabIndex = 1;
            this.cmdInputReportBufferSize.Text = "Cambia dimensione";
            // 
            // txtInputReportBufferSize
            // 
            this.txtInputReportBufferSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtInputReportBufferSize.Location = new System.Drawing.Point(11, 28);
            this.txtInputReportBufferSize.Name = "txtInputReportBufferSize";
            this.txtInputReportBufferSize.Size = new System.Drawing.Size(136, 20);
            this.txtInputReportBufferSize.TabIndex = 0;
            // 
            // fraReportTypes
            // 
            this.fraReportTypes.Controls.Add(this.chkUseControlTransfersOnly);
            this.fraReportTypes.Controls.Add(this.optFeature);
            this.fraReportTypes.Controls.Add(this.optInputOutput);
            this.fraReportTypes.Location = new System.Drawing.Point(23, 155);
            this.fraReportTypes.Name = "fraReportTypes";
            this.fraReportTypes.Size = new System.Drawing.Size(210, 108);
            this.fraReportTypes.TabIndex = 14;
            this.fraReportTypes.TabStop = false;
            this.fraReportTypes.Text = "Reports";
            // 
            // chkUseControlTransfersOnly
            // 
            this.chkUseControlTransfersOnly.Location = new System.Drawing.Point(24, 48);
            this.chkUseControlTransfersOnly.Name = "chkUseControlTransfersOnly";
            this.chkUseControlTransfersOnly.Size = new System.Drawing.Size(159, 24);
            this.chkUseControlTransfersOnly.TabIndex = 2;
            this.chkUseControlTransfersOnly.Text = "Solo ControlTransfers";
            // 
            // optFeature
            // 
            this.optFeature.Location = new System.Drawing.Point(8, 80);
            this.optFeature.Name = "optFeature";
            this.optFeature.Size = new System.Drawing.Size(199, 24);
            this.optFeature.TabIndex = 1;
            this.optFeature.Text = "Scambia Feature Reports";
            // 
            // optInputOutput
            // 
            this.optInputOutput.Checked = true;
            this.optInputOutput.Location = new System.Drawing.Point(8, 24);
            this.optInputOutput.Name = "optInputOutput";
            this.optInputOutput.Size = new System.Drawing.Size(199, 24);
            this.optInputOutput.TabIndex = 0;
            this.optInputOutput.TabStop = true;
            this.optInputOutput.Text = "Scambia Input e Output Reports";
            // 
            // fraSendAndReceive
            // 
            this.fraSendAndReceive.BackColor = System.Drawing.SystemColors.Control;
            this.fraSendAndReceive.Controls.Add(this.cmdContinuous);
            this.fraSendAndReceive.Controls.Add(this.cmdOnce);
            this.fraSendAndReceive.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraSendAndReceive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraSendAndReceive.Location = new System.Drawing.Point(243, 157);
            this.fraSendAndReceive.Name = "fraSendAndReceive";
            this.fraSendAndReceive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraSendAndReceive.Size = new System.Drawing.Size(138, 106);
            this.fraSendAndReceive.TabIndex = 13;
            this.fraSendAndReceive.TabStop = false;
            this.fraSendAndReceive.Text = "Invia/Ricevi dati";
            // 
            // cmdContinuous
            // 
            this.cmdContinuous.BackColor = System.Drawing.SystemColors.Control;
            this.cmdContinuous.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdContinuous.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdContinuous.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdContinuous.Location = new System.Drawing.Point(22, 59);
            this.cmdContinuous.Name = "cmdContinuous";
            this.cmdContinuous.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdContinuous.Size = new System.Drawing.Size(96, 27);
            this.cmdContinuous.TabIndex = 9;
            this.cmdContinuous.Text = "Continuamente";
            this.cmdContinuous.UseVisualStyleBackColor = false;
            // 
            // cmdOnce
            // 
            this.cmdOnce.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOnce.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOnce.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOnce.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOnce.Location = new System.Drawing.Point(22, 28);
            this.cmdOnce.Name = "cmdOnce";
            this.cmdOnce.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOnce.Size = new System.Drawing.Size(96, 25);
            this.cmdOnce.TabIndex = 8;
            this.cmdOnce.Text = "Una sola volta";
            this.cmdOnce.UseVisualStyleBackColor = false;
            // 
            // fraBytesReceived
            // 
            this.fraBytesReceived.BackColor = System.Drawing.SystemColors.Control;
            this.fraBytesReceived.Controls.Add(this.txtBytesReceived);
            this.fraBytesReceived.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraBytesReceived.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraBytesReceived.Location = new System.Drawing.Point(387, 116);
            this.fraBytesReceived.Name = "fraBytesReceived";
            this.fraBytesReceived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraBytesReceived.Size = new System.Drawing.Size(154, 147);
            this.fraBytesReceived.TabIndex = 12;
            this.fraBytesReceived.TabStop = false;
            this.fraBytesReceived.Text = "Byte ricevuti";
            // 
            // txtBytesReceived
            // 
            this.txtBytesReceived.AcceptsReturn = true;
            this.txtBytesReceived.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtBytesReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBytesReceived.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBytesReceived.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBytesReceived.Location = new System.Drawing.Point(20, 24);
            this.txtBytesReceived.MaxLength = 0;
            this.txtBytesReceived.Multiline = true;
            this.txtBytesReceived.Name = "txtBytesReceived";
            this.txtBytesReceived.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBytesReceived.Size = new System.Drawing.Size(114, 103);
            this.txtBytesReceived.TabIndex = 5;
            // 
            // fraBytesToSend
            // 
            this.fraBytesToSend.BackColor = System.Drawing.SystemColors.Control;
            this.fraBytesToSend.Controls.Add(this.chkAutoincrement);
            this.fraBytesToSend.Controls.Add(this.cboByte1);
            this.fraBytesToSend.Controls.Add(this.cboByte0);
            this.fraBytesToSend.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraBytesToSend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraBytesToSend.Location = new System.Drawing.Point(156, 22);
            this.fraBytesToSend.Name = "fraBytesToSend";
            this.fraBytesToSend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraBytesToSend.Size = new System.Drawing.Size(225, 129);
            this.fraBytesToSend.TabIndex = 11;
            this.fraBytesToSend.TabStop = false;
            this.fraBytesToSend.Text = "Byte da inviare";
            // 
            // chkAutoincrement
            // 
            this.chkAutoincrement.AutoSize = true;
            this.chkAutoincrement.BackColor = System.Drawing.SystemColors.Control;
            this.chkAutoincrement.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkAutoincrement.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoincrement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoincrement.Location = new System.Drawing.Point(8, 94);
            this.chkAutoincrement.Name = "chkAutoincrement";
            this.chkAutoincrement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAutoincrement.Size = new System.Drawing.Size(148, 18);
            this.chkAutoincrement.TabIndex = 6;
            this.chkAutoincrement.Text = "Autoincremento dei valori";
            this.chkAutoincrement.UseVisualStyleBackColor = false;
            // 
            // cboByte1
            // 
            this.cboByte1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cboByte1.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboByte1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboByte1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboByte1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboByte1.Location = new System.Drawing.Point(8, 64);
            this.cboByte1.Name = "cboByte1";
            this.cboByte1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboByte1.Size = new System.Drawing.Size(211, 22);
            this.cboByte1.TabIndex = 3;
            // 
            // cboByte0
            // 
            this.cboByte0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cboByte0.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboByte0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboByte0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboByte0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboByte0.Location = new System.Drawing.Point(8, 24);
            this.cboByte0.Name = "cboByte0";
            this.cboByte0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboByte0.Size = new System.Drawing.Size(211, 22);
            this.cboByte0.TabIndex = 2;
            // 
            // lstResults
            // 
            this.lstResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.lstResults.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstResults.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstResults.HorizontalScrollbar = true;
            this.lstResults.ItemHeight = 14;
            this.lstResults.Location = new System.Drawing.Point(23, 269);
            this.lstResults.Name = "lstResults";
            this.lstResults.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstResults.Size = new System.Drawing.Size(518, 116);
            this.lstResults.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pctStatus);
            this.groupBox2.Location = new System.Drawing.Point(204, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 101);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stato";
            // 
            // pctStatus
            // 
            this.pctStatus.Image = global::GenericHid.Properties.Resources.cancel_256;
            this.pctStatus.Location = new System.Drawing.Point(15, 24);
            this.pctStatus.Name = "pctStatus";
            this.pctStatus.Size = new System.Drawing.Size(60, 60);
            this.pctStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctStatus.TabIndex = 0;
            this.pctStatus.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(269, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 60);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modalità GUI";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Standard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::GenericHid.Properties.Resources._231_topo_trappola_1;
            this.pictureBox3.Location = new System.Drawing.Point(302, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(269, 101);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // TopoTester
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 608);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gpbAdvanced);
            this.Controls.Add(this.extraCommands);
            this.Controls.Add(this.fraDeviceIdentifiers);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(21, 28);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopoTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TopoTester";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closed += new System.EventHandler(this.frmMain_Closed);
            this.fraDeviceIdentifiers.ResumeLayout(false);
            this.fraDeviceIdentifiers.PerformLayout();
            this.extraCommands.ResumeLayout(false);
            this.gpbAdvanced.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.fraInputReportBufferSize.ResumeLayout(false);
            this.fraInputReportBufferSize.PerformLayout();
            this.fraReportTypes.ResumeLayout(false);
            this.fraSendAndReceive.ResumeLayout(false);
            this.fraBytesReceived.ResumeLayout(false);
            this.fraBytesReceived.PerformLayout();
            this.fraBytesToSend.ResumeLayout(false);
            this.fraBytesToSend.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctStatus)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }         
        #endregion 
        
        private IntPtr deviceNotificationHandle; 
        private Boolean exclusiveAccess; 
        private SafeFileHandle hidHandle; 
        private String hidUsage; 
        private Boolean myDeviceDetected; 
        private String myDevicePathName; 
        private SafeFileHandle readHandle; 
        private SafeFileHandle writeHandle; 
        
        private Debugging MyDebugging = new Debugging(); //  For viewing results of API calls via Debug.Write.
        private DeviceManagement MyDeviceManagement = new DeviceManagement(); 
        private Hid MyHid = new Hid(); 
        
        internal TopoTester FrmMy;

        volatile bool flag_DeviceConnected = DefinesAndConstants.DEBUG_CALIBRAZIONE;
        Calibrazione c;

        ///  <summary>
        ///  Define a class of delegates that point to the Hid.ReportIn.Read function.
        ///  The delegate has the same parameters as Hid.ReportIn.Read.
        ///  Used for asynchronous reads from the device.       
        ///  </summary>
        
        private delegate void ReadInputReportDelegate( SafeFileHandle hidHandle, SafeFileHandle readHandle, SafeFileHandle writeHandle, ref Boolean myDeviceDetected, ref Byte[] readBuffer, ref Boolean success );
        
        //  This delegate has the same parameters as AccessForm.
        //  Used in accessing the application's form from a different thread.
        
        private delegate void MarshalToForm( String action, String textToAdd );
        
        ///  <summary>
        ///  Called when a WM_DEVICECHANGE message has arrived,
        ///  indicating that a device has been attached or removed.
        ///  </summary>
        ///  
        ///  <param name="m"> a message with information about the device </param>
        
        internal void OnDeviceChange( Message m ) 
        {             
            Debug.WriteLine( "WM_DEVICECHANGE" );

            if (ckbAutoReveal.Checked)
            {

                if (!flag_DeviceConnected) cmdFindDevice_Click(this, null);

                try
                {
                    if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEARRIVAL))
                    {

                        //  If WParam contains DBT_DEVICEARRIVAL, a device has been attached.

                        Debug.WriteLine("A device has been attached.");

                        //  Find out if it's the device we're communicating with.

                        if (MyDeviceManagement.DeviceNameMatch(m, myDevicePathName))
                        {
                            lstResults.Items.Add("My device attached.");
                        }

                    }
                    else if ((m.WParam.ToInt32() == DeviceManagement.DBT_DEVICEREMOVECOMPLETE))
                    {

                        //  If WParam contains DBT_DEVICEREMOVAL, a device has been removed.

                        Debug.WriteLine("A device has been removed.");

                        //  Find out if it's the device we're communicating with.

                        if (MyDeviceManagement.DeviceNameMatch(m, myDevicePathName))
                        {

                            lstResults.Items.Add("My device removed.");

                            //  Set MyDeviceDetected False so on the next data-transfer attempt,
                            //  FindTheHid() will be called to look for the device 
                            //  and get a new handle.

                            FrmMy.myDeviceDetected = false;
                            this.flag_DeviceConnected = false;

                            if (c!=null)
                            c.Close();

                            cmdFindDevice_Click(this, null);
                        }
                    }
                    ScrollToBottomOfListBox();

                }
                catch (Exception ex)
                {
                    DisplayException(this.Name, ex);
                    throw;
                }
            }

        }         
        
        ///  <summary>
        ///  Uses a series of API calls to locate a HID-class device
        ///  by its Vendor ID and Product ID.
        ///  </summary>
        ///          
        ///  <returns>
        ///   True if the device is detected, False if not detected.
        ///  </returns>
        
        private Boolean FindTheHid() 
        {             
            Boolean deviceFound = false; 
            String[] devicePathName = new String[ 128 ];
            String functionName = "";
            Guid hidGuid = Guid.Empty; 
            Int32 memberIndex = 0; 
            Int16 myProductID = 0; 
            Int16 myVendorID = 0; 
            Boolean success = false;            
            
            try 
            { 
                myDeviceDetected = false; 
                
                //  Get the device's Vendor ID and Product ID from the form's text boxes.
                
                GetVendorAndProductIDsFromTextBoxes( ref myVendorID, ref myProductID ); 
                
                //  ***
                //  API function: 'HidD_GetHidGuid
                
                //  Purpose: Retrieves the interface class GUID for the HID class.
                
                //  Accepts: 'A System.Guid object for storing the GUID.
                //  ***
                
                Hid.HidD_GetHidGuid( ref hidGuid );

                functionName = "GetHidGuid"; 
                Debug.WriteLine( MyDebugging.ResultOfAPICall( functionName ) ); 
                Debug.WriteLine( "  GUID for system HIDs: " + hidGuid.ToString() ); 
                
                //  Fill an array with the device path names of all attached HIDs.
                
                deviceFound = MyDeviceManagement.FindDeviceFromGuid( hidGuid, ref devicePathName ); 
                
                //  If there is at least one HID, attempt to read the Vendor ID and Product ID
                //  of each device until there is a match or all devices have been examined.

                int times_found = 0;
                
                if ( deviceFound ) 
                {                     
                    memberIndex = 0; 
                    
                    do 
                    { 
                        //  ***
                        //  API function:
                        //  CreateFile
                        
                        //  Purpose:
                        //  Retrieves a handle to a device.
                        
                        //  Accepts:
                        //  A device path name returned by SetupDiGetDeviceInterfaceDetail
                        //  The type of access requested (read/write).
                        //  FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                        //  A Security structure or IntPtr.Zero. 
                        //  A creation disposition value. Use OPEN_EXISTING for devices.
                        //  Flags and attributes for files. Not used for devices.
                        //  Handle to a template file. Not used.
                        
                        //  Returns: a handle without read or write access.
                        //  This enables obtaining information about all HIDs, even system
                        //  keyboards and mice. 
                        //  Separate handles are used for reading and writing.
                        //  ***

                        hidHandle = FileIO.CreateFile(devicePathName[memberIndex], 0, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        functionName = "CreateFile"; 
                        Debug.WriteLine( MyDebugging.ResultOfAPICall( functionName ) ); 
                        Debug.WriteLine( "  Returned handle: " + hidHandle.ToString() ); 
                        
                        if (!hidHandle.IsInvalid)  
                        {                             
                            //  The returned handle is valid, 
                            //  so find out if this is the device we're looking for.
                            
                            //  Set the Size property of DeviceAttributes to the number of bytes in the structure.
                            
                            MyHid.DeviceAttributes.Size = Marshal.SizeOf( MyHid.DeviceAttributes ); 
                            
                            //  ***
                            //  API function:
                            //  HidD_GetAttributes
                            
                            //  Purpose:
                            //  Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                            //  Product ID, and Product Version Number for a device.
                            
                            //  Accepts:
                            //  A handle returned by CreateFile.
                            //  A pointer to receive a HIDD_ATTRIBUTES structure.
                            
                            //  Returns:
                            //  True on success, False on failure.
                            //  ***                            
                            
                            success = Hid.HidD_GetAttributes(hidHandle, ref MyHid.DeviceAttributes); 
                            
                            if ( success ) 
                            {                                
                                Debug.WriteLine( "  HIDD_ATTRIBUTES structure filled without error." ); 
                                Debug.WriteLine( "  Structure size: " + MyHid.DeviceAttributes.Size );                                                                                               
                                Debug.WriteLine("  Vendor ID: " + Convert.ToString(MyHid.DeviceAttributes.VendorID, 16));                               
                                Debug.WriteLine("  Product ID: " + Convert.ToString(MyHid.DeviceAttributes.ProductID, 16));                               
                                Debug.WriteLine("  Version Number: " + Convert.ToString(MyHid.DeviceAttributes.VersionNumber, 16)); 
                                
                                //  Find out if the device matches the one we're looking for.
                                
                                if ( ( MyHid.DeviceAttributes.VendorID == myVendorID ) && ( MyHid.DeviceAttributes.ProductID == myProductID ) ) 
                                { 
                                    
                                    Debug.WriteLine( "  My device detected" ); 
                                    
                                    //  Display the information in form's list box.
                                    
                                    lstResults.Items.Add( "Device detected:" );                                   
                                    lstResults.Items.Add("  Vendor ID= " + Convert.ToString(MyHid.DeviceAttributes.VendorID, 16));                                  
                                    lstResults.Items.Add("  Product ID = " + Convert.ToString(MyHid.DeviceAttributes.ProductID, 16));
                                    
                                    ScrollToBottomOfListBox();

                                    //times_found++;
                                    //if(times_found == 3)
                                        myDeviceDetected = true; 
                                    
                                    //  Save the DevicePathName for OnDeviceChange().
                                    
                                    myDevicePathName = devicePathName[ memberIndex ];

                                   //WARNING
                                    flag_DeviceConnected = true;
                                    
                                } 
                                else 
                                {                                     
                                    //  It's not a match, so close the handle.
                                    flag_DeviceConnected = false;
                                    myDeviceDetected = false;                                     
                                    hidHandle.Close();                                     
                                }                                 
                            } 
                            else 
                            { 
                                //  There was a problem in retrieving the information.
                                
                                Debug.WriteLine( "  Error in filling HIDD_ATTRIBUTES structure." ); 
                                myDeviceDetected = false; 
                                hidHandle.Close(); 
                            }                             
                        } 
                        
                        //  Keep looking until we find the device or there are no devices left to examine.
                        
                        memberIndex = memberIndex + 1;                         
                    } 
                    while (  ! ( ( myDeviceDetected || ( memberIndex == devicePathName.Length ) ) ) );                     
                } 
                
                if ( myDeviceDetected ) 
                {                     
                    //  The device was detected.
                    //  Register to receive notifications if the device is removed or attached.
                    
                    success = MyDeviceManagement.RegisterForDeviceNotifications( myDevicePathName, FrmMy.Handle, hidGuid, ref deviceNotificationHandle ); 
                    
                    Debug.WriteLine( "RegisterForDeviceNotifications = " + success ); 
                    
                    //  Learn the capabilities of the device.
                    
                    MyHid.Capabilities = MyHid.GetDeviceCapabilities( hidHandle ); 
                    
                    if ( success ) 
                    {                         
                        //  Find out if the device is a system mouse or keyboard.
                        
                        hidUsage = MyHid.GetHidUsage( MyHid.Capabilities ); 
                        
                        //  Get the Input report buffer size.
                        
                        GetInputReportBufferSize(); 
                        cmdInputReportBufferSize.Enabled = true; 
                        
                        //  Get handles to use in requesting Input and Output reports.

                        readHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_READ, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, FileIO.FILE_FLAG_OVERLAPPED, 0);

                        functionName = "CreateFile, ReadHandle";
                        Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName)); 
                        Debug.WriteLine( "  Returned handle: " + readHandle.ToString() ); 
                        
                        if ( readHandle.IsInvalid ) 
                        {                             
                            exclusiveAccess = true; 
                            lstResults.Items.Add( "The device is a system " + hidUsage + "." ); 
                            lstResults.Items.Add( "Windows 2000 and Windows XP obtain exclusive access to Input and Output reports for this devices." ); 
                            lstResults.Items.Add( "Applications can access Feature reports only." ); 
                            ScrollToBottomOfListBox();                             
                        } 
                        else 
                        {
                            writeHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_WRITE, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                            functionName = "CreateFile, WriteHandle";
                            Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName)); 
                            Debug.WriteLine( "  Returned handle: " + writeHandle.ToString() ); 
                            
                            //  Flush any waiting reports in the input buffer. (optional)
                            
                            MyHid.FlushQueue( readHandle );                             
                        } 
                    } 
                } 
                else 
                { 
                    //  The device wasn't detected.
                    
                    lstResults.Items.Add( "Device not found." ); 
                    cmdInputReportBufferSize.Enabled = false; 
                    cmdOnce.Enabled = true; 
                    
                    Debug.WriteLine( " Device not found." ); 
                    
                    ScrollToBottomOfListBox(); 
                }                 
                return myDeviceDetected;                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }         
        
        ///  <summary>
        ///  In asynchronous ReadFiles, the callback function GetInputReportData
        ///  uses this routine to access the application's form, which runs in 
        ///  a different thread.
        ///  The routine performs various application-specific functions that
        ///  involve accessing the application's form.
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form</param>
        ///  <param name="formText"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter. </param>
        
        private void AccessForm( String action, String formText ) 
        {             
            try 
            { 
                //  Select an action to perform on the form:
                
                switch ( action ) 
                {
                    case "AddItemToListBox":
                        
                        lstResults.Items.Add( formText ); 
                        
                        break;
                    case "AddItemToTextBox":
                        
                        txtBytesReceived.SelectedText = formText + "\r\n"; 
                        
                        break;
                    case "EnableCmdOnce":
                        
                        //  If it's a single transfer, re-enable the command button.
                        
                        if ( cmdContinuous.Text == "Continuous" ) 
                        { 
                            cmdOnce.Enabled = true; 
                        }                         
                        break;
                    case "ScrollToBottomOfListBox":
                        
                        lstResults.SelectedIndex = lstResults.Items.Count - 1; 
                        
                        break;
                    case "TextBoxSelectionStart":
                        
                        txtBytesReceived.SelectionStart = formText.Length; //System.Runtime.InteropServices.Marshal.SizeOf( formText ); 
                        
                        break;
                    default:
                        
                        break;
                } 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Start or stop a series of periodic transfers.
        ///  </summary>
        
        private void cmdContinuous_Click( System.Object eventSender, System.EventArgs eventArgs ) 
        {             
            try 
            { 
                if ( cmdContinuous.Text == "Continuous" ) 
                {                     
                    //  Start doing periodic transfers.
                    
                    if ( !( cmdOnce.Enabled ) ) 
                    {                         
                        AccessForm( "AddItemToListBox", "A previous transfer hasn't completed. Please try again." ); 
                    } 
                    else 
                    {                         
                        cmdOnce.Enabled = false; 
                        
                        //  Change the command button's text to "Cancel Continuous"
                        
                        cmdContinuous.Text = "Cancel Continuous"; 
                        
                        //  Enable the timer event to trigger a set of transfers.
                        
                        tmrContinuousDataCollect.Enabled = true; 
                        ReadAndWriteToDevice(); 
                    }                     
                } 
                else 
                {                     
                    //  Stop doing continuous transfers.
                    //  Change the command button's text to "Continuous"
                    
                    cmdContinuous.Text = "Continuous"; 
                    
                    // D isable the timer that triggers the transfers.
                    
                    tmrContinuousDataCollect.Enabled = false; 
                    
                    cmdOnce.Enabled = true; 
                }                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }         
        
        ///  <summary>
        ///  Set the number of Input reports the host will store.
        ///  </summary>
        
        private void cmdInputReportBufferSize_Click( System.Object sender, System.EventArgs e ) 
        {             
            try 
            { 
                SetInputReportBufferSize();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        } 
                
        ///  <summary>
        ///  Search for a specific device.
        ///  </summary>
        
        private void cmdFindDevice_Click( System.Object sender, System.EventArgs e ) 
        {            
            try 
            { 
                FindTheHid();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }

            if (flag_DeviceConnected == true)
                pctStatus.Image = Properties.Resources.apply_256;
            else 
                pctStatus.Image = Properties.Resources.cancel_256;
        }         
        
        ///  <summary>
        ///  Attempt to write a report and read a report.
        ///  </summary>
          
        private void cmdOnce_Click( System.Object eventSender, System.EventArgs eventArgs ) 
        {             
            
            try 
            { 
                //  Don't allow another transfer request until this one completes.
                //  Move the focus away from cmdOnce to prevent the focus from 
                //  switching to the next control in the tab order on disabling the button.
                
                fraSendAndReceive.Focus(); 
                cmdOnce.Enabled = false; 
                
                ReadAndWriteToDevice();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }        
        
        ///  <summary>
        ///  Called if the user changes the Vendor ID or Product ID in the text box.
        ///  </summary>
          
        private void DeviceHasChanged() 
        {             
            try 
            { 
                //  If a device was previously detected, stop receiving notifications about it.
                
                if ( myDeviceDetected ) 
                { 
                    MyDeviceManagement.StopReceivingDeviceNotifications( deviceNotificationHandle ); 
                } 
                
                //  Search for the device the next time FindTheHid is called.
                
                myDeviceDetected = false;                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }

        // OBTAIN DEVICE =========================================================================================
        public bool ObtainDevice()
        {
            // Report header for the debug display:

            Debug.WriteLine("");
            Debug.WriteLine("***** HID Test Report *****");
            Debug.WriteLine(DateAndTime.Today + ": " + DateAndTime.TimeOfDay);

            try
            {

                if ((myDeviceDetected == false))
                {
                    myDeviceDetected = FindTheHid();
                }
            }
            catch (Exception e)
            {
                // TODO
            }

            return myDeviceDetected;
        }

        // GET FEATURE REPORT ====================================================================================
        public bool GetFeatureReport(Byte reportID, ref Byte[] data, Int32 dataLength)
        {
            String byteValue = null;
            Int32 count = 0; 
            Byte[] inFeatureReportBuffer = null;
            Boolean success = false;

            try
            {
                Hid.InFeatureReport myInFeatureReport = new Hid.InFeatureReport();

                if ((MyHid.Capabilities.FeatureReportByteLength > 0))
                {
                    inFeatureReportBuffer = new Byte[dataLength + 1];

                    //  Read a report.

                    inFeatureReportBuffer[0] = reportID;

                    myInFeatureReport.Read(hidHandle, readHandle, writeHandle, ref myDeviceDetected, ref inFeatureReportBuffer, ref success);

                    if (success)
                    {
                        lstResults.Items.Add("A Feature report has been read.");

                        for (count = 1; count <= inFeatureReportBuffer.Length; count++)
                            data[count - 1] = inFeatureReportBuffer[count];

                        //  Display the report data received in the form's list box.

                        lstResults.Items.Add(" Feature Report ID: " + String.Format("{0:X2} ", inFeatureReportBuffer[0]));
                        lstResults.Items.Add(" Feature Report Data:");
                        txtBytesReceived.Text = "";

                        for (count = 0; count <= inFeatureReportBuffer.Length - 1; count++)
                        {

                            //  Display bytes as 2-character Hex strings.

                            byteValue = String.Format("{0:X2} ", inFeatureReportBuffer[count]);

                            lstResults.Items.Add(" " + byteValue);

                            //  Display the received bytes in the text box.

                            txtBytesReceived.SelectionStart = txtBytesReceived.Text.Length; //* TRANSINFO: .NET Equivalent of Microsoft.VisualBasic NameSpace */ System.Runtime.InteropServices.Marshal.SizeOf( txtBytesReceived.Text ); 
                            txtBytesReceived.SelectedText = byteValue + "\r\n";
                        }
                    }
                    else
                    {
                        lstResults.Items.Add("The attempt to read a Feature report failed.");
                    }
                }
            }
            catch (Exception e)
            {
                // TODO
            }

            return success;
        }

        // SET FEATURE REPORT ====================================================================================
        public bool SetFeatureReport(Byte reportID, Byte[] data, Int32 dataLength)
        {
            String byteValue = null;
            Int32 count = 0; 
            Byte[] outFeatureReportBuffer = null;
            Boolean success = false;

            try
            {

                Hid.OutFeatureReport myOutFeatureReport = new Hid.OutFeatureReport();

                if ((MyHid.Capabilities.FeatureReportByteLength > 0))
                {

                    outFeatureReportBuffer = new Byte[dataLength + 1];

                    //  Store the report ID in the buffer

                    outFeatureReportBuffer[0] = reportID;

                    //  Store the report data following the report ID.

                    for (count = 1; count <= dataLength; count++)
                        outFeatureReportBuffer[count] = Convert.ToByte(data[count - 1]);

                    //  Write a report to the device

                    success = myOutFeatureReport.Write(outFeatureReportBuffer, hidHandle);

                    if (success)
                    {
                        lstResults.Items.Add("A Feature report has been written.");

                        //  Display the report data sent in the form's list box.

                        lstResults.Items.Add(" Feature Report ID: " + String.Format("{0:X2} ", outFeatureReportBuffer[0]));
                        lstResults.Items.Add(" Feature Report Data:");

                        for (count = 0; count <= outFeatureReportBuffer.Length - 1; count++)
                        {
                            //  Display bytes as 2-character Hex strings.

                            byteValue = String.Format("{0:X2} ", outFeatureReportBuffer[count]);

                            lstResults.Items.Add(" " + byteValue);
                        }
                    }
                    else
                    {
                        lstResults.Items.Add("The attempt to write a Feature report failed.");
                    }
                }
            }
            catch (Exception e)
            {
                // TODO
            }

            return success;
        }
        
        ///  <summary>
        ///  Sends a Feature report, then retrieves one.
        ///  Assumes report ID = 0 for both reports.
        ///  </summary>
        
        private void ExchangeFeatureReports() 
        {             
            String byteValue = null; 
            Int32 count = 0; 
            Byte[] inFeatureReportBuffer = null; 
            Byte[] outFeatureReportBuffer = null; 
            Boolean success = false; 
            
            try 
            { 
                Hid.InFeatureReport myInFeatureReport = new Hid.InFeatureReport(); 
                Hid.OutFeatureReport myOutFeatureReport = new Hid.OutFeatureReport(); 
                
                inFeatureReportBuffer = null; 
                
                if ( ( MyHid.Capabilities.FeatureReportByteLength > 0 ) ) 
                {                     
                    //  The HID has a Feature report.
                    
                    //  Set the size of the Feature report buffer. 
                    //  Subtract 1 from the value in the Capabilities structure because 
                    //  the array begins at index 0.
                    
                    outFeatureReportBuffer = new Byte[ MyHid.Capabilities.FeatureReportByteLength ]; 
                    
                    //  Store the report ID in the buffer:
                    
                    //outFeatureReportBuffer[ 0 ] = 0; 
                    outFeatureReportBuffer[0] = 0x16; 
                    
                    //  Store the report data following the report ID.
                    //  Use the data in the combo boxes on the form.
                    
                    outFeatureReportBuffer[ 1 ] = Convert.ToByte( cboByte0.SelectedIndex ); 
                    
                    if ( Information.UBound( outFeatureReportBuffer, 1 ) > 1 ) 
                    { 
                        outFeatureReportBuffer[ 2 ] = Convert.ToByte( cboByte1.SelectedIndex ); 
                    } 
                    
                    //  Write a report to the device
                    
                    success = myOutFeatureReport.Write( outFeatureReportBuffer, hidHandle ); 
                    
                    if ( success ) 
                    { 
                        lstResults.Items.Add( "A Feature report has been written." ); 
                        
                        //  Display the report data sent in the form's list box.
                        
                        lstResults.Items.Add( " Feature Report ID: " + String.Format( "{0:X2} ", outFeatureReportBuffer[ 0 ] ) ); 
                        lstResults.Items.Add( " Feature Report Data:" ); 
                        
                        //for ( count=1; count <= Information.UBound( outFeatureReportBuffer, 1 ); count++ )
                        for (count = 0; count <= outFeatureReportBuffer.Length - 1; count++) 
                        {                             
                            //  Display bytes as 2-character Hex strings.
                            
                            byteValue = String.Format( "{0:X2} ", outFeatureReportBuffer[ count ] ); 
                            
                            lstResults.Items.Add( " " + byteValue );                             
                        } 
                    } 
                    else 
                    { 
                        lstResults.Items.Add( "The attempt to write a Feature report failed." ); 
                    } 
                    
                    //  Read a report from the device.
                    
                    //  Set the size of the Feature report buffer. 
                    //  Subtract 1 from the value in the Capabilities structure because 
                    //  the array begins at index 0.
                    
                    if ( ( MyHid.Capabilities.FeatureReportByteLength > 0 ) ) 
                    { 
                        inFeatureReportBuffer = new Byte[ MyHid.Capabilities.FeatureReportByteLength ]; 
                    } 
                    
                    //  Read a report.

                    inFeatureReportBuffer[0] = 0x16;
                    
                    myInFeatureReport.Read( hidHandle, readHandle, writeHandle, ref myDeviceDetected, ref inFeatureReportBuffer, ref success ); 
                    
                    if ( success ) 
                    { 
                        lstResults.Items.Add( "A Feature report has been read." ); 
                        
                        //  Display the report data received in the form's list box.
                        
                        lstResults.Items.Add( " Feature Report ID: " + String.Format( "{0:X2} ", inFeatureReportBuffer[ 0 ] ) ); 
                        lstResults.Items.Add( " Feature Report Data:" ); 
                        txtBytesReceived.Text = "";                         
                        
                        for (count = 0; count <= inFeatureReportBuffer.Length - 1; count++) 
                        { 
                            
                            //  Display bytes as 2-character Hex strings.
                            
                            byteValue = String.Format( "{0:X2} ", inFeatureReportBuffer[ count ] ); 
                            
                            lstResults.Items.Add( " " + byteValue ); 
                            
                            //  Display the received bytes in the text box.

                            txtBytesReceived.SelectionStart = txtBytesReceived.Text.Length; //* TRANSINFO: .NET Equivalent of Microsoft.VisualBasic NameSpace */ System.Runtime.InteropServices.Marshal.SizeOf( txtBytesReceived.Text ); 
                            txtBytesReceived.SelectedText = byteValue + "\r\n";                             
                        } 
                    } 
                    else 
                    { 
                        lstResults.Items.Add( "The attempt to read a Feature report failed." ); 
                    }                     
                } 
                else 
                { 
                    lstResults.Items.Add( "The HID doesn't have a Feature report." ); 
                } 
                
                ScrollToBottomOfListBox();                 
                cmdOnce.Enabled = true;                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Sends an Output report, then retrieves an Input report.
        ///  Assumes report ID = 0 for both reports.
        ///  </summary>
        
        private void ExchangeInputAndOutputReports() 
        {             
            String byteValue = null; 
            Int32 count = 0; 
            Byte[] inputReportBuffer = null; 
            Byte[] outputReportBuffer = null; 
            Boolean success = false; 
            
            try 
            { 
                success = false; 
                
                //  Don't attempt to exchange reports if valid handles aren't available
                //  (as for a mouse or keyboard under Windows 2000/XP.)
                
                if  ( !readHandle.IsInvalid && !writeHandle.IsInvalid )   
                {                    
                    //  Don't attempt to send an Output report if the HID has no Output report.
                    
                    if ( MyHid.Capabilities.OutputReportByteLength > 0 ) 
                    {                         
                        //  Set the size of the Output report buffer.   
					                        
                        outputReportBuffer = new Byte[ MyHid.Capabilities.OutputReportByteLength]; 
                        
                        //  Store the report ID in the first byte of the buffer:
                        
                        outputReportBuffer[ 0 ] = 0; 
                        
                        //  Store the report data following the report ID.
                        //  Use the data in the combo boxes on the form.
                        
                        outputReportBuffer[ 1 ] = Convert.ToByte( cboByte0.SelectedIndex ); 
                        
                        if ( Information.UBound( outputReportBuffer, 1 ) > 1 ) 
                        { 
                            outputReportBuffer[ 2 ] = Convert.ToByte( cboByte1.SelectedIndex ); 
                        } 
                        
                        //  Write a report.
                        
                        if ( ( chkUseControlTransfersOnly.Checked ) == true ) 
                        { 
                            
                            //  Use a control transfer to send the report,
                            //  even if the HID has an interrupt OUT endpoint.
                            
                            Hid.OutputReportViaControlTransfer myOutputReport = new Hid.OutputReportViaControlTransfer(); 
                            success = myOutputReport.Write( outputReportBuffer, writeHandle ); 
                        } 
                        else 
                        { 
                            
                            //  Use WriteFile to send the report.
                            //  If the HID has an interrupt OUT endpoint, WriteFile uses an 
                            //  interrupt transfer to send the report. 
                            //  If not, WriteFile uses a control transfer.
                            
                            Hid.OutputReportViaInterruptTransfer myOutputReport = new Hid.OutputReportViaInterruptTransfer(); 
                            success = myOutputReport.Write( outputReportBuffer, writeHandle ); 
                        }                         
                        
                        if ( success ) 
                        { 
                            lstResults.Items.Add( "An Output report has been written." ); 
                            
                            //  Display the report data in the form's list box.
                            
                            lstResults.Items.Add( " Output Report ID: " + String.Format( "{0:X2} ", outputReportBuffer[ 0 ] ) ); 
                            lstResults.Items.Add( " Output Report Data:" ); 
                            
                            txtBytesReceived.Text = ""; 
                            for ( count=0; count <= outputReportBuffer.Length -1; count++ ) 
                            { 
                                
                                //  Display bytes as 2-character hex strings.
                                
                                byteValue = String.Format( "{0:X2} ", outputReportBuffer[ count ] ); 
                                lstResults.Items.Add( " " + byteValue );                                 
                            }                             
                        } 
                        else 
                        { 
                            lstResults.Items.Add( "The attempt to write an Output report has failed." ); 
                        }                         
                    } 
                    else 
                    { 
                        lstResults.Items.Add( "The HID doesn't have an Output report." ); 
                    } 
                    
                    //  Read an Input report.
                    
                    success = false; 
                    
                    //  Don't attempt to send an Input report if the HID has no Input report.
                    //  (The HID spec requires all HIDs to have an interrupt IN endpoint,
                    //  which suggests that all HIDs must support Input reports.)
                    
                    if ( MyHid.Capabilities.InputReportByteLength > 0 ) 
                    {                         
                        //  Set the size of the Input report buffer. 
                                                
                        inputReportBuffer = new Byte[ MyHid.Capabilities.InputReportByteLength ]; 
                        
                        if ( chkUseControlTransfersOnly.Checked ) 
                        {                             
                            //  Read a report using a control transfer.
                            
                            Hid.InputReportViaControlTransfer myInputReport = new Hid.InputReportViaControlTransfer(); 
                            
                            //  Read the report.
                            
                            myInputReport.Read( hidHandle, readHandle, writeHandle, ref myDeviceDetected, ref inputReportBuffer, ref success ); 
                            
                            if ( success ) 
                            { 
                                lstResults.Items.Add( "An Input report has been read." ); 
                                
                                //  Display the report data received in the form's list box.
                                
                                lstResults.Items.Add( " Input Report ID: " + String.Format( "{0:X2} ", inputReportBuffer[ 0 ] ) ); 
                                lstResults.Items.Add( " Input Report Data:" ); 
                                
                                txtBytesReceived.Text = ""; 
                          
                                for ( count = 0; count <= inputReportBuffer.Length -1; count++)  
                                {                                     
                                    //  Display bytes as 2-character Hex strings.
                                    
                                    byteValue = String.Format( "{0:X2} ", inputReportBuffer[ count ] ); 
                                    
                                    lstResults.Items.Add( " " + byteValue ); 
                                    
                                    //  Display the received bytes in the text box.

                                    txtBytesReceived.SelectionStart = txtBytesReceived.Text.Length; ///* TRANSINFO: .NET Equivalent of Microsoft.VisualBasic NameSpace */ System.Runtime.InteropServices.Marshal.SizeOf(txtBytesReceived.Text); 
                                    txtBytesReceived.SelectedText = byteValue + "\r\n"; 
                                } 
                            } 
                            else 
                            { 
                                lstResults.Items.Add( "The attempt to read an Input report has failed." );                                 
                            } 
                            
                            ScrollToBottomOfListBox(); 
                            
                            //  Enable requesting another transfer.
                            
                            AccessForm( "EnableCmdOnce", "" );                             
                        } 
                        else 
                        { 
                            //  Read a report using interrupt transfers.                
                            //  To enable reading a report without blocking the main thread, this
                            //  application uses an asynchronous delegate.
                            
                            IAsyncResult ar = null; 
                            Hid.InputReportViaInterruptTransfer myInputReport = new Hid.InputReportViaInterruptTransfer(); 
                            
                            //  Define a delegate for the Read method of myInputReport.
                            
                            ReadInputReportDelegate MyReadInputReportDelegate = new ReadInputReportDelegate( myInputReport.Read ); 
                            
                            //  The BeginInvoke method calls myInputReport.Read to attempt to read a report.
                            //  The method has the same parameters as the Read function,
                            //  plus two additional parameters:
                            //  GetInputReportData is the callback procedure that executes when the Read function returns.
                            //  MyReadInputReportDelegate is the asynchronous delegate object.
                            //  The last parameter can optionally be an object passed to the callback.
                            
                            ar = MyReadInputReportDelegate.BeginInvoke( hidHandle, readHandle, writeHandle, ref myDeviceDetected, ref inputReportBuffer, ref success, new AsyncCallback( GetInputReportData ), MyReadInputReportDelegate ); 
                        }                         
                    } 
                    else 
                    { 
                        lstResults.Items.Add( "No attempt to read an Input report was made." ); 
                        lstResults.Items.Add( "The HID doesn't have an Input report." ); 
                    } 
                } 
                else 
                { 
                    lstResults.Items.Add( "Invalid handle. The device is probably a system mouse or keyboard." ); 
                    lstResults.Items.Add( "No attempt to write an Output report or read an Input report was made." );                     
                }                 
                ScrollToBottomOfListBox();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Perform shutdown operations.
        ///  </summary>
        
        private void frmMain_Closed( System.Object eventSender, System.EventArgs eventArgs ) 
        {             
            try 
            { 
                Shutdown();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }         
        
        ///  <summary>
        ///  Perform startup operations.
        ///  </summary>
        
        private void frmMain_Load( System.Object eventSender, System.EventArgs eventArgs ) 
        {             
            try 
            { 
                FrmMy = this; 
                Startup();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }

            button1_Click(null, null);
            ckbAutoReveal.Checked = true;
        }         
        
        ///  <summary>
        ///  Finds and displays the number of Input buffers
        ///  (the number of Input reports the host will store). 
        ///  </summary>
        
        private void GetInputReportBufferSize() 
        {             
            Int32 numberOfInputBuffers = 0;
            Boolean success;
            
            try 
            { 
                //  Get the number of input buffers.
                
               success =  MyHid.GetNumberOfInputBuffers( hidHandle, ref numberOfInputBuffers ); 
                
                //  Display the result in the text box.
                
                txtInputReportBufferSize.Text = Convert.ToString( numberOfInputBuffers );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Retrieves Input report data and status information.
        ///  This routine is called automatically when myInputReport.Read
        ///  returns. Calls several marshaling routines to access the main form.
        ///  </summary>
        ///  
        ///  <param name="ar"> an object containing status information about 
        ///  the asynchronous operation. </param>
        
        private void GetInputReportData( IAsyncResult ar ) 
        {             
            String byteValue = null; 
            Int32 count = 0; 
            Byte[] inputReportBuffer = null; 
            Boolean success = false; 
            
            try 
            { 
                // Define a delegate using the IAsyncResult object.
                
                ReadInputReportDelegate deleg = ( ( ReadInputReportDelegate )( ar.AsyncState ) ); 
                
                //  Get the IAsyncResult object and the values of other paramaters that the
                //  BeginInvoke method passed ByRef.
                
                deleg.EndInvoke( ref myDeviceDetected, ref inputReportBuffer, ref success, ar ); 
                
                //  Display the received report data in the form's list box.
                
                if ( ( ar.IsCompleted && success ) ) 
                { 
                    
                    MyMarshalToForm( "AddItemToListBox", "An Input report has been read." );                     
                    MyMarshalToForm( "AddItemToListBox", " Input Report ID: " + String.Format( "{0:X2} ", inputReportBuffer[ 0 ] ) );                     
                    MyMarshalToForm( "AddItemToListBox", " Input Report Data:" ); 
                    
                    for ( count=0; count <= inputReportBuffer.Length -1 ; count++ ) 
                    {                         
                        //  Display bytes as 2-character Hex strings.
                        
                        byteValue = String.Format( "{0:X2} ", inputReportBuffer[ count ] ); 
                        
                        MyMarshalToForm( "AddItemToListBox", " " + byteValue ); 
                        MyMarshalToForm( "TextBoxSelectionStart", txtBytesReceived.Text ); 
                        MyMarshalToForm( "AddItemToTextBox", byteValue );                         
                    }                     
                } 
                else 
                { 
                    MyMarshalToForm( "AddItemToListBox", "The attempt to read an Input report has failed." ); 
                    Debug.Write( "The attempt to read an Input report has failed" ); 
                } 
                
                MyMarshalToForm( "ScrollToBottomOfListBox", "" ); 
                
                //  Enable requesting another transfer.
                
                MyMarshalToForm( "EnableCmdOnce", "" );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Retrieves a Vendor ID and Product ID in hexadecimal 
        ///  from the form's text boxes and converts the text to Int16s.
        ///  </summary>
        ///  
        ///  <param name="myVendorID"> the Vendor ID as a Int16.</param>
        ///  <param name="myProductID"> the Product ID as a Int16. </param>
        
        private void GetVendorAndProductIDsFromTextBoxes( ref Int16 myVendorID, ref Int16 myProductID ) 
        {             
            try 
            { 
                myVendorID = Convert.ToInt16( Conversion.Val( "&h" + txtVendorID.Text ) ); 
                myProductID = Convert.ToInt16( Conversion.Val( "&h" + txtProductID.Text ) );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Initialize the elements on the form.
        ///  </summary>
          
        private void InitializeDisplay() 
        {           
            Int16 count = 0; 
            String byteValue = null; 
            
            try 
            { 
                //  Create a dropdown list box for each byte to send in a report.
                //  Display the values as 2-character hex strings.
                
                for ( count=0; count <= 255; count++ ) 
                {                     
                    byteValue = String.Format( "{0:X2} ", count ); 
                    FrmMy.cboByte0.Items.Insert( count, byteValue ); 
                    FrmMy.cboByte1.Items.Insert( count, byteValue );                     
                } 
                
                //  Select a default value for each box
                
                FrmMy.cboByte0.SelectedIndex = 0; 
                FrmMy.cboByte1.SelectedIndex = 128; 
                
                //  Check the autoincrement box to increment the values each time a report is sent.
                
                chkAutoincrement.CheckState = System.Windows.Forms.CheckState.Checked; 
                
                //  Don't allow the user to select an input report buffer size until there is
                //  a handle to a HID.
                
                cmdInputReportBufferSize.Focus(); 
                cmdInputReportBufferSize.Enabled = false; 
                
                if ( MyHid.IsWindowsXpOrLater() ) 
                {                     
                    chkUseControlTransfersOnly.Enabled = true;                     
                } 
                else 
                { 
                    //  If the operating system is earlier than Windows XP,
                    //  disable the option to force Input and Output reports to use control transfers.
                    
                    chkUseControlTransfersOnly.Enabled = false;                     
                } 
                
                lstResults.Items.Add( "For a more detailed event log, view debug statements in Visual Studio's Output window:" ); 
                lstResults.Items.Add( "Click Build > Configuration Manager > Active Solution Configuration > Debug > Close." ); 
                lstResults.Items.Add( "Then click View > Output." ); 
                lstResults.Items.Add( "" );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Enables accessing a form's controls from another thread 
        ///  </summary>
        ///  
        ///  <param name="action"> a String that names the action to perform on the form </param>
        ///  <param name="textToDisplay"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter.  </param>
        
        private void MyMarshalToForm( String action, String textToDisplay ) 
        {             
            object[] args = { action, textToDisplay }; 
            MarshalToForm MarshalToFormDelegate = null; 
            
            //  The AccessForm routine contains the code that accesses the form.
            
            MarshalToFormDelegate = new MarshalToForm( AccessForm ); 
            
            //  Execute AccessForm, passing the parameters in args.
            
            base.Invoke( MarshalToFormDelegate, args );             
        }         
        
        ///  <summary>
        ///  Initiates exchanging reports. 
        ///  The application sends a report and requests to read a report.
        ///  </summary>
        
        private void ReadAndWriteToDevice() 
        {             
            // Report header for the debug display:
            
            Debug.WriteLine( "" ); 
            Debug.WriteLine( "***** HID Test Report *****" ); 
            Debug.WriteLine( DateAndTime.Today + ": " + DateAndTime.TimeOfDay ); 
            
            try 
            { 
                //  If the device hasn't been detected, was removed, or timed out on a previous attempt
                //  to access it, look for the device.
                
                if ( ( myDeviceDetected == false ) ) 
                {                     
                    myDeviceDetected = FindTheHid();                     
                } 
                
                if ( ( myDeviceDetected == true ) ) 
                {                     
                    //  Get the bytes to send in a report from the combo boxes.
                    //  Increment the values if the autoincrement check box is selected.
                    
                    if ( Convert.ToDouble( chkAutoincrement.CheckState ) == 1 ) 
                    { 
                        if ( cboByte0.SelectedIndex < 255 ) 
                        { 
                            cboByte0.SelectedIndex = cboByte0.SelectedIndex + 1; 
                        } 
                        else 
                        { 
                            cboByte0.SelectedIndex = 0; 
                        } 
                        if ( cboByte1.SelectedIndex < 255 ) 
                        { 
                            cboByte1.SelectedIndex = cboByte1.SelectedIndex + 1; 
                        } 
                        else 
                        { 
                            cboByte1.SelectedIndex = 0; 
                        } 
                    } 
                    
                    //  An option button selects whether to exchange Input and Output reports
                    //  or Feature reports.
                    
                    if ( ( optInputOutput.Checked == true ) ) 
                    {                        
                        ExchangeInputAndOutputReports();                        
                    } 
                    else 
                    { 
                        ExchangeFeatureReports(); 
                    }                     
                }                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        } 
                
        ///  <summary>
        ///  Scroll to the bottom of the list box and trim as needed.
        ///  </summary>
        
        private void ScrollToBottomOfListBox() 
        {            
            try 
            { 
                Int32 count = 0; 
                
                lstResults.SelectedIndex = lstResults.Items.Count - 1; 
                
                //  If the list box is getting too large, trim its contents by removing the earliest data.
                
                if ( lstResults.Items.Count > 1000 ) 
                {                     
                    for ( count=1; count <= 500; count++ ) 
                    { 
                        lstResults.Items.RemoveAt( 4 ); 
                    }                    
                }                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        } 
                
        ///  <summary>
        ///  Set the number of Input buffers (the number of Input reports 
        ///  the host will store) from the value in the text box.
        ///  </summary>
        
        private void SetInputReportBufferSize() 
        {             
            Int32 numberOfInputBuffers = 0; 
            
            try 
            { 
                //  Get the number of buffers from the text box.
                
                numberOfInputBuffers = Convert.ToInt32( Conversion.Val( txtInputReportBufferSize.Text ) ); 
                
                //  Set the number of buffers.
                
                MyHid.SetNumberOfInputBuffers( hidHandle, numberOfInputBuffers ); 
                
                //  Verify and display the result.
                
                GetInputReportBufferSize();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        }         
        
        ///  <summary>
        ///  Perform actions that must execute when the program ends.
        ///  </summary>
        
        private void Shutdown() 
        {             
            try 
            { 
                //  Close open handles to the device.
                
                if ( !( hidHandle == null ) ) 
                { 
                    if ( !( hidHandle.IsInvalid ) ) 
                    { 
                        hidHandle.Close(); 
                    } 
                } 
                
                if ( !( readHandle == null ) ) 
                { 
                    if ( !( readHandle.IsInvalid ) ) 
                    { 
                        readHandle.Close(); 
                    } 
                } 
                
                if ( !( writeHandle == null ) ) 
                { 
                    if ( !( writeHandle.IsInvalid ) ) 
                    { 
                        writeHandle.Close(); 
                    } 
                } 
                
                //  Stop receiving notifications.
                
                MyDeviceManagement.StopReceivingDeviceNotifications( deviceNotificationHandle );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        } 
                
        ///  <summary>
        ///  Perform actions that must execute when the program starts.
        ///  </summary>
        
        private void Startup() 
        {            
            try 
            { 
                MyHid = new Hid(); 
                InitializeDisplay(); 
                tmrContinuousDataCollect.Enabled = false; 
                tmrContinuousDataCollect.Interval = 1000; 
    
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Exchange data with the device.
        ///  </summary>
        ///  
        ///  <remarks>
        ///  The timer is enabled only if cmdContinous has been clicked, 
        ///  selecting continous (periodic) transfers.
        ///  </remarks>
        
        private void tmrContinuousDataCollect_Tick( System.Object eventSender, System.EventArgs eventArgs ) 
        {             
            try 
            { 
                ReadAndWriteToDevice();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        } 
                
        ///  <summary>
        ///  The Product ID has changed in the text box. Call a routine to handle it.
        ///  </summary>
        
        private void txtProductID_TextChanged( System.Object sender, System.EventArgs e ) 
        {            
            try 
            { 
                DeviceHasChanged();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            } 
        } 
                
        ///  <summary>
        ///  The Vendor ID has changed in the text box. Call a routine to handle it.
        ///  </summary>
        
        private void txtVendorID_TextChanged( System.Object sender, System.EventArgs e ) 
        {            
            try 
            { 
                DeviceHasChanged();                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Finalize method.
        ///  </summary>
        
        ~TopoTester() 
        { 
        } 
                
        ///  <summary>
        ///   Overrides WndProc to enable checking for and handling WM_DEVICECHANGE messages.
        ///  </summary>
        ///  
        ///  <param name="m"> a Windows Message </param>
        
        protected override void WndProc( ref Message m ) 
        {            
            try 
            { 
                //  The OnDeviceChange routine processes WM_DEVICECHANGE messages.
                
                if ( m.Msg == DeviceManagement.WM_DEVICECHANGE ) 
                { 
                    OnDeviceChange( m ); 
                } 
                
                //  Let the base form process the message.
                
                base.WndProc( ref m );                 
            } 
            catch ( Exception ex ) 
            { 
                DisplayException( this.Name, ex ); 
                throw ; 
            }             
        }         
        
        ///  <summary>
        ///  Provides a central mechanism for exception handling.
        ///  Displays a message box that describes the exception.
        ///  </summary>
        ///  
        ///  <param name="moduleName"> the module where the exception occurred. </param>
        ///  <param name="e"> the exception </param>
        
        internal static void DisplayException( String moduleName, Exception e ) 
        {             
            String message = null; 
            String caption = null; 
            
            //  Create an error message.
            
            message = "Exception: " + e.Message + ControlChars.CrLf + "Module: " + moduleName + ControlChars.CrLf + "Method: " + e.TargetSite.Name; 
            
            caption = "Unexpected Exception"; 
            
            MessageBox.Show( message, caption, MessageBoxButtons.OK ); 
            Debug.Write( message );             
        } 
                
        [STAThread]
        internal static void Main() { Application.Run( new TopoTester() ); }       
        private static TopoTester transDefaultFormFrmMain = null;
        internal static TopoTester TransDefaultFormFrmMain
        { 
        	get
        	{ 
        		if (transDefaultFormFrmMain == null)
        		{
        			transDefaultFormFrmMain = new TopoTester();
        		}
        		return transDefaultFormFrmMain;
        	} 
        }
       
        private void btnCalibrazione_Click(object sender, EventArgs e)
        {
            if (isConnectedTest("Non è possibile effettuare la calibrazione se il dispositivo è disconnesso"))
            {
                Int16 myVID = 0;
                Int16 myPID = 0;
                GetVendorAndProductIDsFromTextBoxes(ref myVID, ref myPID);
                c = new Calibrazione(myVID, myPID);
                c.GetCurrentValues();
                c.Show(this);
            }
        }

        private bool isConnectedTest(string Message)
        {
            if (flag_DeviceConnected) return true;
            MessageBox.Show(this, Message, "Errore di connessione", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return false;
        
        }

        private void ckbAutoReveal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAutoReveal.Checked == true)
            {
                cmdFindDevice.Enabled = false;
                
            }
            else
            {
                cmdFindDevice.Enabled = true;
            }
        }

        Boolean isAdvanced = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (isAdvanced)
            {
                this.gpbAdvanced.Visible = false;
                button1.Text = "Standard";
            } else {
                this.gpbAdvanced.Visible = true;
                button1.Text = "Avanzata (MadMouse)";
            }
            isAdvanced = !isAdvanced;

            this.PerformAutoScale();


        }

  

  

     

 


   


 
    }      
} 
