using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.Template.Application.Features.Interviews.Queries.GetPage;
using SS.Template.Application.Infrastructure;
using SS.Template.Application.Queries;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviews.Queries.GetCardList
{
    public class GetCardListPageQueryHandler : IQueryHandler<GetCardListPageQuery, PaginatedResult<InterviewsModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetCardListPageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator )
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResult<InterviewsModel>> Handle(GetCardListPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Interview>(x => x.Status == EnabledStatus.Enabled && !x.CompletedInterview);

            if (!string.IsNullOrEmpty(request.Term))
            {
                var term = request.Term.ToUpper().Trim();
                query = query.Where(x => x.Name.ToUpper().Contains(term));
            }

            var sortCriteria = request.GetSortCriteria();
            var items = query
                .ProjectTo<InterviewsModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(sortCriteria, x => x.InterviewDate);
            var page = await _paginator.MakePageAsync(_readOnlyRepository, query, items, request, cancellationToken);

            return page;
        }
    }
}
