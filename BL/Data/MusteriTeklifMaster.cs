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
    
    public partial class MusteriTeklifMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MusteriTeklifMaster()
        {
            this.MusteriTeklifDetay = new HashSet<MusteriTeklifDetay>();
            this.MusteriTeklifDetay1 = new HashSet<MusteriTeklifDetay>();
        }
    
        public int id { get; set; }
        public string Sirket_Kod { get; set; }
        public System.DateTime Tarih { get; set; }
        public int Musteriid { get; set; }
        public int MKampanyaid { get; set; }
        public string TeklifAdi { get; set; }
        public int Opsiyon { get; set; }
        public string DovizKod { get; set; }
        public bool StokVerildi { get; set; }
        public System.DateTime KayitTarihi { get; set; }
        public string KullaniciKodu { get; set; }
        public Nullable<System.DateTime> DegisiklikTarihi { get; set; }
        public string DegKullaniciKodu { get; set; }
        public int sipmasterid { get; set; }
        public bool FiyatlariSonraKullanma { get; set; }
        public bool Webden { get; set; }
    
        public virtual CariKart CariKart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusteriTeklifDetay> MusteriTeklifDetay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusteriTeklifDetay> MusteriTeklifDetay1 { get; set; }
    }
}
