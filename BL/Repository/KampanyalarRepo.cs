using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BL.Data;
using Core.Dtos;
using BL.Wrapper;

namespace BL.Repository
{
    public class KampanyalarRepo
    {
        public KampanyalarGeciciDTO KaydetKampanyalarGecici(KampanyalarGecici entity, KampanyalarGeciciDTO dto)
        {
            try
            {
                using (var db = new ASIRGroupDBEntities())
                {
                    KampanyalarGecici originalEntity = db.KampanyalarGecici.Find(dto.Kampanyaid);

                    //İnsert
                    if (originalEntity == null)
                    {
                        entity = Wrapper.DtoToEntity.KampanyalarGeciciDTOsToKampanyalarGeciciEntities(entity, dto);
                        db.KampanyalarGecici.Add(entity);
                        try
                        {
                            var result = db.SaveChanges();
                            dto = Wrapper.EntityToDto.KampanyalarGeciciEntititiesToKampanylarGeciciDTOs(entity, new KampanyalarGeciciDTO());
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else //Update
                    {
                        try
                        {
                            entity = db.KampanyalarGecici.Where(q => q.id == dto.id).FirstOrDefault();
                            if (entity != null)
                                db.Entry(entity).CurrentValues.SetValues(dto);
                            db.SaveChanges();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    return dto;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<StokKartAramaWebDTO> KampanyalListesi(int spGenelID,  int page, int pageSize, int totalCount)
        //{
        //    try
        //    {
        //        using (var db = new ASIRGroupDBEntities())
        //        {
        //            var ent = db.StokKartAramaWeb("1", spGenelID, "", false, false, "");

        //            List<StokKartAramaWebDTO> kampanyaListesi = ent.Select(item => new StokKartAramaWebDTO
        //            {
        //                id = item.id,
        //                Sirket_Kod = item.Sirket_Kod,
        //                SKUKodu = item.SKUKodu,
        //                Marka = item.Marka,
        //                Birim = item.Birim,
        //                UreticiBarkodNo = item.UreticiBarkodNo,
        //                UrunBarkodNo = item.UrunBarkodNo,
        //                StokIsmi = item.StokIsmi,
        //                Aktif = item.Aktif,
        //                Ozellik = item.Ozellik,
        //                StokBitincePasif = item.StokBitincePasif,
        //                EkstraOzellik = item.EkstraOzellik,
        //                Renk = item.Renk,
        //                KayitTarihi = item.KayitTarihi,
        //                KullaniciKodu = item.KullaniciKodu,
        //                //KucukResim = item.KucukResim,
        //                Kampanyaid = item.Kampanyaid,
        //                Aciklamaid = item.Aciklamaid,
        //                DegisiklikTarihi = item.DegisiklikTarihi,
        //                DegKullaniciKodu = item.DegKullaniciKodu,
        //                AlisFiyati = item.AlisFiyati,
        //                DovizKodu = item.DovizKodu,
        //                GercekAlisFiyati = item.GercekAlisFiyati,
        //                En = item.En,
        //                Boy = item.Boy,
        //                Yukseklik = item.Yukseklik,
        //                Agirlik = item.Agirlik,
        //                Puan = item.Puan,
        //                KampanyaPuan = item.KampanyaPuan,
        //                UreticiStokKodu = item.UreticiStokKodu,
        //                KampanyaDosyaIsmi = item.KampanyaDosyaIsmi,
        //                Sira = item.Sira,
        //                StokAciklama = item.StokAciklama,
        //                StokTurkceAciklama = item.StokTurkceAciklama,
        //                Konseptid = item.Konseptid,
        //                KonseptTanim = item.KonseptTanim,
        //                TedarikciAdi = item.TedarikciAdi,
        //                FizikiStok = item.FizikiStok,
        //                MusAcikSipMik = item.MusAcikSipMik,
        //                AsirStokMik = item.AsirStokMik,
        //                BlokeStokMik = item.BlokeStokMik,
        //                TedStokMik = item.TedStokMik,
        //                TedAcikSipMik = item.TedAcikSipMik,
        //                AktarMik = item.AktarMik,
        //                AlisKDVOrani = item.AlisKDVOrani,
        //                SatisKDVOrani = item.SatisKDVOrani
        //            }).ToList();

        //            if (pageSize == 0)
        //                return kampanyaListesi;
        //            else
        //                return kampanyaListesi.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        //            //totalCount = kampanyaListesi.Count();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
