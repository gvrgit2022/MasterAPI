using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Religions.Models;
using MediatR;
using Religion = Master.Application.Religions.Models.Religion;

namespace Master.Application.Religions.Queries
{
    public class GetReligionQuery : IRequest<Religion>
    {
        public int Id { get; set; }

    }
     public class GetReligionQueryHandler : BaseHandler,IRequestHandler<GetReligionQuery, Religion>
    {
        public GetReligionQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Religion> Handle(GetReligionQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var religion = await masterContext.Religions

           .ProjectTo<Religion>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return religion;
        }
    }

}

