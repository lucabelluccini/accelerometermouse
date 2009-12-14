/********************************************************************
 FileName:      Eeprom.h
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
#ifndef EEPROM_H
#define EEPROM_H

#include <GenericTypeDefs.h>
#include <Compiler.h>
#include "HardwareProfile.h"
#include <EEP.h>
#include <delays.h>
#include "Delays.h"

#define EE_KEYBOARDMODIFIER		0x00		//BYTE
#define EE_KEYBOARDKEY0			0x02		//BYTE
#define EE_KEYBOARDKEY1			0x04		//BYTE
#define EE_MIRRORX				0x06		//BYTE
#define EE_MIRRORY				0x08		//BYTE
#define EE_OFFSETX				0x0A		//INT
#define EE_OFFSETY				0x0C		//INT
#define EE_GAINX				0x0E		//INT
#define EE_GAINY				0x10		//INT
#define EE_ROTATIONCOEFF0		0x12		//INT
#define EE_ROTATIONCOEFF1		0x14		//INT
#define EE_ROTATIONCOEFF2		0x16		//INT
#define EE_ROTATIONCOEFF3		0x18		//INT
#define EE_CHECKINIT			0xFF		//BYTE

#define EE_EMPTY				0xFF
#define EE_WRITTEN				0x99

void WriteEEpromBYTE(unsigned int badd, unsigned char bdata);
unsigned char ReadEEpromBYTE(unsigned int badd);
void WriteEEpromINT(unsigned int badd, unsigned int bdata);
unsigned int ReadEEpromINT(unsigned int badd);

#endif	//EEPROM_H