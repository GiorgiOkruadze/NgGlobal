using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Extensions
{
    public static class MediaExtensions
    {
        public static IFormFile Base64ToImage(this string equipmentFiles)
        {
            byte[] bytes = Convert.FromBase64String(equipmentFiles);
            MemoryStream stream = new MemoryStream(bytes);

            IFormFile file = new FormFile(stream, 0, bytes.Length, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            return file;
        }
    }
}
