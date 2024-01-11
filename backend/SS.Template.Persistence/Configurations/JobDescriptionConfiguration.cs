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
    public sealed class JobDescriptionConfiguration : IEntityTypeConfiguration<JobDescriptions>
    {
        public void Configure(EntityTypeBuilder<JobDescriptions> builder)
        {
            
        }
    }
}
