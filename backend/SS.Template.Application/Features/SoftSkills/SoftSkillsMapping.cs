using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.SoftSkills.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.SoftSkills
{
    public sealed class SoftSkillsMapping : Profile
    {
        public SoftSkillsMapping()
        {
            CreateMap<AddSoftSkillsModel, SoftSkill>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<SoftSkill,SoftSkillsModel>();
        }
    }
}
