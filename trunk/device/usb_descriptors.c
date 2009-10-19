/********************************************************************
 FileName:     	usb_descriptors.c
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
				
Notes:			If STDMOUSEHID is defined
				- enable standard Mouse HID
				Otherwise
				- enable Vendor Defined HID (debugging mode)
********************************************************************

[Device Descriptors]
The device descriptor is defined as a USB_DEVICE_DESCRIPTOR type.  
This type is defined in usb_ch9.h  Each entry into this structure
needs to be the correct length for the data type of the entry.

[Configuration Descriptors]
The configuration descriptor was changed in v2.x from a structure
to a BYTE array.  Given that the configuration is now a byte array
each byte of multi-byte fields must be listed individually.

[Endpoint Descriptors]
Like the configuration descriptor, the endpoint descriptors were 
changed in v2.x of the stack from a structure to a BYTE array.  As
endpoint descriptors also has a field that are multi-byte entities,
please be sure to specify both bytes of the field.

********************************************************************/

#ifndef __USB_DESCRIPTORS_C
#define __USB_DESCRIPTORS_C

/** INCLUDES *******************************************************/
#include "GenericTypeDefs.h"
#include "Compiler.h"
#include "usb_config.h"
#include "./USB/usb_device.h"

#include "./USB/usb_function_hid.h"

/** CONSTANTS ******************************************************/
#if defined(__18CXX)
#pragma romdata
#endif

/* Device Descriptor */
ROM USB_DEVICE_DESCRIPTOR device_dsc=
{
    0x12,    				// Size of this descriptor in bytes
    USB_DESCRIPTOR_DEVICE,  // DEVICE descriptor type
    0x0200,                 // USB Spec Release Number in BCD format
    0x00,                   // Class Code
    0x00,                   // Subclass code
    0x00,                   // Protocol code
    USB_EP0_BUFF_SIZE,      // Max packet size for EP0, see usb_config.h
    MY_VID,                 // Vendor ID
    MY_PID,                 // Product ID
    0x0001,                 // Device release number in BCD format
    0x01,                   // Manufacturer string index
    0x02,                   // Product string index
    0x00,                   // Device serial number string index
    0x01                    // Number of possible configurations
};

/* Configuration 1 Descriptor */
ROM BYTE configDescriptor1[]={
    /* Configuration Descriptor */
    0x09,							// sizeof(USB_CFG_DSC)
    USB_DESCRIPTOR_CONFIGURATION,
    DESC_CONFIG_WORD(0x0022),		// Total length of data for this cfg
    1,								// # of interfaces
    1,								// Configuration index
    0,								// Configuration string index
    _DEFAULT | _SELF,				// Attributes, see usb_device.h
    50,								// Max power consumption (2X mA)
    /* Interface Descriptor */
    0x09,							// sizeof(USB_INTF_DSC)
    USB_DESCRIPTOR_INTERFACE,
    0,								// Interface #
    0,								// Alternate Setting #
    1,								// # of endpoints in this interface
    HID_INTF,						// Class code
    BOOT_INTF_SUBCLASS,				// Subclass code
    HID_PROTOCOL_MOUSE,				// Protocol code
    0,								// Interface string index
    /* HID Class-Specific Descriptor */
    0x09,							// sizeof(USB_HID_DSC)+3
    DSC_HID,
    DESC_CONFIG_WORD(0x0111),		// HID Spec Release Number in BCD format (1.11)
    0x00,							// Country Code not supported
    HID_NUM_OF_DSC,					// # of class descriptors, see usbcfg.h
    DSC_RPT,
#ifdef STDMOUSEHID
    DESC_CONFIG_WORD(50),    		// Size of the report descriptor
#else
    DESC_CONFIG_WORD(61),      		// Size of the report descriptor    
#endif
    /* Endpoint Descriptor */
    0x07,							// sizeof(USB_EP_DSC)
    USB_DESCRIPTOR_ENDPOINT,		// Endpoint Descriptor
    HID_EP | _EP_IN,				// Endpoint Address
    _INTERRUPT,						// Attributes
    DESC_CONFIG_WORD(3),			// Size
    0x01							//Interval
};

