# THE\_TOPO

Progetto sviluppato per il corso di Programmazione di Sistema al Politecnico di Torino nell'A.A. 2009/2010.

Docente: Malnati Giovanni

Gruppo 18:
  * Allario Marco
  * Belluccini Luca
  * Cancedda Stefano
  * Ferraro Andrea

## Hardware e firmware

Il progetto iniziale del mouse è stato modificato aggiungendo un pulsante su una delle porte disponibili (RC1).
Per lo sviluppo del firmware si è partiti dallo scheletro di un firmware demo di un mouse avente funzionalità  minimali.
Durante lo sviluppo il descrittore della periferica è stato modificato più volte.
Il file "usb\_descriptors.c" contiene il device descriptor, configuration descriptor (interface, hid e endpoint descriptors).
Infine c'è l'HID Report descriptor. L'HID Report Descriptor è passato da essere un descrittore standard di un mouse USB a report composito.
Infatti, al momento della connessione e dell'enumerazione, il device verrà  rilevato come 3 periferiche distinte:
  * HID Input Device
  * Mouse
  * Keyboard
Nel descrittore, esse possono essere riassunte in 3 blocchi:
  * HID Input Device
```
Usage Page (Vendor Defined Page 1)
 Usage (Vendor Usage 1)
 Collection (Application)
  {
   Report ID FID_WRITE_TO_EEPROM
   Usage (Vendor Usage 1)
   ... /* descrizione delle dimensione e del tipo di dati del report */ ...
   Feature Report
  }
  {
   Report ID FID_GAIN_XY
   Usage (Vendor Usage 1)
   ... /* descrizione delle dimensione e del tipo di dati del report */ ...
   Feature Report
  }
  ... /* Uno per ogni Feature Report */ ...
 End Collection (Application)
```
  * Mouse
```
Usage Page (Generic Desktop)
 Usage (Mouse)
 Collection (Application)
  Report ID Mouse
  ... /* Descrittore standard di un mouse USB */ ...
 End Collection (Application)
```
  * Keyboard
```
Usage Page (Generic Desktop)
 Usage (Keyboard)
 Collection (Application)
  Report ID Keyboard
  ... /* Descrittore standard di una keyboard USB */ ...
 End Collection (Application)
```

In tal modo, ad ogni invio o ricezione di input, output o feature report, sarà  necessario specificare nel primo Byte l'ID del report che stiamo comunicando.
Nel caso l'Host necessiti di un dato da parte del mouse dovrà  richiedere un Input Report con ID Mouse (0x01).
Nel caso il device voglia comportarsi da tastiera, invierà  un Input Report con ID Keyboard (0x02).
I casi estranei ai due precedenti sono costituiti da Feature Report che hanno il primo Byte corrispondente alla Feature impostata dall'Host (Set) o richiesta dall'Host (Get).

Esempio:

| HOST | | DEVICE |
|:-----|:|:-------|
| SetFeatureReport(FID\_WRITE\_TO\_EEPROM) | `---> [0x15][0x01] --->` | SetFeatureReport Handle Function: |
|      | | `[0x15] is FID_WRITE_TO_EEPROM` |
|      | | `[0x01] tells me to write parameters to EEprom` |
| GetFeatureReport(FID\_GAIN\_XY) | `---> [0x25][0x00][0x00][0x00][0x00] --->` | GetFeatureReport Handle Function: |
|      | | `[0x25] is FID_GAIN_XY` |
|      | | `[0x??] = GAIN X MSB` |
|      | | `[0x??] = GAIN X LSB` |
|      | | `[0x??] = GAIN Y MSB` |
|      | | `[0x??] = GAIN Y LSB` |
|      | `<--- [0x25][0xXY][0xWK][0xJH][0xVQ] <---` |        |

