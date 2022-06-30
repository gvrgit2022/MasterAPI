using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Age.Model;
using MediatR;
namespace Master.Application.Age.Queries
{
    public class GetAgeTypeQuery : IRequest<AgeType>
    {
        public int Id { get; set; }

    }
    public class GetAgeTypeQueryHandler : BaseHandler, IRequestHandler<GetAgeTypeQuery, AgeType>
    {
        public GetAgeTypeQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<AgeType> Handle(GetAgeTypeQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var agetype = await masterContext.Agetypes

           .ProjectTo<AgeType>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return agetype;
        }
    }

}

