﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class CompanyServiceDto
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public List<TranslationDto> TitleTranslations { get; set; }
        public List<TranslationDto> ShortDescriptionTranslations { get; set; }
        public List<TranslationDto> LongDescriptionTranslations { get; set; }
        public CompanyServiceImageDto Image { get; set; }
    }
}
