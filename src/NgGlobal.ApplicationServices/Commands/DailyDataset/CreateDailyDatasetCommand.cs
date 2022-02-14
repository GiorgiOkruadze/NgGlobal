using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NgGlobal.ApplicationServices.Commands
{
    public class CreateDailyDatasetCommand:IRequest<bool>
    {
        public string ImageBaseUrl { get; set; }
        public List<TranslationDto> TitleTranslations { get; set; }
        public List<TranslationDto> ShortDescriptionTranslations { get; set; }
        public List<TranslationDto> LongDescriptionTranslations { get; set; }
        [JsonIgnore]
        public IFormFile ImageFile { get; set; }
    }
}
