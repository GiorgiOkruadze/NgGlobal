﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseEntity.Configurations
{
    internal class DailyDatasetConfiguration : IEntityTypeConfiguration<DailyDataset>
    {
        public void Configure(EntityTypeBuilder<DailyDataset> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("DailyDatasets");

            builder.HasMany(tr => tr.TitleTranslations)
                 .WithOne()
                 .HasForeignKey(tr => tr.DailyDatasetTitleId);

            builder.HasMany(tr => tr.ShortDescriptionTranslations)
                .WithOne()
                .HasForeignKey(tr => tr.DailyDatasetShortDescriptionId);

            builder.HasMany(tr => tr.LongDescriptionTranslations)
               .WithOne()
               .HasForeignKey(tr => tr.DailyDatasetLongDescriptionId);

            builder.HasOne(tr => tr.Image)
                .WithOne(i => i.DailyDataset)
                .HasForeignKey<DailyDatasetImage>(i => i.DailyDatasetId);
        }
    }
}
