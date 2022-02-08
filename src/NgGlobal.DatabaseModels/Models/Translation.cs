using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class Translation:BaseEntity
    {
        public int TranslationKey { get;set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Text { get; set; }
    }
}
