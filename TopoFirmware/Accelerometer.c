/********************************************************************
 FileName:      Accelerometer.c
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
#ifndef ACCELEROMETER_C
#define ACCELEROMETER_C

#include "Accelerometer.h"

void AccelerometerInit(void)
{
	OpenI2C(MASTER, SLEW_ON);
	SSPADD = 0x1D;
	IdleI2C();
	return;
}

BYTE AccelerometerWakeup(void)
{
	StartI2C();
	IdleI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS) != 0)
		return 1;
	IdleI2C();
	
	if(WriteI2C(0x00) != 0)
		return 2;
	IdleI2C();
	
	if(WriteI2C(0x00) != 0)
		return 3;
	IdleI2C();

	StopI2C();
	
	DELAYms(50);
	return 0;
}

/* SAVE SPACE ON ROM
BYTE AccelerometerSleep(void)
{
	StartI2C();
	IdleI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS) != 0)
		return 1;
	IdleI2C();
	
	if(WriteI2C(0x01) != 0)
		return 2;
	IdleI2C();
	
	if(WriteI2C(0x01) != 0)
		return 3;
	IdleI2C();

	StopI2C();
	
	DELAYms(100);
	return 0;
}
*/

BYTE AccelerometerRead(UINT16* px, UINT16* py)
{
	UINT8 bMSB, bLSB;

	IdleI2C();
	StartI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS) != 0)
		return 1;
	IdleI2C();

	if(WriteI2C(0x01) != 0) //Skip Control Register
		return 2;
	IdleI2C();
	
	RestartI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS+1) != 0)
		return 3;
	IdleI2C();
	
	/* Uncomment if you want to read Control Register
	// Remember to set 0x00 on WriteI2C (Skip Control Register)
	if(ReadI2C() != 0x00) //Control Reg
		return 4;
	IdleI2C();
	AckI2C();
	IdleI2C();
	*/
	
	bMSB = ReadI2C(); //X MSBits
	AckI2C();
	IdleI2C();
	
	bLSB = ReadI2C(); //X LSBits
	AckI2C();
	IdleI2C();
	
	*px = bMSB;
	*px = (*px)<<8;
	*px+= bLSB;

	
	bMSB = ReadI2C(); //Y MSBits
	AckI2C();
	IdleI2C();

	bLSB = ReadI2C(); //Y LSBits	
	NotAckI2C();
	
	*py = bMSB;
	*py = (*py)<<8;
	*py+= bLSB;

	IdleI2C();
	StopI2C();
	
	return 0;
}

#endif	//ACCELEROMETER_C
