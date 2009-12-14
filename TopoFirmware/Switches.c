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
BOOL SwitchA;
BOOL SwitchB;
BOOL oldSwitchA;
BOOL oldSwitchB;
BYTE clickCount;

BOOL SwitchIsPressedA(void)
{
    if(mSwitchA == 0)
    {
		DELAYms(DEBOUNCE_TIME_LAPSE_ms);	           
        if(mSwitchA == 0)
		{
			if(oldSwitchA == TRUE)
			{
				oldSwitchA = FALSE;
				clickCount++;
				
			}
            return TRUE;
		}
    }
	oldSwitchA = TRUE;
    return FALSE;
}

BOOL SwitchIsPressedB(void)
{
    if(mSwitchB == 0)
    {
		DELAYms(DEBOUNCE_TIME_LAPSE_ms);	           
        if(mSwitchB == 0)
		{
			if(oldSwitchB == TRUE)
			{
				oldSwitchB = FALSE;
				//clickCount++;
			}
            return TRUE;
		}
    }
	oldSwitchB = TRUE;
    return FALSE;
}

#endif	//SWITCHES_C
