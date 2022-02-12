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
    public class CompanyServicesConfiguration : IEntityTypeConfiguration<CompanyService>
    {
        public void Configure(EntityTypeBuilder<CompanyService> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("CompanyServices");

            builder.HasMany(tr => tr.TitleTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.CompanyServiceTitleId);

            builder.HasMany(tr => tr.ShortDescriptionTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.CompanyServiceShortDescriptionId);

            builder.HasMany(tr => tr.LongDescriptionTranslations)
               .WithOne()
               .HasForeignKey(tr => tr.CompanyServiceLongDescriptionId);

            builder.HasOne(i => i.Image).WithOne(i => i.CompanyService).HasForeignKey<CompanyServiceImage>(i => i.CompanyServiceId);
        }
    }
}
