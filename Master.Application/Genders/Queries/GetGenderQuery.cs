using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Genders.Models;
using MediatR;
using Gender = Master.Application.Genders.Models.Gender;

namespace Master.Application.Genders.Queries
{
    public class GetGenderQuery : IRequest<Gender>
    {
        public int Id { get; set; }

    }
     public class GetGenderQueryHandler : BaseHandler,IRequestHandler<GetGenderQuery, Gender>
    {
        public GetGenderQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Gender> Handle(GetGenderQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var gender = await masterContext.Genders

           .ProjectTo<Gender>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return gender;
        }
    }

}

