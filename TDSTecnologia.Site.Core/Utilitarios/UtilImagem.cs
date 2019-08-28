using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TDSTecnologia.Site.Core.Utilitarios
{
    public class UtilImagem
    {
        public static async Task<byte[]> ConverterParaByte(IFormFile arquivo)
        {
            MemoryStream ms = new MemoryStream();
            if (arquivo != null && arquivo.ContentType.ToLower().StartsWith("image/"))
            {
                await arquivo.OpenReadStream().CopyToAsync(ms);
                return ms.ToArray();
            }
            return null;
        }
    }
}
