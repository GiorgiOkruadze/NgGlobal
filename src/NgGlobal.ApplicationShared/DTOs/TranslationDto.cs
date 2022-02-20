using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class TranslationDto
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode
        {
            get
            {
                return Language.LanguageCode;
            }
        }
        public string Text { get; set; }
        [JsonIgnore]
        public LanguageDto Language { get; set; }
    }
}
