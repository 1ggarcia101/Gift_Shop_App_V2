using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Commands;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Positions.Commands.Remove
{
    public sealed class RemovePositionsCommandHandler : CommandHandler<RemovePositionsCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public RemovePositionsCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override async Task Handle(RemovePositionsCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.FirstAsync<Position>(x => x.Id == command.Id);

            if (entity == null)
            {
                throw EntityNotFoundException.For<Position>(command.Id);
            }

            entity.Status = EnabledStatus.Disabled;
            await _repository.SaveChangesAsync(cancellationToken);


        }
    }
}
