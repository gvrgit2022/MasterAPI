using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Nationalities.Models;
using MediatR;
using Nationality = Master.Application.Nationalities.Models.Nationality;

namespace Master.Application.Nationalities.Queries
{
    public class GetNationalityQuery : IRequest<Nationality>
    {
        public int Id { get; set; }

    }
     public class GetNationalityQueryHandler : BaseHandler,IRequestHandler<GetNationalityQuery, Nationality>
    {
        public GetNationalityQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Nationality> Handle(GetNationalityQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var nationality = await masterContext.Nationalities

           .ProjectTo<Nationality>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return nationality;
        }
    }

}