//Language code string descriptor
ROM struct{BYTE bLength;BYTE bDscType;WORD string[1];}sd000={
sizeof(sd000),USB_DESCRIPTOR_STRING,{0x0409
}};

//Manufacturer string descriptor
ROM struct{BYTE bLength;BYTE bDscType;WORD string[24];}sd001={
sizeof(sd001),USB_DESCRIPTOR_STRING,
{'P','d','S',' ','-',' ','G','r','o','u','p',' ',
'1','8',' ','-',' ','2','0','0','9','/','1','0'
}};

//Product string descriptor
ROM struct{BYTE bLength;BYTE bDscType;WORD string[17];}sd002={
sizeof(sd002),USB_DESCRIPTOR_STRING,
{'M','o','u','s','e',' ','b','y',' ','G','r',
'o','u','p',' ','1','8'
}};

//Class specific descriptor - HID Mouse
ROM struct{BYTE report[HID_RPT01_SIZE];}hid_rpt01={
    {
#ifdef STDMOUSEHID
	0x05, 0x01, /* Usage Page (Generic Desktop)             */
    0x09, 0x02, /* Usage (Mouse)                            */
#else
	0x06, 0x00, 0xFF, /* Usage Page (Vendor Defined)        */
    0x09, 0x01, /* Usage (Vendor Defined)                   */
#endif
    0xA1, 0x01, /* Collection (Application)                 */
    0x09, 0x01, /*  Usage (Pointer)                         */
    0xA1, 0x00, /*  Collection (Physical)                   */
    0x05, 0x09, /*      Usage Page (Buttons)                */
    0x19, 0x01, /*      Usage Minimum (01)                  */
    0x29, 0x03, /*      Usage Maximum (03)                  */
    0x15, 0x00, /*      Logical Minimum (0)                 */
    0x25, 0x01, /*      Logical Maximum (0)                 */
    0x95, 0x03, /*      Report Count (3)                    */
    0x75, 0x01, /*      Report Size (1)                     */
    0x81, 0x02, /*      Input (Data, Variable, Absolute)    */
    0x95, 0x01, /*      Report Count (1)                    */
    0x75, 0x05, /*      Report Size (5)                     */
    0x81, 0x01, /*      Input (Constant)    ;5 bit padding  */
    0x05, 0x01, /*      Usage Page (Generic Desktop)        */
    0x09, 0x30, /*      Usage (X)                           */
    0x09, 0x31, /*      Usage (Y)                           */
    0x15, 0x81, /*      Logical Minimum (-127)              */
    0x25, 0x7F, /*      Logical Maximum (127)               */
    0x75, 0x08, /*      Report Size (8)                     */
    0x95, 0x02, /*      Report Count (2)                    */
    0x81, 0x06, /*      Input (Data, Variable, Relative)    */
#ifndef STDMOUSEHID
	0x09, 0x01, /*      Usage (Accel X Raw)                 */
	0x09, 0x01, /*      Usage (Accel Y Raw)                 */
	0x75, 0x10, /*      Report Size (16)                    */
	0x95, 0x02, /*      Report Count (2)                    */
	0x81, 0x06, /*      Input (Data, Variable, Absolute)    */
#endif
    0xC0, 0xC0
	}
};

//Array of configuration descriptors
ROM BYTE *ROM USB_CD_Ptr[]=
{
    (ROM BYTE *ROM)&configDescriptor1
};

//Array of string descriptors
ROM BYTE *ROM USB_SD_Ptr[]=
{
    (ROM BYTE *ROM)&sd000,
    (ROM BYTE *ROM)&sd001,
    (ROM BYTE *ROM)&sd002
};

#endif
