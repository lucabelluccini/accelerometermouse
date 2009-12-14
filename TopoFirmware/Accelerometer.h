/********************************************************************
 FileName:      Accelerometer.h
 Dependencies:	See INCLUDES section
 Processor:		PIC18F14K50 USB Microcontroller
 Hardware:		Prototyping board - USB Accelerometer-based Mouse
				This specific file relies on MEMSICMXC62020J
 Complier:  	Microchip C18
 
 Course:		Programmazione di Sistema
 Teacher:		Malnati G.
 Year:			2009/2010
 Group:			18
 Students:		Allario Marco
				Belluccini Luca
				Cancedda Stefano
				Ferraro Andrea
				
Notes:			See datasheet
 *******************************************************************/

#ifndef ACCELEROMETER_H
#define ACCELEROMETER_H

#include <GenericTypeDefs.h>
#include <i2c.h>
#include <delays.h>
#include "Delays.h"

#define ACCELEROMETER_ADDRESS			0x20

/* Accelerometer 

POWER DOWN MODE
	The MEMSIC accelerometer can enter a power down mode by the master device writing a code of “[xxxxxxx1]” into the accelerometer’s internal register.
	A wake up operation is performed when the master writes into the same register a code of “[xxxxxxx0]”. Note that it needs about 50mS (typical) for power up time.
	The master powers down the MEMSIC device by writing into the internal control register.
*/

/******************************************************************************
 * Function:        BYTE AccelerometerRead(UINT16* px, UINT16* py)
 * Hardware:		Binded to Accelerometer
 * Output:          Returns -1 in case of collision
					Returns 0 in case of success
 * Parameters:		Pointers to X and Y UINT16 variables
 * Side Effects:    Takes some time (TO ESTIMATE)
 * Overview:        Reads data via I2C bus.
					Protocol cycles:
					1.	Send START
					2.	Send WRITE on Accelerometer address for writing
					3.	Expect ACK
					4.	Send Register address to start reading from
					5.	Expect ACK
					6.	Send RESTART
					5.	Send WRITE on Accelerometer address for reading
					6.	Expect ACK
					7. 	Send READ for X MSB
					8.	Send ACK
					9. 	Send READ for X LSB
					10.	Send ACK
					11. Send READ for Y MSB
					12.	Send ACK
					13. Send READ for Y LSB
					14.	Send NotACK
					15. Send STOP
 *****************************************************************************/
BYTE AccelerometerRead(UINT16* px, UINT16* py);

/******************************************************************************
 * Function:        BYTE AccelerometerWakeup(void)
 * Hardware:		Binded to Accelerometer
 * Output:          Returns -1 in case of collision
					Returns 0 in case of success
 * Side Effects:    Takes at least 50 ms to complete
 * Overview:        Wakes up the Accelerometer from sleep state via I2C bus.
					Protocol cycles:
					1.	Send START
					2.	Send WRITE on Accelerometer address for writing
					3.	Expect ACK
					4.	Send WRITE [00000000] on Accelerometer Control Register address
					5.	Expect ACK
					6.	Send WRITE [00000000] on Accelerometer Control Register address
					7.	Expect ACK
					8.	Send STOP
					9.	Delay of 50ms
 *****************************************************************************/
BYTE AccelerometerWakeup(void);

/******************************************************************************
 * Function:        BYTE AccelerometerSleep(void)
 * Hardware:		Binded to Accelerometer
 * Output:          Returns -1 in case of collision
					Returns 0 in case of success
 * Side Effects:    Takes at least 50 ms to complete
 * Overview:        Puts the Accelerometer in sleep state via I2C bus.
					Protocol cycles:
					1.	Send START
					2.	Send WRITE on Accelerometer address for writing
					3.	Expect ACK
					4.	Send WRITE [00000001] on Accelerometer Control Register address
					5.	Expect ACK
					6.	Send WRITE [00000001] on Accelerometer Control Register address
					7.	Expect ACK
					8.	Send STOP
					9.	Delay of 50ms
 *****************************************************************************/
/* SAVE SPACE ON ROM
BYTE AccelerometerSleep(void);
*/

/******************************************************************************
 * Function:        BYTE AccelerometerInit(void)
 * Hardware:		Binded to Accelerometer
 * Parameters:		Initializes the Accelerometer
 * Overview:        PIC is MASTER, Accelerometer is SLAVE
					Accelerometer works at 400KHz
					SSPADD register is Baud Rate
					Baud Rate value can be obtained via:
					Fosc / (4 * 400KHz) - 1 = 29 decimal = 0x1d hex
					Fosc = 48MHz
 *****************************************************************************/
void AccelerometerInit(void);

#endif	//ACCELEROMETER_H
