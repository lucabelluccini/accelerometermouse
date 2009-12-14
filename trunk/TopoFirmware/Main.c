/********************************************************************
 FileName:		Main.c
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
********************************************************************/

#ifndef MAIN_C
#define MAIN_C

/** INCLUDES *******************************************************/
#include <p18cxxx.h>
#include <timers.h>
#include <math.h>
#include <GenericTypeDefs.h>
#include <Compiler.h>
#include "Reports.h"

#include <USB/usb_device.h>
#include <USB/usb.h>
#include <USB/usb_function_hid.h>
#include "usb_config.h"

#include "MouseDefines.h"
#include "HardwareProfile.h"
#include "Accelerometer.h"
#include "Switches.h"
#include "Eeprom.h"

/** CONFIGURATION **************************************************/
#if defined(LOW_PIN_COUNT_USB_DEVELOPMENT_KIT)
        #pragma config CPUDIV = NOCLKDIV
        #pragma config USBDIV = OFF
        #pragma config FOSC   = HS
        #pragma config PLLEN  = ON
        #pragma config FCMEN  = OFF
        #pragma config IESO   = OFF
        #pragma config PWRTEN = OFF
        #pragma config BOREN  = OFF
        #pragma config BORV   = 30
        #pragma config WDTEN  = OFF
        #pragma config WDTPS  = 32768
        #pragma config MCLRE  = OFF
        #pragma config HFOFST = OFF
        #pragma config STVREN = ON
        #pragma config LVP    = OFF
        #pragma config XINST  = OFF
        #pragma config BBSIZ  = OFF
        #pragma config CP0    = OFF
        #pragma config CP1    = OFF
        #pragma config CPB    = OFF
        #pragma config WRT0   = OFF
        #pragma config WRT1   = OFF
        #pragma config WRTB   = OFF
        #pragma config WRTC   = OFF
        #pragma config EBTR0  = OFF
        #pragma config EBTR1  = OFF
        #pragma config EBTRB  = OFF        
#else
    #error No hardware board defined, see "HardwareProfile.h" and __FILE__
#endif

#define ABS(X)							(((X)<0)?-(X):X)

#pragma udata
// USB report stuff
char buffer[40];
char bufferIn[10];
USB_HANDLE lastTransmission;

// Mouse coordinates and some related stuff
UINT16 oldX, oldY, tmpX, tmpY;
INT16 filterTest;
INT8 Xbyte, Ybyte;

// Shake Stuff
#define SHAKES							4
#define SHAKE_TIME_ms					700
#define SHAKE_TIME_ticks				-SHAKE_TIME_ms*47				// 1.398 s whole INT cycle -> 65536 / 1398 = 47 units equals roughly 0.001 ms
float violence;
INT8 shakeCounter;
BOOL isShaked, wasShaked;

// Feature Stuff
UINT16 pivotX, pivotY;
INT16 offsetX, offsetY;
UINT16 gainX, gainY;
BYTE keyboardModifier, keyboardKey[2];
INT16 rotationCoeff[4];
BYTE *ptr;
BOOL isCalibrating;	
BOOL mirrorX, mirrorY;
UINT8 shakes;
UINT16 shakeTimeMs;
INT16 newX, newY;
INT16 X,Y,vX,vY;
BOOL writeToEEprom;
BOOL initFromEEprom;

/** PRIVATE PROTOTYPES *********************************************/
static void InitializeSystem(void);
void MouseInit(void);
void ProcessIO(void);
void MouseHighPriorityISRCode();
void MouseLowPriorityISRCode();
void Mouse(void);

void SetKeyboardModifier(void);
void SetKeyboardKey(void);

void MouseSetReportHandler(void);
void MouseGetReportHandler(void);

void WriteVarToEEprom(BOOL init);
void InitVarFromEEprom(void);

