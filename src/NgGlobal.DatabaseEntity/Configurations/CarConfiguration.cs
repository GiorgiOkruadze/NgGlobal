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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Cars");

            builder.HasMany(tr => tr.DriveTrainTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.TranslationKey)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(tr => tr.FuelTypeTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.TranslationKey)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(tr => tr.TransmissionTranslations)
               .WithOne()
               .HasForeignKey(tr => tr.TranslationKey)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(tr => tr.Images)
              .WithOne()
              .HasForeignKey(tr => tr.CarId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