Passando al punto di vista logico del funzionamento del firmware, abbiamo un main loop preceduto da una fase di inizializzazione.
Esclusa la parte di inizializzazione dell'USB, che è standard e già  gestita dal codice fornito dalla Microchip, l'inizializzaizone specifica nel nostro caso è costituita dal settaggio di alcune variabili a valori predefiniti e il caricamento (o prima scrittura utilizzando valori di default) dei parametri di funzionamento del mouse dalla EEprom.
Il main loop può essere diviso logicamente nelle seguenti fasi:
```
// Loop
 // Check di flag che impone di scrivere i parametri correnti sulla EEprom (esso viene settato da una SetFeature FID_WRITE_TO_EEPROM con parametro 0x01 e inibito)
 // Check di flag che impone di leggere i parametri correnti sulla EEprom (esso viene settato da una SetFeature FID_WRITE_TO_EEPROM con parametro 0x00 e inibito)
	
 // Lettura dall'accelerometro della X e della Y via I2C
		
  // Filtro (media tra vecchi e nuovi valori di X e Y)
  // Calcolo di X e Y come distanza da un punto centrale di riferimento e corretto da offset (impostato da eventuali SetFeature FID_OFFSET_XY) e scalato di 64
  // Check per individuare uno shake: viene calcolato il modulo del vettore X^2 + Y^2 (non corretto da offset), chiamato "violence"
   // Se "violence" supera una certa soglia, viene incrementato il contatore di Shake e se è il primo Shake rilevato, viene settato un timer bindato a una ISR

  // I valori X e Y vengono scalati del gain (ricevuto da eventuali SetFeatureReport FID_GAIN_XY)
  // I valori X e Y possono essere specchiati a seconda di due flag (ricevuti da eventuali SetFeatureReport FID_MIRROR_XY)
  // I valori X e Y vengono ruotati sulla base di una matrice di rotazione (ricevuta da eventuali SetFeatureReport FID_ROTATION_COEFF)

 // Se l'ultima trasmissione è andata a buon fine
	
  // Check dei pulsanti: Middle (Left e Right premuti insieme)
  // Check del pulsante Left
  // Check del pulsante Right

  // Se la ISR riferita allo shake ha settato un flag "isShaked"
   // Preparare l'invio di un Report Keyboard contenente la pressione di tasti programmabili via SetFeatureReport FID_KEYBOARD_SHAKEACTION
   // Preparare il successivo invio di un Report Keyboard con tasti non premuti
   // Inviare il primo Report: all'iterazione successiva verrà  inviato il secondo e ripristinato il flag "isShaked"
  // Altrimenti
   // Invia il Report Mouse con i dati ottenuti precedentemente
```

L'ISR dello shake non fa altro che controllare lo Shake counter: se supera una certa soglia (pari a 4), viene settata la variabile "isShaked" e resettato il contatore.
Il valore 4 è stato scelto in modo da farlo corrispondere ad un movimento in avanti ed indietro ripetuto 2 volte (uno shake).

Alcune note:
  * gli switch hanno un sistema di debouncing addizionale in software (un delay di alcuni ms)
  * i valori di guadagno, rotazione sono implementati usando valori interi, arrotondando alla seconda cifra decimale (vengono inviati moltiplicati per 100, utilizzati e il risultato diviso per 100)
  * gli algoritmi di comunicazione I2C sono spiegati nel dettaglio nel file "Accelerometer.h"
  * la scrittura e lettura su EEprom è stata effettuata utilizzando funzioni già  disponibili nel framework della Microchip
  * è possibile capire se è necessario scrivere per la prima volta la EEprom testando una cella di memoria della EEprom: ad ogni re-flashing l'area della EEprom (a meno di contenuti statici impostabili con #pragma ROM ...) viene livellata ad un contenuto di default (0xFF)
  * non è stato possibile implementare un movimento assoluto del mouse per problemi di mapping con lo schermo

## Applicazione di calibrazione in C#

L'applicazione in C# permette di impostare i seguenti parametri del mouse. La tabella descrive il comportamento del device alla ricezione di GetFeatureReport o SetFeatureReport.
Essa è quindi l'interfaccia di comunicazione logica tra Host e Device.

