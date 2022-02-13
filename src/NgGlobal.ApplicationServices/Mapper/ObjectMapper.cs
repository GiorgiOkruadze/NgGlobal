using AutoMapper;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.DatabaseModels.Models;
using System.Linq;

namespace NgGlobal.ApplicationServices.Mapper
{
    public class ObjectMapper:Profile
    {
        public ObjectMapper()
        {
            CreateMap<Language, LanguageDto>().ReverseMap();

            CreateMap<Translation,TranslationDto>()
                .ForMember(dt => dt.Language, db => db.MapFrom(o => o.Language))
                .ReverseMap();

            CreateMap<Image, ImageDto>()
                .ReverseMap();

            CreateMap<Car, CarDto>()
                .ForMember(dt => dt.DriveTrainTranslations, db => db.MapFrom(o => o.DriveTrainTranslations))
                .ForMember(dt => dt.FuelTypeTranslations, db => db.MapFrom(o => o.FuelTypeTranslations))
                .ForMember(dt => dt.TransmissionTranslations, db => db.MapFrom(o => o.TransmissionTranslations))
                .ForMember(dt => dt.Images, db => db.MapFrom(o => o.Images.Select(img => img)))
                .ReverseMap();

            CreateMap<Car, CreateCarCommand>()
               .ForMember(dt => dt.DriveTrainTranslations, db => db.MapFrom(o => o.DriveTrainTranslations))
               .ForMember(dt => dt.FuelTypeTranslations, db => db.MapFrom(o => o.FuelTypeTranslations))
               .ForMember(dt => dt.TransmissionTranslations, db => db.MapFrom(o => o.TransmissionTranslations))
               .ForMember(dt => dt.Images, db => db.MapFrom(o => o.Images.Select(img => img)))
               .ReverseMap();

            CreateMap<Car, UpdateCarCommand>()
               .ForMember(dt => dt.CarId, db => db.MapFrom(o => o.Id))
               .ForMember(dt => dt.DriveTrainTranslations, db => db.MapFrom(o => o.DriveTrainTranslations))
               .ForMember(dt => dt.FuelTypeTranslations, db => db.MapFrom(o => o.FuelTypeTranslations))
               .ForMember(dt => dt.TransmissionTranslations, db => db.MapFrom(o => o.TransmissionTranslations))
               .ForMember(dt => dt.Images, db => db.MapFrom(o => o.Images.Select(img => img)))
               .ReverseMap();

            CreateMap<DailyDataset, DailyDatasetDto>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<DailyDataset, CreateDailyDatasetCommand>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<DailyDataset, UpdateDailyDatasetCommand>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<CompanyService, CompanyServiceDto>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<CompanyService, CreateCompanyServiceCommand>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<CompanyService, UpdateCompanyServiceCommand>()
              .ForMember(dt => dt.TitleTranslations, db => db.MapFrom(o => o.TitleTranslations))
              .ForMember(dt => dt.ShortDescriptionTranslations, db => db.MapFrom(o => o.ShortDescriptionTranslations))
              .ForMember(dt => dt.LongDescriptionTranslations, db => db.MapFrom(o => o.LongDescriptionTranslations))
              .ForMember(dt => dt.Image, db => db.MapFrom(o => o.Image))
              .ReverseMap();

            CreateMap<CompanyInfo, CompanyInfoDto>()
              .ForMember(dt => dt.AddressTranslations, db => db.MapFrom(o => o.AddressTranslations))
              .ReverseMap();

            CreateMap<CompanyInfo, CreateCompanyInfoCommand>()
              .ForMember(dt => dt.AddressTranslations, db => db.MapFrom(o => o.AddressTranslations))
              .ReverseMap();

            CreateMap<CompanyInfo, UpdateCompanyInfoCommand>()
              .ForMember(dt => dt.AddressTranslations, db => db.MapFrom(o => o.AddressTranslations))
              .ReverseMap();

            CreateMap<Contract, ContractDto>()
              .ReverseMap();

            CreateMap<Contract, CreateContractCommand>()
              .ReverseMap();

            CreateMap<Contract, UpdateContractCommand>()
              .ReverseMap();

            CreateMap<Mail, SentMailCommand>()
              .ReverseMap();

            CreateMap<Mail, SetMailAboutCarCommand>()
              .ReverseMap();
        }
    }
}
