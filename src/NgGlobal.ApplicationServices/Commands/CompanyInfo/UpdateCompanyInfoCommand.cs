using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Commands
{
    public class UpdateCompanyInfoCommand:IRequest<bool>
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
