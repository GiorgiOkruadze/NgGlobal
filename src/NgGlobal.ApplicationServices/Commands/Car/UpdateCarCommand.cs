﻿using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Commands
{
    public class UpdateCarCommand:IRequest<bool>
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string Manufacturer { get; set; }
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
