//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizatorProslava.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saradnik
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int TipSaradnikaID { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public bool Obrisan { get; set; }
    }
}