/** VECTOR REMAPPING ***********************************************/
#if defined(__18CXX)
	//On PIC18 devices, addresses 0x00, 0x08, and 0x18 are used for
	//the reset, high priority interrupt, and low priority interrupt
	//vectors.  However, the current Microchip USB bootloader 
	//examples are intended to occupy addresses 0x00-0x7FF or
	//0x00-0xFFF depending on which bootloader is used.  Therefore,
	//the bootloader code remaps these vectors to new locations
	//as indicated below.  This remapping is only necessary if you
	//wish to program the hex file generated from this project with
	//the USB bootloader.  If no bootloader is used, edit the
	//usb_config.h file and comment out the following defines:
	//#define PROGRAMMABLE_WITH_USB_HID_BOOTLOADER
	//#define PROGRAMMABLE_WITH_USB_LEGACY_CUSTOM_CLASS_BOOTLOADER
	
	#if defined(PROGRAMMABLE_WITH_USB_HID_BOOTLOADER)
		#define REMAPPED_RESET_VECTOR_ADDRESS			0x1000
		#define REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS	0x1008
		#define REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS	0x1018
	#elif defined(PROGRAMMABLE_WITH_USB_MCHPUSB_BOOTLOADER)	
		#define REMAPPED_RESET_VECTOR_ADDRESS			0x800
		#define REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS	0x808
		#define REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS	0x818
	#else	
		#define REMAPPED_RESET_VECTOR_ADDRESS			0x00
		#define REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS	0x08
		#define REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS	0x18
	#endif
	
	#if defined(PROGRAMMABLE_WITH_USB_HID_BOOTLOADER)||defined(PROGRAMMABLE_WITH_USB_MCHPUSB_BOOTLOADER)
	extern void _startup (void);        // See c018i.c in your C18 compiler dir
	#pragma code REMAPPED_RESET_VECTOR = REMAPPED_RESET_VECTOR_ADDRESS
	void _reset (void)
	{
	    _asm goto _startup _endasm
	}
	#endif
	#pragma code REMAPPED_HIGH_INTERRUPT_VECTOR = REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS
	void Remapped_High_ISR (void)
	{
	     _asm goto MouseHighPriorityISRCode _endasm
	}
	#pragma code REMAPPED_LOW_INTERRUPT_VECTOR = REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS
	void Remapped_Low_ISR (void)
	{
	     _asm goto MouseLowPriorityISRCode _endasm
	}
	
	#if defined(PROGRAMMABLE_WITH_USB_HID_BOOTLOADER)||defined(PROGRAMMABLE_WITH_USB_MCHPUSB_BOOTLOADER)
	//Note: If this project is built while one of the bootloaders has
	//been defined, but then the output hex file is not programmed with
	//the bootloader, addresses 0x08 and 0x18 would end up programmed with 0xFFFF.
	//As a result, if an actual interrupt was enabled and occured, the PC would jump
	//to 0x08 (or 0x18) and would begin executing "0xFFFF" (unprogrammed space).  This
	//executes as nop instructions, but the PC would eventually reach the REMAPPED_RESET_VECTOR_ADDRESS
	//(0x1000 or 0x800, depending upon bootloader), and would execute the "goto _startup".  This
	//would effective reset the application.
	
	//To fix this situation, we should always deliberately place a 
	//"goto REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS" at address 0x08, and a
	//"goto REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS" at address 0x18.  When the output
	//hex file of this project is programmed with the bootloader, these sections do not
	//get bootloaded (as they overlap the bootloader space).  If the output hex file is not
	//programmed using the bootloader, then the below goto instructions do get programmed,
	//and the hex file still works like normal.  The below section is only required to fix this
	//scenario.
	#pragma code HIGH_INTERRUPT_VECTOR = 0x08
	void High_ISR (void)
	{
	     _asm goto REMAPPED_HIGH_INTERRUPT_VECTOR_ADDRESS _endasm
	}
	#pragma code LOW_INTERRUPT_VECTOR = 0x18
	void Low_ISR (void)
	{
	     _asm goto REMAPPED_LOW_INTERRUPT_VECTOR_ADDRESS _endasm
	}
	#endif	//end of "#if defined(PROGRAMMABLE_WITH_USB_HID_BOOTLOADER)||defined(PROGRAMMABLE_WITH_USB_LEGACY_CUSTOM_CLASS_BOOTLOADER)"

	#pragma code
	
	
	//These are your actual interrupt handling routines.
	#pragma interrupt MouseHighPriorityISRCode
	void MouseHighPriorityISRCode()
	{
		//Check which interrupt flag caused the interrupt.
		//Service the interrupt
		//Clear the interrupt flag
		//Etc.
        #if defined(USB_INTERRUPT)
	        USBDeviceTasks();
        #endif
	
	}	//This return will be a "retfie fast", since this is in a #pragma interrupt section 
	#pragma interruptlow MouseLowPriorityISRCode
	void MouseLowPriorityISRCode()
	{
		// Check which interrupt flag caused the interrupt
		if (INTCONbits.TMR0IF)
		{
			// Clear the interrupt flag
			INTCONbits.TMR0IF = 0;
			if(shakeCounter >= SHAKES){
				//mLed_Toggle();
				isShaked = TRUE;
			}
			shakeCounter = 0;
		}
	}	//This return will be a "retfie", since this is in a #pragma interruptlow section 
#endif

void ShakeInit( void )
{
	RCONbits.IPEN = 1;						// Enable INT Priority Feature
	INTCONbits.GIEH = 1;					// Enable High Priority INT 
	INTCONbits.GIEL = 1;					// Enable Low Priority INT 
	OpenTimer0(TIMER_INT_ON & T0_16BIT & T0_SOURCE_INT & T0_PS_1_256);	//Set 16-bit mode, Prescale 1:256, Internal Clock -> 1.3981 s
	INTCONbits.TMR0IE = 1;					// Enable TMR0 INT
	INTCON2bits.TMR0IP = 0;					// Binds TMR0 Overflow to Low Priority INT
}

/** DECLARATIONS ***************************************************/
#pragma code

void main(void)
{
    InitializeSystem();

    #if defined(USB_INTERRUPT)
        USBDeviceAttach();
    #endif

    while(1)
    {
        #if defined(USB_POLLING)
		// Check bus status and service USB interrupts.
        USBDeviceTasks(); // Interrupt or polling method.  If using polling, must call
        				  // this function periodically.  This function will take care
        				  // of processing and responding to SETUP transactions 
        				  // (such as during the enumeration process when you first
        				  // plug in).  USB hosts require that USB devices should accept
        				  // and process SETUP packets in a timely fashion.  Therefore,
        				  // when using polling, this function should be called 
        				  // frequently (such as once about every 100 microseconds) at any
        				  // time that a SETUP packet might reasonably be expected to
        				  // be sent by the host to your device.  In most cases, the
        				  // USBDeviceTasks() function does not take very long to
        				  // execute (~50 instruction cycles) before it returns.
        #endif
		
        ProcessIO();        
    }
}

/********************************************************************
 * Function:        static void InitializeSystem(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        InitializeSystem is a centralize initialization
 *                  routine. All required USB initialization routines
 *                  are called from here.
 *
 *                  User application initialization routine should
 *                  also be called from here.                  
 *
 * Note:            None
 *******************************************************************/
