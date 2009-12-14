/********************************************************************
 FileName:      Eeprom.c
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
#ifndef EEPROM_C
#define EEPROM_C

#include "Eeprom.h"

unsigned char ReadEEpromBYTE(unsigned int badd)
{
	Busy_eep();
	return Read_b_eep(badd);
}

unsigned int ReadEEpromINT(unsigned int badd)
{
	WORD_VAL wv;
	wv.byte.HB = ReadEEpromBYTE(badd);
	wv.byte.LB = ReadEEpromBYTE(badd+1);
	return wv.Val;
}

void WriteEEpromBYTE(unsigned int badd, unsigned char bdata)
{
	Busy_eep();
	Write_b_eep(badd, bdata);
}

void WriteEEpromINT(unsigned int badd, unsigned int bdata)
{
	WORD_VAL wv;
	wv.Val = bdata;
	WriteEEpromBYTE(badd, wv.byte.HB);
	WriteEEpromBYTE(badd+1, wv.byte.LB);
}

#endif	//EEPROM_C
