using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.JobDescription.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.JobDescription
{
    public sealed class JobDescriptionMapping : Profile
    {
        public JobDescriptionMapping()
        {
            CreateMap<AddJobDescriptionModel, JobDescriptions>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<JobDescriptions, JobDescriptionModel>();
        }
    }
}
