using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgGlobal.DatabaseModels.Models;

namespace NgGlobal.DatabaseEntity.Configurations
{
    public class CompanyInfoConfiguration: IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("CompanyInfos");

            builder.HasMany(tr => tr.AddressTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.TranslationKey)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
