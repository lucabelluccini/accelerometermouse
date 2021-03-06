# Platform Invoke in .NET

Data una function call (definita nel nostro codice managed) e un unmanaged called site (la funzione che verrà chiamata), ogni parametro della prima verrà "marshaled" (convertita) in un qualcosa di equivalente della seconda.

![http://i.msdn.microsoft.com/0h9e9t7d.pinvoke(en-us,VS.71).gif](http://i.msdn.microsoft.com/0h9e9t7d.pinvoke(en-us,VS.71).gif)

I dati marshaled vengono messi nel runtime stack e la funzione unmanaged viene invocata.
Il marshaling può essere complesso o trasparente a seconda dei casi.
Per tipi di dato semplice (come interi, floating point, Byte, ...), il marshaling è un blitting (copia Byte a Byte).
Il marshaling può essere evitato, come nei casi in cui è necessario passare strutture dati by reference al codice unmanaged (viene passato un puntatore a tale struttura). E' possibile ottenere maggior controllo sul marshaling, attraverso scelte esplicite sulla conversione.
Il comportamento di default del marshaling è controllato mediante DllImport e attributi MarshalAs.
Le stringhe introducono maggiore complessità a causa dei diversi tipi di formato. La runtime usa UTF-16 e dovranno essere marshaled in forma adatte alle chiamate (ANSI, UTF-8, ...).
Nel caso di costanti ed enumerazioni, è necessario ridefinirle mediante una enumerazione C# o costanti statiche in una classe.

Ci sono due differenze tra l'uso di Classi e Strutture per il passaggio dei parametri.
  1. Le strutture non necessitano di essere allocate sullo Heap, ma possono essere allcoate nello stack
  1. Le strutture sono impostate come LayoutKind.Sequential di default: in questo modo le dichiarazioni non necessitano di alcun attributo aggiuntivo per essere utilizzate con codice unmanaged
Queste differenze permettono alle strutture di essere passate by-value a funzioni unmanaged, al contrario delle Classi.
Inoltre, se la struttura è allocata sullo stack e la struttura contiene solo tipi blittabili, se viene passata una struttura al codice unmanaged by-reference, la struttura verrà passata direttamente al codice unmanaged senza copie intermedie. Cio significa che non sarà necessario specificare l'attributo Out per far effettuare modifiche al codice unmanaged.
Non appena la struttura contiene dati non blittabili, questa ottimizzazione non è più effettuabile.

In .NET 2.0 è stato introdotto un nuovo meccanismo per wrappare handle unmanaged.
Tale wrapper è la classe SafeHandle. Gli oggetti SafeHandle incapsulano un handle sottoforma di un IntPtr, ma esponendolo come SafeFileHandle o SafeWaitHandle, lo sviluppatore ha un guadagno in termini di type safety.
I SafeHandle inoltre impediscono di far riciclare gli handle.
Vengono trattati in modo particolare e verrà effettuato marshalling in modo automatico quando usati in chiamate P/Invoke. A seconda dell'utilizzo:
  * se sono parametri in uscita, il SafeHandle viene passato
  * se sono valori di ritorno, viene creata una nuova istanza della classe SafeHandle e il valore dell'handle è settata con il valore dell'IntPtr
  * se il passaggio è by-ref, il valore in uscita è ignorato e il valore di ritorno sarà inglobato in un SafeHandle
  * se fa parte di una struttura, il SafeHandle viene passato
Questa feature è stata utilizzata pesantemente nel codice del progetto.
