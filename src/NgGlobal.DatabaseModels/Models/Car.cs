using System;
using System.Collections.Generic;

namespace NgGlobal.DatabaseModels.Models
{
    public class Car:BaseEntity
    {
        public int UserId { get; set; }
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public List<Translation> DriveTrainTranslations { get; set; }
        public List<Translation> FuelTypeTranslations { get; set; }
        public List<Translation> TransmissionTranslations { get; set; }
        public double Mile { get; set; }
        public string VinCode { get; set; }
        public List<Image> Images { get; set; }
        public double Price { get; set; }
        public string SellerPhoneNumber { get; set; }
        public DateTime ArrivesIn { get; set; }
    }
}
