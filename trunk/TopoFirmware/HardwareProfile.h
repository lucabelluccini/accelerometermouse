/********************************************************************
 FileName:      HardwareProfile.h
 Dependencies:	See INCLUDES section
 Processor:		PIC18F14K50 USB Microcontroller
 Hardware:		Prototyping board - USB Accelerometer-based Mouse
 Complier:  	Microchip C18
 
 Course:		Programmazione di Sistema
 Teacher:		Malnati G.
 Year:			2009/2010
 Group:			18
 Students:		Allario Marco
				Belluccini Luca
				Cancedda Stefano
				Ferraro Andrea
				
Notes:			
 *******************************************************************/

#ifndef HARDWARE_PROFILE_H
#define HARDWARE_PROFILE_H

/*******************************************************************/
    /******** USB stack hardware selection options *********************/
    /*******************************************************************/
    //This section is the set of definitions required by the MCHPFSUSB
    //  framework.  These definitions tell the firmware what mode it is
    //  running in, and where it can find the results to some information
    //  that the stack needs.
    //These definitions are required by every application developed with
    //  this revision of the MCHPFSUSB framework.  Please review each
    //  option carefully and determine which options are desired/required
    //  for your application.
	
	//#define USE_USB_BUS_SENSE_IO
    #define tris_usb_bus_sense  TRISAbits.TRISA1    // Input
    
    #if defined(USE_USB_BUS_SENSE_IO)
    	#define USB_BUS_SENSE       PORTAbits.RA1
    #else
    	#define USB_BUS_SENSE       1
    #endif
    
    //#define USE_SELF_POWER_SENSE_IO	
    #define tris_self_power     TRISAbits.TRISA2    // Input
    
    #if defined(USE_SELF_POWER_SENSE_IO)
    	#define self_power          PORTAbits.RA2
    #else
    	#define self_power          1
    #endif
	
    /*******************************************************************/
    /******** Application specific definitions *************************/
    /*******************************************************************/

    #define PROGRAMMABLE_WITH_USB_HID_BOOTLOADER	

    /** Board definition ***********************************************/
    #define DEMO_BOARD LOW_PIN_COUNT_USB_DEVELOPMENT_KIT
    #define LOW_PIN_COUNT_USB_DEVELOPMENT_KIT
		
    #define CLOCK_FREQ 48000000
    
    /** L E D ***********************************************************/
	#define mInitLed()		    TRISCbits.TRISC0 = OUTPUT_PIN
	#define mLed                LATCbits.LATC0
	#define mLed_On()           mLed = 1
	#define mLed_Off()          mLed = 0
	#define mLed_Toggle()       mLed = !mLed
	
	/** S W I T C H *****************************************************/
	#define mInitSwitchA()     	TRISCbits.TRISC5 = INPUT_PIN
	#define mSwitchA     		PORTCbits.RC5
	#define mInitSwitchB()		TRISCbits.TRISC1 = INPUT_PIN; ANSEL = ANSELH = 0
	#define mSwitchB			PORTCbits.RC1
		
    /** I/O pin definitions ********************************************/
    #define INPUT_PIN 1
    #define OUTPUT_PIN 0

#endif  //HARDWARE_PROFILE_H
