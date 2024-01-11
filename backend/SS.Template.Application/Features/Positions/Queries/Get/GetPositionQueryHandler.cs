
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.Template.Application.Queries;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Positions.Queries.Get
{
    public sealed class GetPositionQueryHandler : IQueryHandler<GetPositionQuery,PositionsModel>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetPositionQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
        }

        public async Task<PositionsModel> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Position>(x=>x.Id == request.Id && x.Status == EnabledStatus.Enabled)
                .ProjectTo<PositionsModel>(_mapper.ConfigurationProvider);

            var result = await _readOnlyRepository.SingleAsync(query, cancellationToken);

            if(result == null)
            {
                throw EntityNotFoundException.For<Position>(request.Id);
            }

            return result;
        }
    }
}
