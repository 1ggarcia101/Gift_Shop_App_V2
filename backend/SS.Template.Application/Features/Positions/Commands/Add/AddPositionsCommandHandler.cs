using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Commands;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Positions.Commands.Add
{
    public sealed class AddPositionsCommandHandler : CommandHandler<AddPositionsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddPositionsCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override async Task Handle(AddPositionsCommand command, CancellationToken cancellationToken)
        {
            foreach(var positionModel in command.Positions)
            {
                var entity = _mapper.Map<Position>(positionModel);

                _repository.Add(entity);
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
