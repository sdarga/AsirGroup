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
    
    public partial class StokKartiTanim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StokKartiTanim()
        {
            this.StokKarti = new HashSet<StokKarti>();
        }
    
        public int id { get; set; }
        public string Sirket_Kod { get; set; }
        public bool Aktif { get; set; }
        public string StokAciklama { get; set; }
        public string StokTurkceAciklama { get; set; }
        public string GTIPKodu { get; set; }
        public double AlisKDVOrani { get; set; }
        public double SatisKDVOrani { get; set; }
        public bool KdvDahil { get; set; }
        public int Sira { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string KullaniciKodu { get; set; }
        public Nullable<System.DateTime> DegisiklikTarihi { get; set; }
        public string DegKullaniciKodu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StokKarti> StokKarti { get; set; }
    }
}
