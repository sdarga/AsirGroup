using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Data;
using Core.Dtos;

namespace BL.Wrapper
{
    public class EntityToDto
    {
        public static KampanyalarGeciciDTO KampanyalarGeciciEntititiesToKampanylarGeciciDTOs(KampanyalarGecici entity, KampanyalarGeciciDTO dto)
        {
            try
            {
                dto.id = entity.id;
                dto.Genelid = entity.Genelid;
                dto.Kampanyaid = entity.Kampanyaid;
                dto.Kategoriid = entity.Kategoriid;
                dto.Tanim = entity.Tanim;
                dto.Aktif = entity.Aktif;
                dto.Secim = entity.Secim;
                dto.KayitTarihi = entity.KayitTarihi;
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
