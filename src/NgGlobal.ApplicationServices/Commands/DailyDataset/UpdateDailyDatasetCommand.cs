using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Commands
{
    public class UpdateDailyDatasetCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public List<TranslationDto> TitleTranslations { get; set; }
        public List<TranslationDto> ShortDescriptionTranslations { get; set; }
        public List<TranslationDto> LongDescriptionTranslations { get; set; }
        public DailyDatasetImageDto Image { get; set; }
    }
}
