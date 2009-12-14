using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GenericHid
{

    
    public partial class KeyboardSelector : Form
    {
        private string lastKeyPressed = "";

        public string LastKeyPressed
        {
            get { return lastKeyPressed; }
            set { lastKeyPressed = value; }
        }



        public KeyboardSelector()
        {
            InitializeComponent();
        }


        private void kcontrol_UserKeyPressed(object sender, KeyboardClassLibrary.KeyboardEventArgs e)
        {
            if (e.KeyboardKeyPressed != null)
            {
                char[] c = e.KeyboardKeyPressed.ToCharArray();
                string s = new String(c);
                this.LastKeyPressed = s;
                this.Close();                
            }
           }

        private void KeyboardSelector_Load(object sender, EventArgs e)
        {

        }

        private void kcontrol_Load(object sender, EventArgs e)
        {

        }

    


   
    }
}
