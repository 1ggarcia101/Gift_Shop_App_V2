using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Commands;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Interviews.Commands.Add
{
    public sealed class AddInterviewsCommandHandler : CommandHandler<AddInterviewsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddInterviewsCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override async Task Handle(AddInterviewsCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Interview>(command.Interview);
            _repository.Add(entity);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
