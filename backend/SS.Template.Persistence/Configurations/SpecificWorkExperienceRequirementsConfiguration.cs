using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Template.Domain.Entities;

namespace SS.Template.Persistence.Configurations
{
    internal class SpecificWorkExperienceRequirementsConfiguration : IEntityTypeConfiguration<SpecificWorkExperienceRequirement>
    {
        public void Configure(EntityTypeBuilder<SpecificWorkExperienceRequirement> builder)
        {
            
        }
    }
}
