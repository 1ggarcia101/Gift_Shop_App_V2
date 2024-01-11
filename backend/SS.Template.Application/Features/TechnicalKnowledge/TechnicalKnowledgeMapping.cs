using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.TechnicalKnowledge.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.TechnicalKnowledge
{
    public sealed class TechnicalKnowledgeMapping : Profile
    {
        public TechnicalKnowledgeMapping()
        {
            CreateMap<AddTechnicalKnowledgeModel, TechnicalKnowledges>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<TechnicalKnowledges, TechnicalKnowledgeModel>();
        }
    }
}
