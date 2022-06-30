using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Services.Models;
using MediatR;
using Service = Master.Application.Services.Models.Service;

namespace Master.Application.Services.Queries
{
    public class ServicQuery : IRequest<Service>
    {
        public int Id { get; set; }

    }
     public class GetServiceQueryHandler : BaseHandler,IRequestHandler<ServicQuery, Service>
    {
        public GetServiceQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Service> Handle(ServicQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var service = await masterContext.Religions

           .ProjectTo<Service>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return service;
        }
    }

}

