/********************************************************************
 FileName:      Switches.h
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
#ifndef SWITCHES_H
#define SWITCHES_H

#include <GenericTypeDefs.h>
#include <delays.h>
#include "Delays.h"
#include "HardwareProfile.h"

#define DEBOUNCE_TIME_LAPSE_ms		65

extern BOOL SwitchA;
extern BOOL SwitchB; 
extern BOOL oldSwitchA;					// Last Switch State
extern BOOL oldSwitchB;					// Last Switch State
extern BYTE clickCount;					// Click Counter (for each Event Window)

/******************************************************************************
 * Function:        BOOL SwitchIsPressed(void)
 * Hardware:		Binded to Switch
 * Output:          TRUE - pressed, FALSE - not pressed
 * Side Effects:    Consumes at least DEBOUNCE_TIME_LAPSE_ms milliseconds
					Increments clickCount
 * Overview:        Indicates if the switch is pressed. Debouncing implemented.
 *****************************************************************************/
BOOL SwitchIsPressedA(void);
BOOL SwitchIsPressedB(void);

#endif	//SWITCHES_H
