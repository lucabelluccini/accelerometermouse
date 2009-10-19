/********************************************************************
 FileName:      Switches.c
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
#ifndef SWITCHES_C
#define SWITCHES_C

#include "Switches.h"

#pragma udata
BOOL oldSwitch;
BYTE clickCount;

BOOL SwitchIsPressed(void)
{
    if(mSwitch == 0)
    {
		DELAYms(DEBOUNCE_TIME_LAPSE_ms);	           
        if(mSwitch == 0)
		{
			if(oldSwitch == TRUE)
			{
				oldSwitch = FALSE;
				clickCount++;
			}
            return TRUE;
		}
    }
	oldSwitch = TRUE;
    return FALSE;
}

#endif	//SWITCHES_C
