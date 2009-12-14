/// <summary>
///  Runs the application.
/// </summary> 
///  
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GenericHid
{
    
    public class GenericHid  
    {

       internal static TopoTester FrmMy;

    /*    internal static TopoTester FrmMy1
        {
            get { return GenericHid.FrmMy; }
            set { GenericHid.FrmMy = value; }
        }
    */

        /// <summary>
        ///  Displays the application's main form.
        /// </summary> 
        
        public static void Main() 
        { 
            FrmMy = new TopoTester();
            Application.Run( FrmMy ); 
        } 
        
        
    } 
    
    
    
    
    
} 
