/********************************************************************
 FileName:     	Delays.h
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
				
Notes:			Defines some macros for user-friendly Delays
				Instruction Cycle = TCY
				TCY = 4 / Internal Clock = 4 / 48 MHz
				1 ms = 1000 us = 12 TCY * 1000 = 120 * 100 TCY
 *******************************************************************/
 
#ifndef mDELAYS_H
#define mDELAYS_H
#define DELAYnop()						Delay1TCY()	
#define DELAYms(M)						Delay100TCYx(M*120)
#define DELAY1s()						Delay10KTCYx(240);Delay10KTCYx(240);Delay10KTCYx(240);Delay10KTCYx(240);Delay10KTCYx(240)
#endif	//mDELAYS_H
