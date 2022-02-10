using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class TranslationDto
    {
        public int? TranslationKey { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string Text { get; set; }
    }
}
