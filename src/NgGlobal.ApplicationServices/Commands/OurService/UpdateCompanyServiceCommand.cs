using MediatR;
using Microsoft.AspNetCore.Http;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NgGlobal.ApplicationServices.Commands
{
    public class UpdateCompanyServiceCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string ImageBaseUrl { get; set; }
        public int CompanyServiceImageId { get; set; }
        public List<TranslationDto> TitleTranslations { get; set; }
        public List<TranslationDto> ShortDescriptionTranslations { get; set; }
        public List<TranslationDto> LongDescriptionTranslations { get; set; }
        [JsonIgnore]
        public IFormFile ImageFile { get; set; }
    }
}
