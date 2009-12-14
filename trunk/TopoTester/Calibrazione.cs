using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace GenericHid
{

    public partial class Calibrazione : Form
    {

        Color OK_COLOR = Color.PaleGreen;
        Color KO_COLOR = Color.LightCoral;


        Matrix topoMatrix = new Matrix(1,0,0,1,0,0);

        HIDCommunications hidComm;

        Byte[] shakeByte = new Byte[3];

        public Calibrazione(Int16 PID, Int16 VID)
        {
            InitializeComponent();
            hidComm = HIDCommunications.getInstance();
            hidComm.FindTheHid(PID, VID);
        }

        public Calibrazione()
        {
            InitializeComponent();
            hidComm = HIDCommunications.getInstance();
            hidComm.FindTheHid(0x04d8, 0x0012);
        }

        private void tkbDx_Scroll(object sender, EventArgs e)
        {
            txtX.Text = tkbDx.Value.ToString();        
        }

        private void tkbDy_Scroll(object sender, EventArgs e)
        {
            txtY.Text = tkbDy.Value.ToString();
        }


        /**
         * Funzioni di conversione gradi/radianti
        */

        // Angolo_gradi : 360 = Angolo_radianti : 2 π 
        private double radFromGrad(int angolo_gradi)
        {
            return (angolo_gradi * 2 * Math.PI / 360); 
        }
        private double radFromGrad(double angolo_gradi)
        {
            return (angolo_gradi * 2 * Math.PI / 360);
        }
       
        private int gradFromRad(double angolo_radianti)
        {
            double risultato = (angolo_radianti * 180.0 / Math.PI);
            return (int) risultato;
        }

        private void angleSelector_AngleChanged()
        {
            int angle = angleSelector.Angle;
            //if (angle < 0) angle += 360;
            txtGrad.Text = angle.ToString();
            txtRad.Text = radFromGrad(angle).ToString("N2");
        }

        private void Calibrazione_Load(object sender, EventArgs e)
        {
            txtX.Text = tkbDx.Value.ToString();
            txtY.Text = tkbDy.Value.ToString();
            angleSelector_AngleChanged();
            tkbScalamentoX_Scroll(sender, e);
            tkbScalamentoY_Scroll(sender, e);
            txtMx.BackColor = OK_COLOR;
            txtMy.BackColor = OK_COLOR;
            tttInfo.Active = true;
        }

        // Get current Values
        public void GetCurrentValues()
        {

            // Offset
            Byte[] offsetXY_ByteArray = new Byte[4];
            hidComm.GetFeatureReport(0x13, ref offsetXY_ByteArray, offsetXY_ByteArray.Length);
            Byte[] offsetX = new Byte[2];
            Byte[] offsetY = new Byte[2];
            offsetX[1] = offsetXY_ByteArray[0];
            offsetX[0] = offsetXY_ByteArray[1];
            offsetY[1] = offsetXY_ByteArray[2];
            offsetY[0] = offsetXY_ByteArray[3];
            Int16 offsetX_int = BitConverter.ToInt16(offsetX, 0);
            Int16 offsetY_int = BitConverter.ToInt16(offsetY, 0);
            txtX.Text = offsetX_int.ToString();
            txtY.Text = offsetY_int.ToString();

            // Gain
            Byte[] gainXY_ByteArray = new Byte[4];
            hidComm.GetFeatureReport(0x25, ref gainXY_ByteArray, gainXY_ByteArray.Length);
            Byte[] gainX = new Byte[2];
            Byte[] gainY = new Byte[2];
            gainX[1] = gainXY_ByteArray[0];
            gainX[0] = gainXY_ByteArray[1];
            gainY[1] = gainXY_ByteArray[2];
            gainY[0] = gainXY_ByteArray[3];
            Int16 gainX_int = BitConverter.ToInt16(gainX, 0);
            Int16 gainY_int = BitConverter.ToInt16(gainY, 0);
            float gainX_f = gainX_int;
            float gainY_f = gainY_int;
            gainX_f = gainX_f / 10;
            gainY_f = gainY_f / 10;
            gainX_int = (Int16)gainX_f;
            gainY_int = (Int16)gainY_f;
            txtMx.Text = (gainX_f / 10).ToString();
            txtMy.Text = (gainY_f / 10).ToString();

            // Angle
            Byte[] rotazione_ByteArray = new Byte[8];
            hidComm.GetFeatureReport(0x26, ref rotazione_ByteArray, rotazione_ByteArray.Length);
            Byte[] cosT = new Byte[2];
            Byte[] msinT = new Byte[2];
            cosT[1] = rotazione_ByteArray[0];
            cosT[0] = rotazione_ByteArray[1];
            msinT[1] = rotazione_ByteArray[2];
            msinT[0] = rotazione_ByteArray[3];
            Int16 cosT_int = BitConverter.ToInt16(cosT, 0);
            Int16 msinT_int = BitConverter.ToInt16(msinT, 0);
            float cosT_f = cosT_int;
            float msinT_f = msinT_int;
            cosT_f = cosT_f / 100;
            msinT_f = -msinT_f / 100;
            txtGrad.Text = (gradFromRad(Math.Acos(cosT_f)) * ((Math.Asin(msinT_f) < 0) ? -1 : 1)).ToString();

            // Mirroring
            Byte[] mirroring_ByteArray = new Byte[1];
            hidComm.GetFeatureReport(0x21, ref mirroring_ByteArray, mirroring_ByteArray.Length);
            switch (mirroring_ByteArray[0])
            {
                case 3:
                    cb_mirrorX.Checked = true;
                    cb_mirrorY.Checked = true;
                    break;
                case 2:
                    cb_mirrorX.Checked = false;
                    cb_mirrorY.Checked = true;
                    break;
                case 1:
                    cb_mirrorX.Checked = true;
                    cb_mirrorY.Checked = false;
                    break;
                case 0:
                    cb_mirrorX.Checked = false;
                    cb_mirrorY.Checked = false;
                    break;
                default:
                    break;
            }            

        }

        private void txtX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result = int.Parse(txtX.Text);
                if ((result > tkbDx.Maximum) || (result < tkbDx.Minimum))
                    throw new System.OverflowException();
                tkbDx.Value = result;
                txtX.BackColor = OK_COLOR;
            }
            catch (System.Exception)
            {
                txtX.BackColor = KO_COLOR;
            }
   
         }

        private void txtY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tkbDy.Value = int.Parse(txtY.Text);
                txtY.BackColor = OK_COLOR;
            }
            catch (System.Exception)
            {
                txtY.BackColor = KO_COLOR;
            }
        }

        private void txtGrad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int result = int.Parse(txtGrad.Text.ToString());
                angleSelector.Angle = result;
                txtGrad.BackColor = OK_COLOR;
            }
            catch (System.Exception)
            {
                txtGrad.BackColor = KO_COLOR;
            }
            txtRad.BackColor = txtGrad.BackColor;
        }

        private bool generaMatrice()
        {

            if ((txtGrad.BackColor == OK_COLOR) && (txtX.BackColor == OK_COLOR) && (txtY.BackColor == OK_COLOR))
            {
                topoMatrix.Rotate(float.Parse(txtGrad.Text.ToString()));
                return true;
            }
            return false;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Byte[] write_ByteArray = new Byte[1];
            write_ByteArray[0] = 0x00;
            hidComm.SetFeatureReport(0x15, write_ByteArray, write_ByteArray.Length);
            GetCurrentValues();
        }

        private Boolean checkvalues()
        {
            if(txtX.BackColor == KO_COLOR)
                return false;
            if(txtY.BackColor == KO_COLOR)
                return false;
            if(txtGrad.BackColor == KO_COLOR)
                return false;
            return true;
        }

        private void btnAnteprima_Click(object sender, EventArgs e)
        {
            if (!checkvalues())
                return;

            float buffer;
            Byte[] buf_byte;
            Int16 i, buf_int;
            UInt16 buf_uint;

            // Feature ROTAZIONE
            // Byte (feature id) + 4*Int16 (per la rotazione) *100

            Byte[] rotazione_ByteArray = new Byte[8];

            // Byte #0, #1
            buffer = (float) Math.Cos(float.Parse(txtRad.Text)) * 100;
            buf_int = (Int16)buffer;
            buf_byte = BitConverter.GetBytes(buf_int);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(rotazione_ByteArray, 0);

            // Byte #2, #3
            buffer = (float) -Math.Sin(float.Parse(txtRad.Text)) * 100;
            buf_int = (Int16)buffer;
            buf_byte = BitConverter.GetBytes(buf_int);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(rotazione_ByteArray, 2);

            // Byte #4, #5
            buffer = (float) Math.Sin(float.Parse(txtRad.Text)) * 100;
            buf_int = (Int16)buffer;
            buf_byte = BitConverter.GetBytes(buf_int);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(rotazione_ByteArray, 4);

            // Byte #6, #7
            buffer = (float) Math.Cos(float.Parse(txtRad.Text)) * 100;
            buf_int = (Int16)buffer;
            buf_byte = BitConverter.GetBytes(buf_int);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(rotazione_ByteArray, 6);

            hidComm.SetFeatureReport(0x26, rotazione_ByteArray, rotazione_ByteArray.Length);

            // Feature OFFSET
            // Byte (feature id) + 2*int16 (offset)

            Byte[] offset_ByteArray = new Byte[4];

            Int16 xOffset = (Int16)float.Parse(txtX.Text);
            buf_byte = BitConverter.GetBytes(xOffset);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(offset_ByteArray, 0);

            Int16 yOffset = (Int16)float.Parse(txtY.Text);
            buf_byte = BitConverter.GetBytes(yOffset);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(offset_ByteArray, 2);

            hidComm.SetFeatureReport(0x13, offset_ByteArray, offset_ByteArray.Length);

            // Feature SCALING
            // Byte (feature id) + 2*int16 (offset) * 100 (RANGE: 0.1 a 10)

            Byte[] scalamento_ByteArray = new Byte[4];
            
            buffer = float.Parse(txtMx.Text.ToString()) * 100;
            buf_uint = (UInt16)buffer;
            buf_byte = BitConverter.GetBytes(buf_uint);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(scalamento_ByteArray, 0);

            buffer = float.Parse(txtMy.Text.ToString()) * 100;
            buf_uint = (UInt16)buffer;
            buf_byte = BitConverter.GetBytes(buf_uint);
            Array.Reverse(buf_byte);
            buf_byte.CopyTo(scalamento_ByteArray, 2);

            hidComm.SetFeatureReport(0x25, scalamento_ByteArray, scalamento_ByteArray.Length);

            // Feature MIRROR

            Byte[] mirroring_ByteArray = new Byte[1];

            mirroring_ByteArray[0] = 0;
            if (cb_mirrorX.Checked)
                mirroring_ByteArray[0] += 1;
            if (cb_mirrorY.Checked)
                mirroring_ByteArray[0] += 2;
            hidComm.SetFeatureReport(0x21, mirroring_ByteArray, mirroring_ByteArray.Length);
               

        }

        private void btnScrivi_Click(object sender, EventArgs e)
        {
            Byte[] write_ByteArray = new Byte[1];
            write_ByteArray[0] = 0x01;
            hidComm.SetFeatureReport(0x15, write_ByteArray, write_ByteArray.Length);
        }

        private void tkbScalamentoY_Scroll(object sender, EventArgs e)
        {
            float val = tkbScalamentoY.Value;
            val = val / 10;
            txtMy.Text = val.ToString();

        }

        private void tkbScalamentoX_Scroll(object sender, EventArgs e)
        {
            float val = tkbScalamentoX.Value;
            val = val / 10;
            txtMx.Text = val.ToString();
        }

        private void ottieniOffsetCorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gpbOffset_Enter(object sender, EventArgs e)
        {

        }


        private void azioniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtMx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float result = float.Parse(txtMx.Text);
                if ((result > (tkbScalamentoX.Maximum / 10)) || (result < (tkbScalamentoX.Minimum / 10)))
                    throw new System.OverflowException();
                result = result * 10;
                int result_int = int.Parse(result.ToString());
                tkbScalamentoX.Value = result_int;
                txtMx.BackColor = OK_COLOR;
            }
            catch (System.Exception)
            {
                txtMx.BackColor = KO_COLOR;
            }
        }

        private void txtMy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float result = float.Parse(txtMy.Text);
                if ((result > (tkbScalamentoY.Maximum / 10)) || (result < (tkbScalamentoY.Minimum / 10)))
                    throw new System.OverflowException();
                result = result * 10;
                int result_int = int.Parse(result.ToString());
                tkbScalamentoY.Value = result_int;
                txtMy.BackColor = OK_COLOR;
            }
            catch (System.Exception)
            {
                txtMy.BackColor = KO_COLOR;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            KeyboardSetter c = new KeyboardSetter();
            c.Show(this);
                
        }

        public void shakeSet(Byte[] sba)
        {
            hidComm.GetFeatureReport(0x1e, ref sba, sba.Length);
        }

        private void CancelExit_Click(object sender, EventArgs e)
        {
            this.btnCancel_Click(null,null);
            this.Close();
        }

        private void auto_offset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dall'istante della pressione del tasto OK, dopo 2 secondi verrà memorizzata la posizione del mouse e ottenuti i valori di offset corrispondenti.\nIl mouse non sarà operativo in tale intervallo di tempo.");

            // Non muovere il mouse
            Byte[] isCalibrating_ByteArray = new Byte[1];
            isCalibrating_ByteArray[0] = 1;
            hidComm.SetFeatureReport(0x20, isCalibrating_ByteArray, isCalibrating_ByteArray.Length);

            // Ottieni X e Y correnti
            System.Threading.Thread.Sleep(2000);
            Byte[] rawXY_ByteArray = new Byte[4];
            hidComm.GetFeatureReport(0x14, ref rawXY_ByteArray, rawXY_ByteArray.Length);
            Byte[] rawX = new Byte[2];
            Byte[] rawY = new Byte[2];
            rawX[1] = rawXY_ByteArray[0];
            rawX[0] = rawXY_ByteArray[1];
            rawY[1] = rawXY_ByteArray[2];
            rawY[0] = rawXY_ByteArray[3];
            UInt16 rawX_uint = BitConverter.ToUInt16(rawX, 0);
            UInt16 rawY_uint = BitConverter.ToUInt16(rawY, 0);

            // Ottieni Pivot X e Pivot Y
            Byte[] pivotXY_ByteArray = new Byte[4];
            hidComm.GetFeatureReport(0x27, ref pivotXY_ByteArray, pivotXY_ByteArray.Length);
            Byte[] pivotX = new Byte[2];
            Byte[] pivotY = new Byte[2];
            pivotX[1] = pivotXY_ByteArray[0];
            pivotX[0] = pivotXY_ByteArray[1];
            pivotY[1] = pivotXY_ByteArray[2];
            pivotY[0] = pivotXY_ByteArray[3];
            UInt16 pivotX_uint = BitConverter.ToUInt16(pivotX, 0);
            UInt16 pivotY_uint = BitConverter.ToUInt16(pivotY, 0);

            // Ottieni Offset X e Offset Y
            Int16 offsetX = (Int16)(rawX_uint - pivotX_uint);
            Int16 offsetY = (Int16)(rawY_uint - pivotY_uint);

            txtX.Text = offsetX.ToString();
            txtY.Text = offsetY.ToString();

            isCalibrating_ByteArray[0] = 0;
            hidComm.SetFeatureReport(0x20, isCalibrating_ByteArray, isCalibrating_ByteArray.Length);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }





    }

}
