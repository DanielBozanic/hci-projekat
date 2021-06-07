﻿using System;

namespace OrganizatorProslava.Services
{
    public class TipKorisnika
    {
        public const int Admin = 1;
        public const int Organizator = 2;
        public const int Klijent = 3;
    }

    public class TipKorisnikaOpis
    {
        public const string Admin = "Administrator";
        public const string Organizator = "Organizator";
        public const string Klijent = "Klijent";
    }

    public class Pol
    {
        public const string Zenski = "Z";
        public const string Muski = "M";
    }

    public class Poruke
    {
        public const string Poruka = "Poruka";
        public const string PodaciCeBitiIzgubljeni = "Svi uneseni podaci ce biti izgubljeni.";
        public const string OdbaciPodatke = "Da li ste sigurni da zelite odbaciti podatke?";
        public const string ImeObavezno = "Ime je obavezno polje.";
        public const string PrezimeObavezno = "Prezime je obavezno polje.";
        public const string KorisnickoImeObavezno = "Korisnicko Ime je obavezno polje.";
        public const string LozinkaObavezna = "Lozinka je obavezno polje.";
        public const string LozinkeRazlicite = "Unesene lozinke se ne podudaraju";
        public const string KorisnickoImePostoji = "Korisnicko ime vec postoji. Unesite drugo korisnicko ime.";
        public const string PogresnaPrijava = "Uneto je pogresno korisnicko ime ili lozinka.";
        public const string NijeNadjenKorisnik = "Nije pronadjen korisnik sa Id=";
        public const string KorisnikObrisan = "Korisnik {0} je obrisan.";
        public const string BrisiKorisnika = "Da li zelite da izbrisete selekovanog korisnika?";
        public const string IzmenaZapisNijeSelektovan = "Da bi izmenili red u tabeli morate ga prvo selektovati.";
        public const string BrisanjeZapisNijeSelektovan = "Da bi obrisali red u tabeli morate ga prvo selektovati.";
        public const string NijeNadjenSaradnik = "Nije pronadjen saradnik sa Id=";
        public const string SaradnikObrisan = "Saradnik {0} je obrisan.";
        public const string BrisiSaradnika = "Da li zelite da izbrisete selekovanog saradnika?";
        public const string NazivObavezan = "Naziv je obavezno polje.";
        public const string EmailObavezan = "Email je obavezno polje.";
        public const string TipSaradnikaObavezan = "Tip Saradnika je obavezno polje.";
        public const string EmailPogresanFormat = "Email je pogresnog formata.";
        public const string EmailMoraBitiJedinstven = "Email mora biti jedinstven u sistemu.";
        public const string ZauzetaPozicija = "Ne mozete postaviti sto na ovu poziciju u sali zato što je ona vec zauzeta.";
        public const string StoImaPozicijuNaMapi = "Ne možete postaviti sto {0} - '{1}' na mapu sale jer se on vec nalazi na njoj.";
    }

    public class StatusZabave
    {
        public const int Napravljena = 1;
        public const int UProcesu = 2;
        public const int Izbrisana = 3;
        public const int Zavrsena = 4;
    }
}
