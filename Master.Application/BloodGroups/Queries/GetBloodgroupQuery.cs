using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.BloodGroups.Models;
using MediatR;
using BloodGroup = Master.Application.BloodGroups.Models.BloodGroup;

namespace Master.Application.BloodGroups.Queries
{
    public class GetBloodGroupQuery : IRequest<BloodGroup>
    {
        public int Id { get; set; }

    }
    public class GetbloodgroupQueryHandler : BaseHandler, IRequestHandler<GetBloodGroupQuery, BloodGroup>
    {
        public GetbloodgroupQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<BloodGroup> Handle(GetBloodGroupQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var bloodgroup = await masterContext.Bloodgroups

           .ProjectTo<BloodGroup>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return bloodgroup;
        }
    }

}

