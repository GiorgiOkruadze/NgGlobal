using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseEntity.Configurations
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Mails");
        }
    }
}
