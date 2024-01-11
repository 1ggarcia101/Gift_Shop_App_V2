using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.SpecificWorkExperienceRequirements.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.SpecificWorkExperienceRequirements
{
    public sealed class SpecificWorkExperienceRequirementsMapping : Profile
    {
        public SpecificWorkExperienceRequirementsMapping()
        {
            CreateMap<AddSpecificWorkExperienceRequirementsModel, SpecificWorkExperienceRequirement>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<SpecificWorkExperienceRequirement, SpecificWorkExperiencerequirementsModel>();
        }
    }
}
