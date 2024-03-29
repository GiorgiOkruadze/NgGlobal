﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class DailyDataset : BaseEntity
    {
        public List<Translation> TitleTranslations { get; set; }
        public List<Translation> ShortDescriptionTranslations { get; set; }
        public List<Translation> LongDescriptionTranslations { get; set; }
        public DailyDatasetImage Image { get; set; }

    }
}