static void InitializeSystem(void)
{
	ADCON1 |= 0x0F;                 // Default all pins to digital
    
//	The USB specifications require that USB peripheral devices must never source
//	current onto the Vbus pin.  Additionally, USB peripherals should not source
//	current on D+ or D- when the host/hub is not actively powering the Vbus line.
//	When designing a self powered (as opposed to bus powered) USB peripheral
//	device, the firmware should make sure not to turn on the USB module and D+
//	or D- pull up resistor unless Vbus is actively powered.  Therefore, the
//	firmware needs some means to detect when Vbus is being powered by the host.
//	A 5V tolerant I/O pin can be connected to Vbus (through a resistor), and
// 	can be used to detect when Vbus is high (host actively powering), or low
//	(host is shut down or otherwise not supplying power).  The USB firmware
// 	can then periodically poll this I/O pin to know when it is okay to turn on
//	the USB module/D+/D- pull up resistor.  When designing a purely bus powered
//	peripheral device, it is not possible to source current on D+ or D- when the
//	host is not actively providing power on Vbus. Therefore, implementing this
//	bus sense feature is optional.  This firmware can be made to use this bus
//	sense feature by making sure "USE_USB_BUS_SENSE_IO" has been defined in the
//	HardwareProfile.h file.    
    #if defined(USE_USB_BUS_SENSE_IO)
    tris_usb_bus_sense = INPUT_PIN; // See HardwareProfile.h
    #endif
    
//	If the host PC sends a GetStatus (device) request, the firmware must respond
//	and let the host know if the USB peripheral device is currently bus powered
//	or self powered.  See chapter 9 in the official USB specifications for details
//	regarding this request.  If the peripheral device is capable of being both
//	self and bus powered, it should not return a hard coded value for this request.
//	Instead, firmware should check if it is currently self or bus powered, and
//	respond accordingly.  If the hardware has been configured like demonstrated
//	on the PICDEM FS USB Demo Board, an I/O pin can be polled to determine the
//	currently selected power source.  On the PICDEM FS USB Demo Board, "RA2" 
//	is used for	this purpose.  If using this feature, make sure "USE_SELF_POWER_SENSE_IO"
//	has been defined in HardwareProfile.h, and that an appropriate I/O pin has been mapped
//	to it in HardwareProfile.h.
    #if defined(USE_SELF_POWER_SENSE_IO)
    tris_self_power = INPUT_PIN;	// See HardwareProfile.h
    #endif
    
    MouseInit();
    USBDeviceInit();	
}

void MouseInit(void)
{
    // Initialize LED
    mInitLed();
    mLed_Off();
    
    // Initialize Mouse Buttons
    mInitSwitchA();
	mInitSwitchB();
    oldSwitchA = oldSwitchB = FALSE;
	bufferIn[0] = 0;
	
	// Initialize stuff for Shake Check
	shakeCounter = 0;
	ShakeInit();
	isShaked = wasShaked = FALSE;
	
	// Initialize Feature Defined Stuff
	pivotX = 0x0800;
	pivotY = 0x0800;
	isCalibrating = FALSE;
	// Initialize from EEprom
	InitVarFromEEprom();
	initFromEEprom = FALSE;
	writeToEEprom = FALSE;

    // Initialize the variable holding the handle for the last transmission
    lastTransmission = 0;
	
	// Initialize whole buffer
	bufferIn[1] = bufferIn[2] = 0;
	
	// Initialize the accelerometer, wakes it up
	AccelerometerInit();
	AccelerometerWakeup();
	DELAYms(60);
	AccelerometerRead(&oldX,&oldY);
	X = oldX;
	Y = oldY;
}

void ProcessIO(void)
{   
    // If not configured, do not Process IO
    if((USBDeviceState < CONFIGURED_STATE)||(USBSuspendControl==1)) return;
	
	Mouse();
	    
}

