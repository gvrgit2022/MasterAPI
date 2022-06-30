using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Bedtypes.Model;
using MediatR;
using Bedtype = Master.Application.Bedtypes.Model.Bedtype;

namespace Master.Application.Bedtypes.Queries
{
    public class GetBedtypeQuery : IRequest<Bedtype>
    {
        public int Id { get; set; }

    }
    public class GetAmenitiesQueryHandler : BaseHandler, IRequestHandler<GetBedtypeQuery, Bedtype>
    {
        public GetAmenitiesQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Bedtype> Handle(GetBedtypeQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //FirstOrDefaultAsync(cancellationToken);

            var bedtype = await masterContext.Bedtypes

           .ProjectTo<Bedtype>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return bedtype;
        }
    }

}

