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
	SSPADD = 0x1d;
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
	
	DELAYms(50);
	return 0;
}

BYTE AccelerometerRead(UINT16* px, UINT16* py)
{
	BYTE b;

	StartI2C();
	IdleI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS) != 0)
		return 1;
	IdleI2C();

	if(WriteI2C(0x01) != 0) //Skip Control Registers
		return 2;
	IdleI2C();
	
	RestartI2C();
	
	if(WriteI2C(ACCELEROMETER_ADDRESS+1) != 0)
		return 3;
	IdleI2C();
	
	b = ReadI2C(); //X MSBits
	IdleI2C();
	AckI2C();
	
	*px = (b << 8);
	
	IdleI2C();
	b = ReadI2C(); //X LSBits
	IdleI2C();
	AckI2C();
	
	*px |= b;
	
	IdleI2C();
	b = ReadI2C(); //Y MSBits
	IdleI2C();
	AckI2C();
	
	*py = (b << 8);
	
	IdleI2C();
	b = ReadI2C(); //Y LSBits
	IdleI2C();	
	NotAckI2C();
	
	*py |= b;
	
	IdleI2C();
	StopI2C();
	
	return 0;
}

#endif	//ACCELEROMETER_C