void Mouse(void)
{   
	if(writeToEEprom == TRUE)
	{
		WriteVarToEEprom(FALSE);
		writeToEEprom = FALSE;
	}
	if(initFromEEprom == TRUE)
	{
		InitVarFromEEprom();
		initFromEEprom = FALSE;
	}
	
	// If no I2C collision occurs
	if(AccelerometerRead(&tmpX,&tmpY) == 0)
	{

		X = (oldX + tmpX) / 2;
		Y = (oldY + tmpY) / 2;
		oldX = X;
		oldY = Y;
		vX = (X - (INT16)pivotX) / 64;
		vY = (Y - (INT16)pivotY) / 64;
		X = (X - (INT16)pivotX + offsetX) / 64;
		Y = (Y - (INT16)pivotY + offsetY) / 64;
		
		// Checks for Shakes... We won't hurt you :D
		// ScaleFactor = 32 	75^2
		// ScaleFactor = 64 	30^2
		// ScaleFactor = 128 	19^2
		// ScaleFactor = 256 	9^2
		// -> Empiric law: violence > 2090/ScaleFactor
		violence = vX*vX + vY*vY;
		if(violence > 650)
			if(shakeCounter++ == 0)
			{
				WriteTimer0(SHAKE_TIME_ticks);
			}
		
		// Gain (is scaled of 100 -> to be normalized)
		X = (X * (INT16)gainX) / 100;
		Y = (Y * (INT16)gainY) / 100;
		
		// Mirroring
		if(mirrorX)
			X = -X;
		if(mirrorY)
			Y = -Y;
		
		// Rotation (is scaled of 100 -> to be normalized)
		newX = X * rotationCoeff[0] + Y * rotationCoeff[2];
		newY = X * rotationCoeff[1] + Y * rotationCoeff[3];
		newX = newX / 100;
		newY = newY / 100;
		bufferIn[1] = (BYTE)(newX);
		bufferIn[2] = (BYTE)(newY);

	}

    if(HIDTxHandleBusy(lastTransmission) == 0)
    {
		SwitchB = SwitchIsPressedB();
		SwitchA = SwitchIsPressedA();
		
		// Mouse Buttons - Virtual Middle Mouse Button
		if(SwitchA && SwitchB)
		{
			bufferIn[0] |= 0x04;
		} else {
			bufferIn[0] &= 0xFB;
		}
		
		// Mouse Buttons - Left Mouse Button
		if(SwitchA && !SwitchB)
		{
			bufferIn[0] |= 0x01;
		} else {
			bufferIn[0] &= 0xFE;
		}
			
        // Mouse Buttons - Right Mouse Button
		if(SwitchB && !SwitchA)
		{
			bufferIn[0] |= 0x02;
		} else {
			bufferIn[0] &= 0xFD;
		}
		
		// Write Back phase on Report - Mouse Report ID (IN)
		hid_report_in[0] = ID_MOUSE;
		// Mouse Buttons
        hid_report_in[1] = bufferIn[0];
		// Mouse X & Y
		if(!isCalibrating)
		{
			hid_report_in[2] = bufferIn[1];
			hid_report_in[3] = bufferIn[2];
		}
		
		if(isShaked || wasShaked)
		{
			if(wasShaked)
			{
				// Write Back phase on Report - Keyboard REPORT ID (IN)
				hid_report_in[0] = ID_KEYBOARD;
				// No key pressed!
				hid_report_in[1] = 0;hid_report_in[2] = 0;hid_report_in[3] = 0;hid_report_in[4] = 0;
				hid_report_in[5] = 0;hid_report_in[6] = 0;hid_report_in[7] = 0;
				wasShaked = FALSE;
			}
			
			if(isShaked)
			{
				// Write Back phase on Report - Keyboard REPORT ID (IN)
				hid_report_in[0] = ID_KEYBOARD;
				// Left GUI (IV LSB Bit) & 'D' Key (7) => Show Desktop!
				hid_report_in[1] = keyboardModifier;hid_report_in[2] = keyboardKey[0];
				hid_report_in[3] = keyboardKey[1];hid_report_in[4] = 0;hid_report_in[5] = 0;
				hid_report_in[6] = 0;hid_report_in[7] = 0;
				isShaked = FALSE;
				// Send Keyboard report only once
				wasShaked = TRUE;
			}

			// Send the 9 byte packet over USB to the host.
			lastTransmission = HIDTxPacket(HID_EP, (BYTE*)hid_report_in, 0x08);
			
		} else {
			// Send the 4 byte packet over USB to the host.
			lastTransmission = HIDTxPacket(HID_EP, (BYTE*)hid_report_in, 0x04);
		}

    }
	
}

// ******************************************************************************************************
// ************** USB Callback Functions ****************************************************************
// ******************************************************************************************************
// The USB firmware stack will call the callback functions USBCBxxx() in response to certain USB related
// events.  For example, if the host PC is powering down, it will stop sending out Start of Frame (SOF)
// packets to your device.  In response to this, all USB devices are supposed to decrease their power
// consumption from the USB Vbus to <2.5mA each.  The USB module detects this condition (which according
// to the USB specifications is 3+ms of no bus activity/SOF packets) and then calls the USBCBSuspend()
// function.  You should modify these callback functions to take appropriate actions for each of these
// conditions.  For example, in the USBCBSuspend(), you may wish to add code that will decrease power
// consumption from Vbus to <2.5mA (such as by clock switching, turning off LEDs, putting the
// microcontroller to sleep, etc.).  Then, in the USBCBWakeFromSuspend() function, you may then wish to
// add code that undoes the power saving things done in the USBCBSuspend() function.

// The USBCBSendResume() function is special, in that the USB stack will not automatically call this
// function.  This function is meant to be called from the application firmware instead.  See the
// additional comments near the function.

/******************************************************************************
 * Function:        void USBCBSuspend(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        Call back that is invoked when a USB suspend is detected
 *
 * Note:            None
 *****************************************************************************/
void USBCBSuspend(void)
{
	//Example power saving code.  Insert appropriate code here for the desired
	//application behavior.  If the microcontroller will be put to sleep, a
	//process similar to that shown below may be used:
	
	//ConfigureIOPinsForLowPower();
	//SaveStateOfAllInterruptEnableBits();
	//DisableAllInterruptEnableBits();
	//EnableOnlyTheInterruptsWhichWillBeUsedToWakeTheMicro();	//should enable at least USBActivityIF as a wake source
	//Sleep();
	//RestoreStateOfAllPreviouslySavedInterruptEnableBits();	//Preferrably, this should be done in the USBCBWakeFromSuspend() function instead.
	//RestoreIOPinsToNormal();									//Preferrably, this should be done in the USBCBWakeFromSuspend() function instead.

	//IMPORTANT NOTE: Do not clear the USBActivityIF (ACTVIF) bit here.  This bit is 
	//cleared inside the usb_device.c file.  Clearing USBActivityIF here will cause 
	//things to not work as intended.	
	

    #if defined(__C30__)
    #if 0
        U1EIR = 0xFFFF;
        U1IR = 0xFFFF;
        U1OTGIR = 0xFFFF;
        IFS5bits.USB1IF = 0;
        IEC5bits.USB1IE = 1;
        U1OTGIEbits.ACTVIE = 1;
        U1OTGIRbits.ACTVIF = 1;
        Sleep();
    #endif
    #endif
}


