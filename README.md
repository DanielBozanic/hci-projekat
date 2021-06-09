# Projekat iz predmeta Interakcija čovek računar - Tim 4.4

Članovi tima:
* Daniel Božanić SW-63/2018
* Tatjana Gavrilović SW-53/2018
* Milica Đumić SW-27/2018
* Bogdana Miletić SW-56/2017

# Uputstvo za pokretanje projekta

## Neophodni programi
Da bi se aplikacija pokrenula potrebno je instalirati sledeće programe:
* [Microsoft SQL Server 2019](https://www.microsoft.com/en-us/Download/details.aspx?id=101064)
* [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)

### Pokretanje SUBP-a
Nakon instaliranja i pokretanja SQL Server Management Studio-a, izvršite skriptu [Baza.sql](./Baza.sql).

### Pokretanje aplikacije
U fajlu *connections.config* potrebno je u okviru *data source* atributa staviti naziv SQL Server-a.
Fajl *connections.config* se nalazi u zip arhivi [connectionsConfigFajl](./).
Na kraju je potrebno *connections.config* fajl ubaciti u [folder](./OgranizatorProslava/OgranizatorProslava) ./OgranizatorProslava/OgranizatorProslava.