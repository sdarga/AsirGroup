//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BL.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class MusteriKampanyalari
    {
        public int id { get; set; }
        public string Sirket_Kod { get; set; }
        public string MKampanyaKodu { get; set; }
        public string MKampanyaAdi { get; set; }
        public int Musteriid { get; set; }
        public System.DateTime Tarih1 { get; set; }
        public System.DateTime Tarih2 { get; set; }
        public bool Aktif { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string KullaniciKodu { get; set; }
        public Nullable<System.DateTime> DegKayitTarihi { get; set; }
        public string DegKullaniciKodu { get; set; }
    
        public virtual CariKart CariKart { get; set; }
    }
}