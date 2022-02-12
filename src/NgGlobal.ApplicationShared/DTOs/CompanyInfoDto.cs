using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class CompanyInfoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<TranslationDto> AddressTranslations { get; set; }
        public string Viber { get; set; }
        public string Facebook { get; set; }
        public string WhatsApp { get; set; }
    }
}
