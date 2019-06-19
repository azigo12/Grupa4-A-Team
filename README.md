# Grupa1-A-Team
# E-lections

https://e-lections.azurewebsites.net

### Članovi tima:
__Denis Selimović, Lamija Vrnjak, Amila Žigo__

## Opis teme:
* U predstojećem tekstu bit će opisana aplikacija za elektronsko glasanje na izborima. Idući u korak s vremenom, ideja se sama nameće. Aplikacija omogućava glasačima olakšan izlazak na izbore jer je dostupna svima i lako se koristi, a pored toga predstavlja i platformu za online izborne kampanje. Aplikacija će služiti glasačima da saznaju nešto više o kandidatima za koje mogu glasati, olakšati im sam proces glasanja kao i pružiti uvid u aktuelne izvještaje u toku i po završetku izbora. Kandidati će moći ažurirati svoje profile i na efikasan način prenijeti svoje ideje.

## Specifikacija funkcionalnosti:
* Svaki korisnik aplikacije popunjava formular sa osobnim podacima pri registraciji. Ti podaci su: ime i prezime, datum rođenja, broj lične karte, jedinstveni matični broj, adresa (ulica, broj, kanton, država) prebivališta i spol te lozinka (koju sami biraju). Podaci moraju proći validaciju (to radi sistem)
* Prva vrsta korisnika aplikacije su *administratori*. Glavni administrator ima mogućnost da registruje dodatne administratore (na gore opisan način), nakon čega će oni moći pristupiti servisu sa svojim pristupnim podacima (jmbg i lozinka)
* Administrator kreira izbore što uključuje specificiranje detalja o izborima kao što su geografsko područje glasača koji mogu glasati na izborima, koliko se glasova treba dodijeliti da bi jedan listić bio ispravan i funkcije za koje se glasa. Administrator zatim kreira konkurs koji traje po njegovom određenju. Kada zaprimi prijave na konkurs administrator ih razmatra i prihvata odnosno odbija. 
* Administrator registruje stranke čiji članovi se kasnije prijavljuju da budu kandidati
* Administrator kreira sve vrste izvještaja koji su ponuđeni (broj glasova po kandidatima, geografskim područjima, godištu, spolu itd.). Neke od ovih izvještaja može učiniti javnima nakon čega će i ostali korisnici sistema (glasači) moći da ih vide
* Druga vrsta korisnika su *glasači*. Glasači se registruju samostalno tako što popune formular sa osobnim podacima koji se zatim validiraju, a sistemu će pristupati sa jmbg-om i lozinkom
* Glasači glasaju na izborima (na kojima mogu glasati) tako što se putem interfejsa prijave da glasaju na tim izborima i kada oni započnu obave glasanje. To uključuje popunjavanje glasačkog listića.  Listić je ispravan ukoliko ima onoliko glasova koliko je administrator odredio pri kreiranju izbora. Nakon validacije listića, glas se bilježi i ažurira se statistika sa novim glasom
* Glasači putem aplikacije mogu potražiti profile kandidata koji ih interesuju i čitati ono što su oni napisali
* Ukoliko postoje javno dostupni izvještaji, glasači ih mogu pregledati
* Treća vrsta korisnika su *kandidati*. Kandidati dobivaju taj status tako što se preko svog glasačkog računa prijave na konkurs za određenu funkciju za koju se glasa pri čemu navode da li su član neke stranke i koje te čekaju odobrenje administratora
* Obzirom da su i kandidati zapravo glasači oni imaju sve mogućnosti nabrojane u tekstu iznad. Pored toga, imaju mogućnost uređivanja vlastitog profila sve dok izbori ne započnu. 

## Specifikacija funkcionalnosti web servisa:
* Prilikom registracije glasač mora navesti svoju e-mail adresu na koju će mu biti poslan e-mail sa kodom. Unosom tog koda mu se osposobljava račun.

## Akteri:
* __Administrator__ - osoba koja je zadužena za kreiranje i specificiranje detalja o izborima, registraciju novih administratora, odobravanje kandidatskog statusa te kreiranje izvještaja
* __Glasač__ - osoba koja glasa na izborima i ima mogućnost uvida u profile kandidata 
* __Kandidat__ - osoba za koju se može glasati na izborima, ažurira svoj profil sa informacijama o sebi i svojoj kampanji
* __Sistem__ - akter koji služi za pozadinsku verifikaciju podataka, ažuriranje statistike i sl.


