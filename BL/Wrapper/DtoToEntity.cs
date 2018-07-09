using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Data;
using Core.Dtos;

namespace BL.Wrapper
{
    public class DtoToEntity
    {
        public static KampanyalarGecici KampanyalarGeciciDTOsToKampanyalarGeciciEntities(KampanyalarGecici entity, KampanyalarGeciciDTO dto)
        {
            try
            {
                entity.id = dto.id;
                entity.Genelid = dto.Genelid;
                entity.Kampanyaid = dto.Kampanyaid;
                entity.Kategoriid = dto.Kategoriid;
                entity.Tanim = dto.Tanim;
                entity.Aktif = dto.Aktif;
                entity.Secim = dto.Secim;
                entity.KayitTarihi = dto.KayitTarihi;
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