/******************************************************************************
 * Function:        void _USB1Interrupt(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is called when the USB interrupt bit is set
 *					In this example the interrupt is only used when the device
 *					goes to sleep when it receives a USB suspend command
 *
 * Note:            None
 *****************************************************************************/
#if 0
void __attribute__ ((interrupt)) _USB1Interrupt(void)
{
    #if !defined(self_powered)
        if(U1OTGIRbits.ACTVIF)
        {       
            IEC5bits.USB1IE = 0;
            U1OTGIEbits.ACTVIE = 0;
            IFS5bits.USB1IF = 0;
        
            //USBClearInterruptFlag(USBActivityIFReg,USBActivityIFBitNum);
            USBClearInterruptFlag(USBIdleIFReg,USBIdleIFBitNum);
            //USBSuspendControl = 0;
        }
    #endif
}
#endif

/******************************************************************************
 * Function:        void USBCBWakeFromSuspend(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The host may put USB peripheral devices in low power
 *					suspend mode (by "sending" 3+ms of idle).  Once in suspend
 *					mode, the host may wake the device back up by sending non-
 *					idle state signalling.
 *					
 *					This call back is invoked when a wakeup from USB suspend 
 *					is detected.
 *
 * Note:            None
 *****************************************************************************/
void USBCBWakeFromSuspend(void)
{
	// If clock switching or other power savings measures were taken when
	// executing the USBCBSuspend() function, now would be a good time to
	// switch back to normal full power run mode conditions.  The host allows
	// a few milliseconds of wakeup time, after which the device must be 
	// fully back to normal, and capable of receiving and processing USB
	// packets.  In order to do this, the USB module must receive proper
	// clocking (IE: 48MHz clock must be available to SIE for full speed USB
	// operation).
}

/********************************************************************
 * Function:        void USBCB_SOF_Handler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USB host sends out a SOF packet to full-speed
 *                  devices every 1 ms. This interrupt may be useful
 *                  for isochronous pipes. End designers should
 *                  implement callback routine as necessary.
 *
 * Note:            None
 *******************************************************************/
void USBCB_SOF_Handler(void)
{
    // No need to clear UIRbits.SOFIF to 0 here.
    // Callback caller is already doing that.
}

/*******************************************************************
 * Function:        void USBCBErrorHandler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The purpose of this callback is mainly for
 *                  debugging during development. Check UEIR to see
 *                  which error causes the interrupt.
 *
 * Note:            None
 *******************************************************************/
void USBCBErrorHandler(void)
{
    // No need to clear UEIR to 0 here.
    // Callback caller is already doing that.

	// Typically, user firmware does not need to do anything special
	// if a USB error occurs.  For example, if the host sends an OUT
	// packet to your device, but the packet gets corrupted (ex:
	// because of a bad connection, or the user unplugs the
	// USB cable during the transmission) this will typically set
	// one or more USB error interrupt flags.  Nothing specific
	// needs to be done however, since the SIE will automatically
	// send a "NAK" packet to the host.  In response to this, the
	// host will normally retry to send the packet again, and no
	// data loss occurs.  The system will typically recover
	// automatically, without the need for application firmware
	// intervention.
	
	// Nevertheless, this callback function is provided, such as
	// for debugging purposes.
}


/*******************************************************************
 * Function:        void USBCBCheckOtherReq(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        When SETUP packets arrive from the host, some
 * 					firmware must process the request and respond
 *					appropriately to fulfill the request.  Some of
 *					the SETUP packets will be for standard
 *					USB "chapter 9" (as in, fulfilling chapter 9 of
 *					the official USB specifications) requests, while
 *					others may be specific to the USB device class
 *					that is being implemented.  For example, a HID
 *					class device needs to be able to respond to
 *					"GET REPORT" type of requests.  This
 *					is not a standard USB chapter 9 request, and 
 *					therefore not handled by usb_device.c.  Instead
 *					this request should be handled by class specific 
 *					firmware, such as that contained in usb_function_hid.c.
 *
 * Note:            None
 *******************************************************************/
void USBCBCheckOtherReq(void)
{
    USBCheckHIDRequest();
}//end


/*******************************************************************
 * Function:        void USBCBStdSetDscHandler(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USBCBStdSetDscHandler() callback function is
 *					called when a SETUP, bRequest: SET_DESCRIPTOR request
 *					arrives.  Typically SET_DESCRIPTOR requests are
 *					not used in most applications, and it is
 *					optional to support this type of request.
 *
 * Note:            None
 *******************************************************************/
void USBCBStdSetDscHandler(void)
{
    // Must claim session ownership if supporting this request
}//end


/*******************************************************************
 * Function:        void USBCBInitEP(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is called when the device becomes
 *                  initialized, which occurs after the host sends a
 * 					SET_CONFIGURATION (wValue not = 0) request.  This 
 *					callback function should initialize the endpoints 
 *					for the device's usage according to the current 
 *					configuration.
 *
 * Note:            None
 *******************************************************************/
void USBCBInitEP(void)
{
    // Enable the HID endpoint
    USBEnableEndpoint(HID_EP,USB_IN_ENABLED|USB_OUT_ENABLED|USB_HANDSHAKE_ENABLED|USB_DISALLOW_SETUP);
}