| **REPORT ID** | **SIZE(Bytes)** | **ON GET FEATURE** | **ON SET FEATURE** | **DATA DETAILS** |
|:--------------|:----------------|:-------------------|:-------------------|:-----------------|
| FID\_OFFSET\_XY | 4               | Returns Offsets X,Y | Sets Offsets X,Y   | 2 INT16          |
| FID\_RAW\_XY  | 4               | Returns Raw Values X,Y | -                  | 2 UINT16         |
| FID\_WRITE\_TO\_EEPROM | 1               | -                  | Starts Write/Read to/from EEPROM | 1 BYTE           |
|               |                 |                    |                    | (0x01 to Write, 0x00 to Read) |
| FID\_KEYBOARD\_SHAKEACTION | 3               | Returns Keyboard Action Keys | Sets Keyboard Action Keys | 1 BYTE + 2 BYTES |
|               |                 |                    |                    | (Keyboard Modifier + 2 Keys) |
| FID\_IS\_CALIBRATING | 1               | -                  | Enable/Unable Mouse Calibration | 1 BYTE           |
|               |                 |                    |                    | (0x01 to disable cursor movement) |
| FID\_MIRROR\_XY | 1               | Returns Mirroring status | Enable/Unable X,Y Mirroring | 1 BYTE           |
|               |                 |                    |                    | (Bit0:MirrorX,Bit1:MirrorY) |
| FID\_SHAKES\_WES | 2               | Returns size of Event Window in ms | Sets size of Event Window in ms | 1 UINT16         |
| FID\_GAIN\_XY | 4               | Returns Gain X,Y   | Sets Gain X,Y      | 2 UINT16         |
| FID\_ROTATION\_COEFF | 8               | Returns Rotation Coefficients | Set Rotation Coefficients | 4 INT16          |
| FID\_PIVOT\_XY | 4               | Returns Pivot X,Y  | Sets Pivot X,Y     | 2 UINT16         |

La prima fase è stata quella di costruire un wrapper alla "Hid.dll", in modo da avere disponibili chiamate come:
```
[ DllImport( "hid.dll", SetLastError=true ) ]
internal static extern Boolean HidD_GetFeature( SafeFileHandle HidDeviceObject, Byte[] lpReportBuffer, Int32 ReportBufferLength );        
```

Il wrapper è stato costruito sfruttando la P/Invoke ([PlatformInvoke](PlatformInvoke.md)), che consente di eseguire codice non managed (il codice della libreria di sistema che fornisce interazione con periferiche HID) in un contesto managed (la nostra applicazione in .NET). Un approfondimento è disponibile nell'appendice A.
Una volta ottenute tutte le chiamate necessarie per interagire con le periferiche USB HID, è stato possibile procedere con la comunicazione vera e propria.

L'applicazione ha una schermata iniziale che auto-rileva la presenza del device sulla base del Product ID e Vendor ID.
Se il dispositivo viene rilevato, è possibile accedere ad una finestra di configurazione.
La configurazione consiste nel poter impostare parametri quali:
  * Rotazione del mouse rispetto all'asse Z
  * Inclinazione del mouse rispetto all'asse X e Y
  * "Sensibilità " o guadagno del mouse
  * Lo shortcut da tastiera che deve essere scatenato al momento in cui avviene uno shake

Per quanto riguarda l'inclinazione del mouse rispetto all'asse X e Y, è possibile far eseguire una sorta di auto-taratura.
Un pulsante permette di accedere ad una notifica di pre-calibrazione: alla pressione del tasto 'OK' il movimento del cursore verrà  inibito e l'utente deve posizionare il mouse nel modo in cui vuole utilizzarlo.
Dopo 2 secondi tale posizione viene campionata per poter essere utilizzata.

I valori della rotazione e guadagno sono inviati al mouse in formato intero (viene eseguito un arrotondamento alla seconda cifra decimale, moltiplicando per 100 il valore). Per questo l'inclinazione potrebbe essere ottenuta in modo impreciso dal mouse. La granularità  è di circa 3 gradi.

Avendo la possibilità  di poter scegliere singolarmente i parametri da inviare o ricevere, ogni controllo del form è costituito in sostanza da controlli sui valori introdotti/ottenuti, conversioni in Byte e chiamate di una o più Set/Get Feature Report.
