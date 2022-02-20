using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Service
{
    public class TranslationService: ITranslationService
    {
        private readonly IRepository<Translation> _translationRepository = default;

        public TranslationService(IRepository<Translation> translationRepository)
        {
            _translationRepository = translationRepository;
        }

        public async Task<bool> DeleteTranslationsAsync(IEnumerable<int> ids)
        {
            foreach (var item in ids.ToList())
            {
                await _translationRepository.DeleteAsync(item);
            }

            return true;
        }
    }
}
