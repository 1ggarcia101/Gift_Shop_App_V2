using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Interviewers.Commands.Remove;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviewers.Commands.Activate
{
    public class ActivateInterviewerCommandHandler : ICommandHandler<ActivateInterviewerCommand>
    {
        private readonly IRepository _repository;

        public ActivateInterviewerCommandHandler(IRepository repository)
        {
            _repository = repository;
        }


        public async Task Handle(ActivateInterviewerCommand command, CancellationToken cancellationToken)
        {
            var employeeItem = await _repository.FirstAsync<Domain.Entities.Interviewers>(x => x.Id == command.id) ?? throw EntityNotFoundException.For<Domain.Entities.Interviewers>(command.id);

            employeeItem.ActiveInterviewer = EnabledStatus.Disabled;
            await _repository.SaveChangesAsync(cancellationToken);



        }

    }
}
