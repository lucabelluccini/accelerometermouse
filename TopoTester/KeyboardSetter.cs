using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenericHid
{
    public partial class KeyboardSetter : Form
    {

        string keySet_1, keySet_2;

        DefinesAndConstants dac = new DefinesAndConstants();

        public KeyboardSetter()
        {
            InitializeComponent();
            
        }


        bool okMods = false;
        bool okKeys = false;
      
        private void byteToCk(int b) {
            int val = 128;
            for (int idx = 7; idx >= 0; idx--)
            {
                if( (b / val) == 1 ) {
                    ckMod.SetItemChecked(idx, true);
                    b = b % val;
                }
                val = val / 2;
            }
        }

        private Byte modToByte(int n)
        {
            switch (n)
            {
                case 0: return 0x01;// "L-CTRL";
                case 1: return 0x02;// "L-SHIFT";
                case 2: return 0x04;// "L-ALT";
                case 3: return 0x08;// "L-WIN";
                case 4: return 0x10;// "R-CTRL";
                case 5: return 0x20;// "R-SHIFT";
                case 6: return 0x40;// "R-ALT";
                case 7: return 0x80;// "R-WIN";
            }

            return 0x00;
        }

        private void ckMod_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            updateKeyAction();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Byte[] shake_ByteArray = updateKeyAction();
            HIDCommunications hidComm = HIDCommunications.getInstance();
            hidComm.SetFeatureReport(0x1e, shake_ByteArray, shake_ByteArray.Length);
            this.Close();
        }

        private void ckMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateKeyAction();
        }

        
        private Byte[] updateKeyAction(){

            Byte modifier = new Byte();
            int[] modifierCks = new int[ckMod.CheckedIndices.Count];
            ckMod.CheckedIndices.CopyTo(modifierCks, 0);
            for (int i = 0; i < modifierCks.Length; i++)
            {
                modifier |= modToByte(modifierCks[i]);
            }

            if (comboBox_TastoA.SelectedItem == null)
                comboBox_TastoA.SelectedIndex = 0;
            if (comboBox_TastoB.SelectedItem == null)
                comboBox_TastoB.SelectedIndex = 0;

            Byte keyA = Convert.ToByte(dac.keyMappings[comboBox_TastoA.SelectedItem]);
            Byte keyB = Convert.ToByte(dac.keyMappings[comboBox_TastoB.SelectedItem]);

            Byte[] outBA = new Byte[3];
            outBA[0] = modifier;
            outBA[1] = keyA;
            outBA[2] = keyB;

            return outBA;
            
        }

        private void comboBox_TastoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateKeyAction();
        }

        private void KeyboardSetter_Load(object sender, EventArgs e)
        {
            Byte[] sba = new Byte[3];
            HIDCommunications hidComm = HIDCommunications.getInstance();
            hidComm.GetFeatureReport(0x1e, ref sba, sba.Length);
            Byte mod = sba[0];
            Byte keyA = sba[1];
            Byte keyB = sba[2];
            byteToCk(mod);
            comboBox_TastoA.SelectedItem = dac.retrieveKey(keyA);
            comboBox_TastoB.SelectedItem = dac.retrieveKey(keyB);
        }

        private void comboBox_TastoA_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateKeyAction();
        }

   


   
        

    }
}
