using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using AutoMapper;
using SS.Template.Application.Commands;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviewers.Commands.Update
{
    public class UpdateInterviewerCommandHandler : ICommandHandler<UpdateInterviewerCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateInterviewerCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        public async Task Handle(UpdateInterviewerCommand command, CancellationToken cancellationToken)
        {
            var employeeItem = await _repository.FirstAsync<Domain.Entities.Interviewers>(x => x.Id == command.Id) ?? throw EntityNotFoundException.For<Domain.Entities.Interviewers>(command.Id);

            _mapper.Map(command, employeeItem);
            employeeItem.DisplayName = string.Concat(employeeItem.FirstName, ' ', employeeItem.LastName);
            await _repository.SaveChangesAsync(cancellationToken);



        }

    }
}
