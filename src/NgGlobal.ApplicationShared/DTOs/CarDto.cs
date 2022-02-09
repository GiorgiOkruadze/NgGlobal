using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public List<TranslationDto> DriveTrainTranslations { get; set; }
        public List<TranslationDto> FuelTypeTranslations { get; set; }
        public List<TranslationDto> TransmissionTranslations { get; set; }
        public double Mile { get; set; }
        public string VinCode { get; set; }
        public List<ImageDto> Images { get; set; }
        public double Price { get; set; }
        public string SellerPhoneNumber { get; set; }
        public DateTime ArrivesIn { get; set; }
    }
}
