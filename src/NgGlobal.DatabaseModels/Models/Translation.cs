using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class Translation:BaseEntity
    {
        public int? DriveTrainId { get;set; }
        public int? FuelTypeId { get; set; }
        public int? TransmissionId { get; set; }
        public int? AddressId { get; set; }
        public int? CompanyServiceTitleId { get; set; }
        public int? CompanyServiceShortDescriptionId { get; set; }
        public int? CompanyServiceLongDescriptionId { get; set; }
        public int? DailyDatasetTitleId { get; set; }
        public int? DailyDatasetShortDescriptionId { get; set; }
        public int? DailyDatasetLongDescriptionId { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Text { get; set; }
    }
}
