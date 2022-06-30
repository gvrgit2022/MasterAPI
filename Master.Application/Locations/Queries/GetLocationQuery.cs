using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Locations.Models;
using MediatR;
using Locationtype = Master.Application.Locations.Models.Locationtype;

namespace Master.Application.Locations.Queries
{
    public class GetLocationQuery : IRequest<Locationtype>
    {
        public int Id { get; set; }

    }
     public class GetLocationQueryHandler : BaseHandler,IRequestHandler<GetLocationQuery, Locationtype>
    {
        public GetLocationQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Locationtype> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var location = await masterContext.Locationtypes

           .ProjectTo<Locationtype>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return location;
        }
    }

}

