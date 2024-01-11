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

namespace SS.Template.Application.Features.Interviews.Commands.Edit
{
    public sealed class EditInterviewsCommandHandler : CommandHandler<Edit<AddInterviewsModel>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EditInterviewsCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override async Task Handle(Edit<AddInterviewsModel> command, CancellationToken cancellationToken)
        {
            var entity = await _repository.FirstAsync<Interview>(x => x.Id == command.Id);

            if (entity == null)
            {
                throw EntityNotFoundException.For<Interview>(command.Id);
            }

            _mapper.Map(command.Model, entity);

            await _repository.SaveChangesAsync(cancellationToken);
        }

    }
}
