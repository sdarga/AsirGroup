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
    
    public partial class Kampanyalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kampanyalar()
        {
            this.StokKarti = new HashSet<StokKarti>();
        }
    
        public int id { get; set; }
        public string Sirket_Kod { get; set; }
        public string Tanim { get; set; }
        public bool Aktif { get; set; }
        public int Kategoriid { get; set; }
        public int Tedarikciid { get; set; }
        public string Aciklama { get; set; }
        public Nullable<System.DateTime> KayitTarihi { get; set; }
        public string KullaniciKodu { get; set; }
        public Nullable<System.DateTime> DegisiklikTarihi { get; set; }
        public string DegKullaniciKodu { get; set; }
        public bool PortaldeGoster { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StokKarti> StokKarti { get; set; }
    }
}
