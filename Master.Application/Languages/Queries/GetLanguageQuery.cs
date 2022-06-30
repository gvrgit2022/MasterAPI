using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Languages.Models;
using MediatR;
using Language = Master.Application.Languages.Models.Language;

namespace Master.Application.Languages.Queries
{
    public class GetLanguageQuery : IRequest<Language>
    {
        public int Id { get; set; }

    }
     public class GetLanguageQueryHandler : BaseHandler,IRequestHandler<GetLanguageQuery, Language>
    {
        public GetLanguageQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Language> Handle(GetLanguageQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var language = await masterContext.Languages

           .ProjectTo<Language>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return language;
        }
    }

}

