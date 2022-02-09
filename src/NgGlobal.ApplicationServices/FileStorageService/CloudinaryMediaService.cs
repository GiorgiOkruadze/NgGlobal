using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.FileStorageService
{
    public class CloudinaryMediaService
    {
        public string ApiKey { get; set; } = "917751897546634";
        public string ApiSecret { get; set; } = "zJjTgbtW6whsT-feRg5F-LGs-KM";
        public string Cloud { get; set; } = "itacademystep-develoeprs";


        public string UploadFile(string filePath)
        {
            var myAccount = new Account { ApiKey = ApiKey, ApiSecret = ApiSecret, Cloud = Cloud };
            Cloudinary _cloudinary = new(myAccount);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.Url.AbsoluteUri;
        }
    }
}
