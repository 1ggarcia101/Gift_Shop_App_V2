using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.Artemis.Proxy;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Examples.Commands.Add;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Interviewers.Commands.Add
{
    public sealed class AddInterviewerCommandHandler : CommandHandler<AddInterviewerCommand>
    {
        private readonly IJanusProxy _janusProxy;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddInterviewerCommandHandler(IRepository repository, IMapper mapper, IJanusProxy janusProxy)
        {
            _repository = repository;
            _mapper = mapper;
            _janusProxy = janusProxy;

        }

        protected override async Task Handle(AddInterviewerCommand command, CancellationToken cancellationToken)
        {
            var janusBambooEmployees = await _janusProxy.GetEmployees();
            var queryEmployees = _repository.Query<Domain.Entities.Interviewers>();
            var ltEmployees = new List<Domain.Entities.Interviewers>();
            janusBambooEmployees.ForEach( x =>
            {
                var employee =  _repository.First(queryEmployees, y=>y.Email == x.Email);

                if(employee != null)
                {
                    _mapper.Map(x, employee);
                }
                else
                {
                    var newEmployee = new Domain.Entities.Interviewers();
                    _mapper.Map(x, newEmployee);
                    ltEmployees.Add(newEmployee);
                }

            });

            _repository.AddRange(ltEmployees);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
