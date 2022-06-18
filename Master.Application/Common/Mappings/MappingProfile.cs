using AutoMapper;
using Master.Application;
 
 

namespace MasterAPI.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Master.Infrastructure.Models.Address.Addresstype, Master.Application.Address.Model.Addresstype>();
            CreateMap<Master.Infrastructure.Models.Master.Admissiontype, Master.Application.Admission.Model.AdmissionType>();

        }
    }
}
