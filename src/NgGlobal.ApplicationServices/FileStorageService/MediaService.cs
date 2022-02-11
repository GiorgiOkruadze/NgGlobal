using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.FileStorageService
{
    public class MediaService : IMediaService
    {

        private readonly CloudinarySettings _cloudOption;
        private readonly Cloudinary _cloudinary;

        public MediaService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            _cloudOption = cloudinarySettings.Value;
            var acc = new Account()
            {
                ApiKey = _cloudOption.ApiKey,
                ApiSecret = _cloudOption.ApiSecret,
                Cloud = _cloudOption.CloudName
            };
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<DeletionResult> DeleteImage(string id)
        {
            var result = await _cloudinary.DestroyAsync(new DeletionParams(id));

            return result;
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile file)
        {
            var result = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                };

                result = await _cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }
    }
}