/********************************************************************
 * Function:        void USBCBSendResume(void)
 *
 * PreCondition:    None
 *
 * Input:           None
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        The USB specifications allow some types of USB
 * 					peripheral devices to wake up a host PC (such
 *					as if it is in a low power suspend to RAM state).
 *					This can be a very useful feature in some
 *					USB applications, such as an Infrared remote
 *					control	receiver.  If a user presses the "power"
 *					button on a remote control, it is nice that the
 *					IR receiver can detect this signalling, and then
 *					send a USB "command" to the PC to wake up.
 *					
 *					The USBCBSendResume() "callback" function is used
 *					to send this special USB signalling which wakes 
 *					up the PC.  This function may be called by
 *					application firmware to wake up the PC.  This
 *					function should only be called when:
 *					
 *					1.  The USB driver used on the host PC supports
 *						the remote wakeup capability.
 *					2.  The USB configuration descriptor indicates
 *						the device is remote wakeup capable in the
 *						bmAttributes field.
 *					3.  The USB host PC is currently sleeping,
 *						and has previously sent your device a SET 
 *						FEATURE setup packet which "armed" the
 *						remote wakeup capability.   
 *
 *					This callback should send a RESUME signal that
 *                  has the period of 1-15ms.
 *
 * Note:            Interrupt vs. Polling
 *                  -Primary clock
 *                  -Secondary clock ***** MAKE NOTES ABOUT THIS *******
 *                   > Can switch to primary first by calling USBCBWakeFromSuspend()
 
 *                  The modifiable section in this routine should be changed
 *                  to meet the application needs. Current implementation
 *                  temporary blocks other functions from executing for a
 *                  period of 1-13 ms depending on the core frequency.
 *
 *                  According to USB 2.0 specification section 7.1.7.7,
 *                  "The remote wakeup device must hold the resume signaling
 *                  for at lest 1 ms but for no more than 15 ms."
 *                  The idea here is to use a delay counter loop, using a
 *                  common value that would work over a wide range of core
 *                  frequencies.
 *                  That value selected is 1800. See table below:
 *                  ==========================================================
 *                  Core Freq(MHz)      MIP         RESUME Signal Period (ms)
 *                  ==========================================================
 *                      48              12          1.05
 *                       4              1           12.6
 *                  ==========================================================
 *                  * These timing could be incorrect when using code
 *                    optimization or extended instruction mode,
 *                    or when having other interrupts enabled.
 *                    Make sure to verify using the MPLAB SIM's Stopwatch
 *                    and verify the actual signal on an oscilloscope.
 *******************************************************************/
void USBCBSendResume(void)
{
    static WORD delay_count;
    
    USBResumeControl = 1;                // Start RESUME signaling
    
    delay_count = 1800U;                // Set RESUME line for 1-13 ms
    do
    {
        delay_count--;
    }while(delay_count);
    USBResumeControl = 0;
}


/*******************************************************************
 * Function:        BOOL USER_USB_CALLBACK_EVENT_HANDLER(
 *                        USB_EVENT event, void *pdata, WORD size)
 *
 * PreCondition:    None
 *
 * Input:           USB_EVENT event - the type of event
 *                  void *pdata - pointer to the event data
 *                  WORD size - size of the event data
 *
 * Output:          None
 *
 * Side Effects:    None
 *
 * Overview:        This function is called from the USB stack to
 *                  notify a user application that a USB event
 *                  occured.  This callback is in interrupt context
 *                  when the USB_INTERRUPT option is selected.
 *
 * Note:            None
 *******************************************************************/
BOOL USER_USB_CALLBACK_EVENT_HANDLER(USB_EVENT event, void *pdata, WORD size)
{
    switch(event)
    {
        case EVENT_CONFIGURED: 
            USBCBInitEP();
            break;
        case EVENT_SET_DESCRIPTOR:
            USBCBStdSetDscHandler();
            break;
        case EVENT_EP0_REQUEST:
            USBCBCheckOtherReq();
            break;
        case EVENT_SOF:
            USBCB_SOF_Handler();
            break;
        case EVENT_SUSPEND:
            USBCBSuspend();
            break;
        case EVENT_RESUME:
            USBCBWakeFromSuspend();
            break;
        case EVENT_BUS_ERROR:
            USBCBErrorHandler();
            break;
        case EVENT_TRANSFER:
            Nop();
            break;
        default:
            break;
    }      
    return TRUE; 
}

/********************************************************************
 * Function:        WriteVarToEEprom(BOOL init)
 * Overview:        This function stores mouse parameters to EEprom
					If it is called passing TRUE, sets default values
					and it writes them
 *******************************************************************/
void WriteVarToEEprom(BOOL init)
{
	if(init == TRUE)
	{
		keyboardModifier = 0x08;
		keyboardKey[0] = 0x07;
		keyboardKey[1] = 0x00;
		mirrorX = FALSE;
		mirrorY = FALSE;
		offsetX = 0;
		offsetY = 0;
		gainX = 100;
		gainY = 100;
		rotationCoeff[0] = 100;
		rotationCoeff[1] = 0;
		rotationCoeff[2] = 0;
		rotationCoeff[3] = 100;
	}
	WriteEEpromBYTE(EE_KEYBOARDMODIFIER,keyboardModifier);
	WriteEEpromBYTE(EE_KEYBOARDKEY0,keyboardKey[0]);
	WriteEEpromBYTE(EE_KEYBOARDKEY1,keyboardKey[1]);
	WriteEEpromBYTE(EE_MIRRORX,mirrorX);
	WriteEEpromBYTE(EE_MIRRORY,mirrorY);
	WriteEEpromINT(EE_OFFSETX,offsetX);
	WriteEEpromINT(EE_OFFSETY,offsetY);
	WriteEEpromINT(EE_GAINX,gainX);
	WriteEEpromINT(EE_GAINY,gainY);
	WriteEEpromINT(EE_ROTATIONCOEFF0,rotationCoeff[0]);
	WriteEEpromINT(EE_ROTATIONCOEFF1,rotationCoeff[1]);
	WriteEEpromINT(EE_ROTATIONCOEFF2,rotationCoeff[2]);
	WriteEEpromINT(EE_ROTATIONCOEFF3,rotationCoeff[3]);
	WriteEEpromBYTE(EE_CHECKINIT, EE_WRITTEN);
}

