using AutoMapper;
//using SampleAPI.Infrastructure.Models.Test;
//using SampleAPI.Infrastructure.Models.HMS;
//using SampleAPI.Infrastructure.Models.Patient;
using Master.Infrastructure.Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application
{
    public class BaseHandler
    {
        
       
       protected readonly MasterContext masterContext;
        protected readonly IMapper Mapper;
        protected readonly IConfigurationProvider ConfigurationProvider;
        //private masterDBContext context;

        protected BaseHandler(MasterContext context, IMapper mapper)
        {
            masterContext = context;
            Mapper = mapper;
            ConfigurationProvider = mapper.ConfigurationProvider;
        }








    }
}
