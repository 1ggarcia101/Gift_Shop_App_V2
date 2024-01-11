using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.Template.Application.Features.Examples;
using SS.Template.Application.Infrastructure;
using SS.Template.Application.Queries;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Positions.Queries.GetPage
{
    public sealed class GetPositionPageQueryHandler : IQueryHandler<GetPositionPageQuery, PaginatedResult<PositionsModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;

        public GetPositionPageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
        }

        public async Task<PaginatedResult<PositionsModel>> Handle(GetPositionPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Position>(x => x.Status == EnabledStatus.Enabled);

            if (!string.IsNullOrEmpty(request.Term))
            {
                var term = request.Term.Trim();
                query = query.Where(x => x.PositionName.Contains(term));
            }

            var sortCriteria = request.GetSortCriteria();
            var items = query
                .ProjectTo<PositionsModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(sortCriteria, x => x.PositionName);
            var page = await _paginator.MakePageAsync(_readOnlyRepository, query, items, request, cancellationToken);

            return page;
        }
    }
}