/********************************************************************
 * Function:        InitVarFromEEprom(void)
 * Overview:        This function loads mouse parameters from EEprom
					If EEPROM is empty, fills it with default params
					calling the WriteVarToEEprom function
 *******************************************************************/
void InitVarFromEEprom(void)
{
	if(ReadEEpromBYTE(EE_CHECKINIT) == EE_EMPTY)
		WriteVarToEEprom(TRUE);
	keyboardModifier = ReadEEpromBYTE(EE_KEYBOARDMODIFIER);
	keyboardKey[0] = ReadEEpromBYTE(EE_KEYBOARDKEY0);
	keyboardKey[1] = ReadEEpromBYTE(EE_KEYBOARDKEY1);
	mirrorX = ReadEEpromBYTE(EE_MIRRORX);
	mirrorY = ReadEEpromBYTE(EE_MIRRORY);
	offsetX = ReadEEpromINT(EE_OFFSETX);
	offsetY = ReadEEpromINT(EE_OFFSETY);
	gainX = ReadEEpromINT(EE_GAINX);
	gainY = ReadEEpromINT(EE_GAINY);
	rotationCoeff[0] = ReadEEpromINT(EE_ROTATIONCOEFF0);
	rotationCoeff[1] = ReadEEpromINT(EE_ROTATIONCOEFF1);
	rotationCoeff[2] = ReadEEpromINT(EE_ROTATIONCOEFF2);
	rotationCoeff[3] = ReadEEpromINT(EE_ROTATIONCOEFF3);
}

/********************************************************************
 * Functions:        void Set<Feature> (void)
  *******************************************************************/

void SetKeyboardShakeAction(void) { 
	keyboardModifier = buffer[1];
	keyboardKey[0] = buffer[2];
	keyboardKey[1] = buffer[3];
}

void SetCalibrating(void) {
	isCalibrating = (buffer[1] == 0)? FALSE : TRUE;
}

void SetRotationCoeff(void) {
BYTE *ptr;
 	ptr = (BYTE *) rotationCoeff;
	*ptr = buffer[2];
	ptr++;
	*ptr = buffer[1];
	ptr++;
	*ptr = buffer[4];
	ptr++;
	*ptr = buffer[3];
	ptr++;
	*ptr = buffer[6];
	ptr++;
	*ptr = buffer[5];
	ptr++;
	*ptr = buffer[8];
	ptr++;
	*ptr = buffer[7];
}

void SetOffset(void) {
BYTE *ptr;
 	ptr = (BYTE *) &offsetX;
	*ptr = buffer[2];
	ptr++;
	*ptr = buffer[1];
 	ptr = (BYTE *) &offsetY;
	*ptr = buffer[4];
	ptr++;
	*ptr = buffer[3];
}

void SetGain(void) {
BYTE *ptr;
 	ptr = (BYTE *) &gainX;
	*ptr = buffer[2];
	ptr++;
	*ptr = buffer[1];
 	ptr = (BYTE *) &gainY;
	*ptr = buffer[4];
	ptr++;
	*ptr = buffer[3];
}

void SetPivot(void) {
BYTE *ptr;
 	ptr = (BYTE *) &pivotX;
	*ptr = buffer[2];
	ptr++;
	*ptr = buffer[1];
 	ptr = (BYTE *) &pivotY;
	*ptr = buffer[4];
	ptr++;
	*ptr = buffer[3];
}

void WriteToEeprom(void) {
	switch(buffer[1])
	{
		case 1:
			writeToEEprom = TRUE;
			break;
		case 0:
			initFromEEprom = TRUE;
			break;
		default:
			break;
	}
	
}

void SetMirror(void) {
	switch(buffer[1])
	{
		case 0x00:
			mirrorX = FALSE;
			mirrorY = FALSE;
			break;
		case 0x01:
			mirrorX = TRUE;
			mirrorY = FALSE;
			break;
		case 0x02:
			mirrorX = FALSE;
			mirrorY = TRUE;
			break;
		case 0x03:
			mirrorX = TRUE;
			mirrorY = TRUE;
			break;
		default:
			mirrorX = FALSE;
			mirrorY = FALSE;
			break;
	}
}

/********************************************************************
 * Function:        void MouseSetReportHandler(void)
 * Side Effects:    If the USBEP0Transmit() function is not called
 *                  in this function then the resulting GET_REPORT
 *                  will be STALLed.
 * Overview:        This function is called by the HID function driver
 *                  in response to a SET_REPORT command.
 * Note:            This function is called from the stack in
 *                  response of a EP0 packet.  The response to this
 *                  packet should be fast in order to clear EP0 for
 *                  any potential SETUP packets.  Do not call any
 *                  functions or run any algorithms that take a long time
 *                  to execute (>50uSec).  Have any data that is received
 *                  should be processed in the main line.  Save the data
 *                  here and process the data later.
 *                  - SetupPkt.W_Value.byte.HB specifies the report type
 *                  - SetupPkt.W_Value.byte.LB specifies the report ID of the target 
 *******************************************************************/

