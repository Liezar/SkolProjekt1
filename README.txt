Mitt program använder sig utav filer för att skapa, hämta och lagra produkter. 
För att skapa produkter med olika typer av material, priser, storlekar osv, så skapas det en katalog som heter ProductData. Katalogen skapas när man försöker skapa en produkt.
Katalogen ska då ligga under "C:\USERS\USER\ProductData". Katalogen innehåller 4 filer där man kan fylla på med data.
Nedan finner du ett exempel på hur man fyller på materialfilen med data:

Ull
Bomull
Linne
Elastan
Siden

Det är bara att göra en ny radmatning och skriva in ny data, samma gäller för resten av filerna.
OBS: Om datafilerna är tomma och du försöker skapa en produkt så kommer det att skrivas ut "N/A" i det fältet som saknar data.

I mitt programm så kan du välja hur du vill spara produkterna. Det finns 2 val, JSON eller det som jag kallar PLAIN.
Du kan välja på vilket sätt som du sparar på, i programmet under inställningarna. Standard är PLAIN.
Dessa filer sparas här: "C:\USERS\USER\

Det är också sparsättet som styr över vilken sorts fil som ska läsas in, så om du har valt JSON i inställningarna, så är det JSON-filen som kommer att läsas och skrivas ut.
