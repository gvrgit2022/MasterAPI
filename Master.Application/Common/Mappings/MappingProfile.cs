using AutoMapper;
using Master.Application;



namespace MasterAPI.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Master.Infrastructure.Models.Master.Addresstype, Master.Application.Address.Model.Addresstype>();
            CreateMap<Master.Infrastructure.Models.Master.Admissiontype, Master.Application.Admission.Model.AdmissionType>();
            CreateMap<Master.Infrastructure.Models.Master.Agetype, Master.Application.Age.Model.AgeType>();
            CreateMap<Master.Infrastructure.Models.Master.Bloodgroup, Master.Application.BloodGroups.Models.BloodGroup>();
            CreateMap<Master.Infrastructure.Models.Master.Country, Master.Application.Countries.Model.Country>();
            CreateMap<Master.Infrastructure.Models.Master.Department, Master.Application.Departments.Models.Department>();
            CreateMap<Master.Infrastructure.Models.Master.Designation, Master.Application.Designations.Models.Designation>();
            CreateMap<Master.Infrastructure.Models.Master.Gender, Master.Application.Genders.Models.Gender>();
            CreateMap<Master.Infrastructure.Models.Master.Language, Master.Application.Languages.Models.Language>();
            CreateMap<Master.Infrastructure.Models.Master.Locationtype, Master.Application.Locations.Models.Locationtype>();
            CreateMap<Master.Infrastructure.Models.Master.Maritalstatus, Master.Application.Maritalstatus.Models.Maritalstatus>();
            CreateMap<Master.Infrastructure.Models.Master.Nationality, Master.Application.Nationalities.Models.Nationality>();
            CreateMap<Master.Infrastructure.Models.Master.Religion, Master.Application.Religions.Models.Religion>();
            CreateMap<Master.Infrastructure.Models.Master.Amenity, Master.Application.Amenities.Model.Amenity>();
            CreateMap<Master.Infrastructure.Models.Master.Service, Master.Application.Services.Models.Service>();
            CreateMap<Master.Infrastructure.Models.Master.Bedtype, Master.Application.Bedtypes.Model.Bedtype>();
            CreateMap<Master.Infrastructure.Models.Master.Cityarea, Master.Application.CityAreas.Models.Cityarea>();

        }
    }
}
