using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgGlobal.DatabaseModels.Models;

namespace NgGlobal.DatabaseEntity.Configurations
{
    public class TranslationConfiguration : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Translations");

            builder.HasOne(tr => tr.Language)
                .WithMany()
                .HasForeignKey(tr => tr.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(tr => tr.Text);
        }
    }
}
