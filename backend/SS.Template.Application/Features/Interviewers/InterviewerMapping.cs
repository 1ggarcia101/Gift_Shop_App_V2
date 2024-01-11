
using AutoMapper;
using SS.Artemis.Proxy.Models.Janus;
using SS.Template.Application.Features.Interviewers.Commands.Add;
using SS.Template.Application.Features.Interviewers.Commands.Update;

namespace SS.Template.Application.Features.Interviewers
{
    public sealed class InterviewerMapping : Profile
    {
        public InterviewerMapping()
        {
            CreateMap<EmployeesProxyModel, Domain.Entities.Interviewers>()
                .ForMember(x => x.Id, e => e.Ignore())
                .ForMember(x => x.ActiveInterviewer, e => e.Ignore());

            CreateMap<UpdateInterviewerCommand, Domain.Entities.Interviewers>();

            CreateMap<Domain.Entities.Interviewers, InterviewerModel>();
        }
    }
}