void MouseSetReportHandler(void)
{
	mLed_Toggle();
    switch(SetupPkt.W_Value.byte.LB)
    {
		case FID_ROTATION_COEFF:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetRotationCoeff);
			break;
		case FID_KEYBOARD_SHAKEACTION:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetKeyboardShakeAction);
			break;
		case FID_IS_CALIBRATING:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetCalibrating);
			break;
		case FID_OFFSET_XY:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetOffset);
			break;
		case FID_WRITE_TO_EEPROM:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,WriteToEeprom);
			break;
		case FID_MIRROR_XY:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetMirror);
			break;
		case FID_GAIN_XY:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetGain);
			break;
		case FID_PIVOT_XY:
			USBEP0Receive((BYTE*)buffer,SetupPkt.wLength,SetPivot);
			break;
        default:
            break;
    }
}

/********************************************************************
 * Function:        void MouseGetReportHandler(void)
 * Side Effects:    If either the USBEP0SendRAMPtr() or USBEP0Transmit()
 *                  functions are not called in this function then the 
 *                  requesting GET_REPORT will be STALLed
 * Overview:        This function is called by the HID function driver
 *                  in response to a GET_REPORT command.
 *
 * Note:            This function is called from the stack in
 *                  response of a EP0 packet.  The response to this
 *                  packet should be fast in order to clear EP0 for
 *                  any potential SETUP packets.  Do not call any
 *                  functions or run any algorithms that take a long time
 *                  to execute (>50uSec).  Have any data that would be
 *                  read using one of these commands pre-calculated
 *                  from the main line code and just use this function
 *                  to transfer the data.
 *                  - SetupPkt.W_Value.byte.HB specifies the report type
 *                  - SetupPkt.W_Value.byte.LB specifies the report ID of the target 
 *******************************************************************/

 void MouseGetReportHandler(void)
{
BYTE val = 0;
	mLed_Toggle();
    switch(SetupPkt.W_Value.byte.LB)
    {
         case FID_RAW_XY:
            buffer[0] = FID_RAW_XY;
            buffer[1] = (BYTE)(tmpX>>8);
			buffer[2] = (BYTE)(tmpX);
			buffer[3] = (BYTE)(tmpY>>8);
			buffer[4] = (BYTE)(tmpY);
			USBEP0SendRAMPtr((BYTE*)&buffer, 5, USB_EP0_NO_OPTIONS);
            break;
		case FID_PIVOT_XY:
            buffer[0] = FID_PIVOT_XY;
            buffer[1] = (BYTE)(pivotX>>8);
			buffer[2] = (BYTE)(pivotX);
			buffer[3] = (BYTE)(pivotY>>8);
			buffer[4] = (BYTE)(pivotY);
			USBEP0SendRAMPtr((BYTE*)&buffer, 5, USB_EP0_NO_OPTIONS);
            break;
		case FID_OFFSET_XY:
            buffer[0] = FID_OFFSET_XY;
            buffer[1] = (BYTE)(offsetX>>8);
			buffer[2] = (BYTE)(offsetX);
			buffer[3] = (BYTE)(offsetY>>8);
			buffer[4] = (BYTE)(offsetY);
			USBEP0SendRAMPtr((BYTE*)&buffer, 5, USB_EP0_NO_OPTIONS);
            break;
		case FID_KEYBOARD_SHAKEACTION:
            buffer[0] = FID_KEYBOARD_SHAKEACTION;
            buffer[1] = keyboardModifier;
			buffer[2] = keyboardKey[0];
			buffer[3] = keyboardKey[1];
			USBEP0SendRAMPtr((BYTE*)&buffer, 4, USB_EP0_NO_OPTIONS);
            break;
		case FID_ROTATION_COEFF:
            buffer[0] = FID_ROTATION_COEFF;
            buffer[1] = (BYTE) (rotationCoeff[0]>>8);
			buffer[2] = (BYTE) (rotationCoeff[0]);
            buffer[3] = (BYTE) (rotationCoeff[1]>>8);
			buffer[4] = (BYTE) (rotationCoeff[1]);
            buffer[5] = (BYTE) (rotationCoeff[2]>>8);
			buffer[6] = (BYTE) (rotationCoeff[2]);
            buffer[7] = (BYTE) (rotationCoeff[3]>>8);
			buffer[8] = (BYTE) (rotationCoeff[3]);
			USBEP0SendRAMPtr((BYTE*)&buffer, 9, USB_EP0_NO_OPTIONS);
            break;
		case FID_GAIN_XY:
			buffer[0] = FID_GAIN_XY;
            buffer[1] = (BYTE) (gainX>>8);
			buffer[2] = (BYTE) (gainX);
            buffer[3] = (BYTE) (gainY>>8);
			buffer[4] = (BYTE) (gainY);
			USBEP0SendRAMPtr((BYTE*)&buffer, 5, USB_EP0_NO_OPTIONS);
            break;
		case FID_MIRROR_XY:
			buffer[0] = FID_MIRROR_XY;
			if(mirrorX)
				val += 1;
			if(mirrorY)
				val += 2;
			buffer[1] = val;
			USBEP0SendRAMPtr((BYTE*)&buffer, 2, USB_EP0_NO_OPTIONS);
			break;
        default:
            break;
    }
}

/** EOF Main.c **********************************************/
#endif
