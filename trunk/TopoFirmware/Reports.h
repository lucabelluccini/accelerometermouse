/********************************************************************
 FileName:      Reports.h
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
				
Notes:			In FID_KEYBOARD_SHAKEACTION:
				-Modifier: consists of a Byte Mask
					7 RIGHT GUI
					6 RIGHT ALT
					5 RIGHT SHIFT
					4 RIGHT CTRL
					3 LEFT GUI
					2 LEFT ALT
					1 LEFT SHIFT
					0 LEFT CTRL
				-Keys: can set up to 2 keys
					Defined in USB HUT Documentation, page 53
					
				In FID_MIRROR_XY:
				-0x00 for NO MIRRORING
				-0x01 for X MIRRORING
				-0x10 for Y MIRRORING
				-0x11 for X and Y MIRRORING
				
				In FID_IS_CALIBRATING:
				-0x00 for enabling mouse cursor movement
				-0x01 for disabling mouse cursor movement
				
				In FID_ROTATION_COEFF (scaled * 100):
				-1st for cos(omega)
				-2nd for -sin(omega)
				-3rd for sin(omega)
				-4th for cos(omega)
				
				In FID_WRITE_TO_EEPROM
				-0x00 for loading last saved parameters
				-0x01 for storing current parameters
				
********************************************************************/

#ifndef REPORTS_H
#define REPORTS_H

enum HIDReportID
{//	REPORT ID								SIZE(Bytes)		ON GET FEATURE						ON SET FEATURE						DATA DETAILS						IMPLEMENTED
	ID_MOUSE					= 0x01,	//																																	X
	ID_KEYBOARD					= 0x02,	//																																	X
	FID_OFFSET_XY				= 0x13,	//	2*2				Returns Offsets X,Y					Sets Offsets X,Y					2 x INT16								X
	FID_RAW_XY					= 0x14,	//	2*2				Returns Raw Values X,Y				-									2 x UINT16								X
	FID_WRITE_TO_EEPROM			= 0x15,	//  1				-									Starts Write Settings to EEPROM		1 BYTE									X
	FID_ABSOLUTE_MODE_X			= 0x1D, //  1				Returns if X is absolute			Enable/Unable X Absolute			
	FID_KEYBOARD_SHAKEACTION	= 0x1E, //  1+2				Returns Keyboard Action Keys		Sets Keyboard Action Keys			1 BYTE + 2 BYTES						X
	FID_IS_CALIBRATING			= 0x20,	//	1				-									Enable/Unable Mouse Calibration		1 BYTE									X
	FID_MIRROR_XY				= 0x21,	//	1				-									Enable/Unable X,Y Mirroring			1 BYTE									X
	FID_SHAKES_WES				= 0x24, // 	2				Returns size of Event Window in ms	Sets size of Event Window in ms 	1 UINT16								
	FID_GAIN_XY					= 0x25,	//	2*2				-									Sets Gain X,Y						2 x UINT16								X
	FID_ROTATION_COEFF			= 0x26, //	4*2				-									Set Rotation Coefficients			4 x INT16								X
	FID_PIVOT_XY				= 0x27,	//	2*2				Returns Pivot X,Y					Sets Pivot X,Y						2 X UINT16								X
    FID_NO_MORE_REPORTS 		= 0xFF
};

#endif



