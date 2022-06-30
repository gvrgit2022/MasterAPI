using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Designations.Models;
using MediatR;
using Designation = Master.Application.Designations.Models.Designation;

namespace Master.Application.Designations.Queries
{
    public class GetDesignationQuery : IRequest<Designation>
    {
        public int Id { get; set; }

    }
     public class GetDesignationQueryHandler : BaseHandler,IRequestHandler<GetDesignationQuery, Designation>
    {
        public GetDesignationQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Designation> Handle(GetDesignationQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var designation = await masterContext.Designations

           .ProjectTo<Designation>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return designation;
        }
    }

}

