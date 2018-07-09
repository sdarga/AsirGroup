﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ASIRGroupDBEntities : DbContext
    {
        public ASIRGroupDBEntities()
            : base("name=ASIRGroupDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CariKart> CariKart { get; set; }
        public virtual DbSet<DescriptionGecici> DescriptionGecici { get; set; }
        public virtual DbSet<Kampanyalar> Kampanyalar { get; set; }
        public virtual DbSet<KampanyalarGecici> KampanyalarGecici { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Konseptler> Konseptler { get; set; }
        public virtual DbSet<KonseptlerGecici> KonseptlerGecici { get; set; }
        public virtual DbSet<MusterilerGecici> MusterilerGecici { get; set; }
        public virtual DbSet<MusteriSiparisDetay> MusteriSiparisDetay { get; set; }
        public virtual DbSet<MusteriSiparisMaster> MusteriSiparisMaster { get; set; }
        public virtual DbSet<MusteriTeklifDetay> MusteriTeklifDetay { get; set; }
        public virtual DbSet<MusteriTeklifMaster> MusteriTeklifMaster { get; set; }
        public virtual DbSet<Sirketler> Sirketler { get; set; }
        public virtual DbSet<StokKarti> StokKarti { get; set; }
        public virtual DbSet<StokKartiTanim> StokKartiTanim { get; set; }
        public virtual DbSet<WebKullanicilari> WebKullanicilari { get; set; }
        public virtual DbSet<MusteriTeklifDetayGecici> MusteriTeklifDetayGecici { get; set; }
        public virtual DbSet<MusteriTeklifDetayGeciciSil> MusteriTeklifDetayGeciciSil { get; set; }
        public virtual DbSet<Sabitler> Sabitler { get; set; }
        public virtual DbSet<MusteriKampanyalari> MusteriKampanyalari { get; set; }
        public virtual DbSet<WebKullaniciYetkileri> WebKullaniciYetkileri { get; set; }
    
        public virtual int DescriptionGetir(string sp_Sirket_Kod, Nullable<int> spGenelid, Nullable<bool> spSecim, Nullable<int> spTeklifMasterid)
        {
            var sp_Sirket_KodParameter = sp_Sirket_Kod != null ?
                new ObjectParameter("sp_Sirket_Kod", sp_Sirket_Kod) :
                new ObjectParameter("sp_Sirket_Kod", typeof(string));
    
            var spGenelidParameter = spGenelid.HasValue ?
                new ObjectParameter("spGenelid", spGenelid) :
                new ObjectParameter("spGenelid", typeof(int));
    
            var spSecimParameter = spSecim.HasValue ?
                new ObjectParameter("spSecim", spSecim) :
                new ObjectParameter("spSecim", typeof(bool));
    
            var spTeklifMasteridParameter = spTeklifMasterid.HasValue ?
                new ObjectParameter("spTeklifMasterid", spTeklifMasterid) :
                new ObjectParameter("spTeklifMasterid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DescriptionGetir", sp_Sirket_KodParameter, spGenelidParameter, spSecimParameter, spTeklifMasteridParameter);
        }
    
        public virtual int KampanyalariGetir(string sp_Sirket_Kod, Nullable<int> spGenelid, Nullable<bool> spSecim, Nullable<int> spTeklifMasterid, Nullable<bool> spPasiflerideGoster)
        {
            var sp_Sirket_KodParameter = sp_Sirket_Kod != null ?
                new ObjectParameter("sp_Sirket_Kod", sp_Sirket_Kod) :
                new ObjectParameter("sp_Sirket_Kod", typeof(string));
    
            var spGenelidParameter = spGenelid.HasValue ?
                new ObjectParameter("spGenelid", spGenelid) :
                new ObjectParameter("spGenelid", typeof(int));
    
            var spSecimParameter = spSecim.HasValue ?
                new ObjectParameter("spSecim", spSecim) :
                new ObjectParameter("spSecim", typeof(bool));
    
            var spTeklifMasteridParameter = spTeklifMasterid.HasValue ?
                new ObjectParameter("spTeklifMasterid", spTeklifMasterid) :
                new ObjectParameter("spTeklifMasterid", typeof(int));
    
            var spPasiflerideGosterParameter = spPasiflerideGoster.HasValue ?
                new ObjectParameter("spPasiflerideGoster", spPasiflerideGoster) :
                new ObjectParameter("spPasiflerideGoster", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("KampanyalariGetir", sp_Sirket_KodParameter, spGenelidParameter, spSecimParameter, spTeklifMasteridParameter, spPasiflerideGosterParameter);
        }
    
        public virtual ObjectResult<KonseptleriGetir_Result> KonseptleriGetir(string sp_Sirket_Kod, Nullable<int> spGenelid, Nullable<bool> spSecim)
        {
            var sp_Sirket_KodParameter = sp_Sirket_Kod != null ?
                new ObjectParameter("sp_Sirket_Kod", sp_Sirket_Kod) :
                new ObjectParameter("sp_Sirket_Kod", typeof(string));
    
            var spGenelidParameter = spGenelid.HasValue ?
                new ObjectParameter("spGenelid", spGenelid) :
                new ObjectParameter("spGenelid", typeof(int));
    
            var spSecimParameter = spSecim.HasValue ?
                new ObjectParameter("spSecim", spSecim) :
                new ObjectParameter("spSecim", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KonseptleriGetir_Result>("KonseptleriGetir", sp_Sirket_KodParameter, spGenelidParameter, spSecimParameter);
        }
    
        public virtual int MusteriKampanyalariGetir(string sp_Sirket_Kod, Nullable<System.DateTime> spTarih, Nullable<int> spGenelid)
        {
            var sp_Sirket_KodParameter = sp_Sirket_Kod != null ?
                new ObjectParameter("sp_Sirket_Kod", sp_Sirket_Kod) :
                new ObjectParameter("sp_Sirket_Kod", typeof(string));
    
            var spTarihParameter = spTarih.HasValue ?
                new ObjectParameter("spTarih", spTarih) :
                new ObjectParameter("spTarih", typeof(System.DateTime));
    
            var spGenelidParameter = spGenelid.HasValue ?
                new ObjectParameter("spGenelid", spGenelid) :
                new ObjectParameter("spGenelid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MusteriKampanyalariGetir", sp_Sirket_KodParameter, spTarihParameter, spGenelidParameter);
        }
    
        public virtual ObjectResult<StokKartAramaWeb_Result> StokKartAramaWeb(string sp_Sirket_Kod, Nullable<int> spGenelid, string spAramaMetni, Nullable<bool> spBakiyeler, Nullable<bool> spResimli, string spKullaniciRole)
        {
            var sp_Sirket_KodParameter = sp_Sirket_Kod != null ?
                new ObjectParameter("sp_Sirket_Kod", sp_Sirket_Kod) :
                new ObjectParameter("sp_Sirket_Kod", typeof(string));
    
            var spGenelidParameter = spGenelid.HasValue ?
                new ObjectParameter("spGenelid", spGenelid) :
                new ObjectParameter("spGenelid", typeof(int));
    
            var spAramaMetniParameter = spAramaMetni != null ?
                new ObjectParameter("spAramaMetni", spAramaMetni) :
                new ObjectParameter("spAramaMetni", typeof(string));
    
            var spBakiyelerParameter = spBakiyeler.HasValue ?
                new ObjectParameter("spBakiyeler", spBakiyeler) :
                new ObjectParameter("spBakiyeler", typeof(bool));
    
            var spResimliParameter = spResimli.HasValue ?
                new ObjectParameter("spResimli", spResimli) :
                new ObjectParameter("spResimli", typeof(bool));
    
            var spKullaniciRoleParameter = spKullaniciRole != null ?
                new ObjectParameter("spKullaniciRole", spKullaniciRole) :
                new ObjectParameter("spKullaniciRole", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StokKartAramaWeb_Result>("StokKartAramaWeb", sp_Sirket_KodParameter, spGenelidParameter, spAramaMetniParameter, spBakiyelerParameter, spResimliParameter, spKullaniciRoleParameter);
        }
    }
}
