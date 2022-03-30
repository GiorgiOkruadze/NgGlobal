using NgGlobal.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Services.Abstractions
{
    public interface IFilterService
    {
        Task<FilterDto> ReadFilterAsync();
        Task<bool> WriteFilterInFileAsync();
    }
}
