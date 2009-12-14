using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace GenericHid
{

    class DefinesAndConstants
    {
        // Inverte il flag di riconoscimento del dispositivo
        public static readonly bool DEBUG_CALIBRAZIONE = false;

        public Hashtable keyMappings = new Hashtable();

        public DefinesAndConstants()
        {
            keyMappings.Add("Non Impostato", (Byte)0x00);
        keyMappings.Add("Keyboard a",0x04);
        keyMappings.Add("Keyboard b",0x05);
        keyMappings.Add("Keyboard c",0x06);
        keyMappings.Add("Keyboard d",0x07);
        keyMappings.Add("Keyboard e",0x08);
        keyMappings.Add("Keyboard f",0x09);
        keyMappings.Add("Keyboard g",0x0A);
        keyMappings.Add("Keyboard h",0x0B);
        keyMappings.Add("Keyboard i",0x0C);
        keyMappings.Add("Keyboard j",0x0D);
        keyMappings.Add("Keyboard k",0x0E);
        keyMappings.Add("Keyboard l",0x0F);
        keyMappings.Add("Keyboard m",0x10);
        keyMappings.Add("Keyboard n",0x11);
        keyMappings.Add("Keyboard o",0x12);
        keyMappings.Add("Keyboard p",0x13);
        keyMappings.Add("Keyboard q",0x14);
        keyMappings.Add("Keyboard r",0x15);
        keyMappings.Add("Keyboard s",0x16);
        keyMappings.Add("Keyboard t",0x17);
        keyMappings.Add("Keyboard u",0x18);
        keyMappings.Add("Keyboard v",0x19);
        keyMappings.Add("Keyboard w",0x1A);
        keyMappings.Add("Keyboard x",0x1B);
        keyMappings.Add("Keyboard y",0x1C);
        keyMappings.Add("Keyboard z",0x1D);
        keyMappings.Add("Keyboard 1",0x1E);
        keyMappings.Add("Keyboard 2",0x1F);
        keyMappings.Add("Keyboard 3",0x20);
        keyMappings.Add("Keyboard 4",0x21);
        keyMappings.Add("Keyboard 5",0x22);
        keyMappings.Add("Keyboard 6",0x23);
        keyMappings.Add("Keyboard 7",0x24);
        keyMappings.Add("Keyboard 8",0x25);
        keyMappings.Add("Keyboard 9",0x26);
        keyMappings.Add("Keyboard 0",0x27);
        keyMappings.Add("Keyboard Return (ENTER)",0x28);
        keyMappings.Add("Keyboard ESCAPE",0x29);
        keyMappings.Add("Keyboard DELETE (Backspace)",0x2A);
        keyMappings.Add("Keyboard Tab",0x2B);
        keyMappings.Add("Keyboard Spacebar",0x2C);
        keyMappings.Add("Keyboard -",0x2D);
        keyMappings.Add("Keyboard =",0x2E);
        keyMappings.Add("Keyboard [",0x2F);
        keyMappings.Add("Keyboard ]",0x30);
        keyMappings.Add("Keyboard \"",0x31);
        keyMappings.Add("Keyboard ;",0x33);
        keyMappings.Add("Keyboard ‘",0x34);
        keyMappings.Add("Keyboard '",0x35);
        keyMappings.Add("Keyboard ,",0x36);
        keyMappings.Add("Keyboard .",0x37);
        keyMappings.Add("Keyboard /",0x38);
        keyMappings.Add("Keyboard Caps Lock",0x39);
        keyMappings.Add("Keyboard F1",0x3A);
        keyMappings.Add("Keyboard F2",0x3B);
        keyMappings.Add("Keyboard F3",0x3C);
        keyMappings.Add("Keyboard F4",0x3D);
        keyMappings.Add("Keyboard F5",0x3E);
        keyMappings.Add("Keyboard F6",0x3F);
        keyMappings.Add("Keyboard F7",0x40);
        keyMappings.Add("Keyboard F8",0x41);
        keyMappings.Add("Keyboard F9",0x42);
        keyMappings.Add("Keyboard F10",0x43);
        keyMappings.Add("Keyboard F11",0x44);
        keyMappings.Add("Keyboard F12",0x45);
        keyMappings.Add("Keyboard PrintScreen",0x46);
        keyMappings.Add("Keyboard Scroll Lock",0x47);
        keyMappings.Add("Keyboard Pause",0x48);
        keyMappings.Add("Keyboard Insert",0x49);
        keyMappings.Add("Keyboard Home",0x4A);
        keyMappings.Add("Keyboard PageUp",0x4B);
        keyMappings.Add("Keyboard Delete Forward",0x4C);
        keyMappings.Add("Keyboard End",0x4D);
        keyMappings.Add("Keyboard PageDown",0x4E);
        keyMappings.Add("Keyboard RightArrow",0x4F);
        keyMappings.Add("Keyboard LeftArrow",0x50);
        keyMappings.Add("Keyboard DownArrow",0x51);
        keyMappings.Add("Keyboard UpArrow",0x52);
        keyMappings.Add("Keypad Num Lock and Clear",0x53);
        keyMappings.Add("Keypad /",0x54);
        keyMappings.Add("Keypad *",0x55);
        keyMappings.Add("Keypad -",0x56);
        keyMappings.Add("Keypad + ",0x57);
        keyMappings.Add("Keypad ENTER",0x58);
        keyMappings.Add("Keypad 1",0x59);
        keyMappings.Add("Keypad 2",0x5A);
        keyMappings.Add("Keypad 3",0x5B);
        keyMappings.Add("Keypad 4",0x5C);
        keyMappings.Add("Keypad 5",0x5D);
        keyMappings.Add("Keypad 6",0x5E);
        keyMappings.Add("Keypad 7",0x5F);
        keyMappings.Add("Keypad 8",0x60);
        keyMappings.Add("Keypad 9",0x61);
        keyMappings.Add("Keypad 0",0x62);
        keyMappings.Add("Keypad .",0x63);
        }

        public String retrieveKey(Byte x)
        {
            foreach (DictionaryEntry de in keyMappings)
            {
                if (Convert.ToByte(de.Value) == x)
                    return Convert.ToString(de.Key);
            }
            return "Non Impostato";

        }

        //// Add some elements to the hash table. There are no 
        //// duplicate keys, but some of the values are duplicates.
        

        //public static int shakeKeyMap(String keyCode)
        //{
        //    switch (keyCode)
        //    {
        //        case "00000000000": return 000000000;
        //        case "00000000001": return 000000000;
        //        case "00000000002": return 000000000;
        //        case "00000000003": return 000000000;
        //        case "00000000004": return 000000000;
        //        case "00000000005": return 000000000;
        //        case "00000000006": return 000000000;
              
        //    }
        //    return 0;
        //}


    }


}
