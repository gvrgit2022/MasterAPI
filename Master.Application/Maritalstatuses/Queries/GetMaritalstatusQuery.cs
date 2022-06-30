using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Maritalstatus.Models;
using MediatR;
using Martstatus = Master.Application.Maritalstatus.Models.Maritalstatus;

namespace Master.Application.Maritalstatus.Queries
{
    public class GetMaritalstatusQuery : IRequest<Martstatus>
    {
        public int Id { get; set; }

    }
     public class GetMaritalstatusQueryHandler : BaseHandler,IRequestHandler<GetMaritalstatusQuery, Martstatus>
    {
        public GetMaritalstatusQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Martstatus> Handle(GetMaritalstatusQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var maritalstatus = await masterContext.Maritalstatuses

           .ProjectTo<Martstatus>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return maritalstatus;
        }
    }

}

