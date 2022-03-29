using MediatR;
using Newtonsoft.Json;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.ApplicationShared.DTOs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadFiltersHandler : IRequestHandler<ReadFiltersQuery, FilterDto>
    {
        private readonly IFileService _fileService = default;

        public ReadFiltersHandler(IFileService fileService)
        {
            _fileService=fileService;
        }

        public async Task<FilterDto> Handle(ReadFiltersQuery request, CancellationToken cancellationToken)
        {
            var fileData = await _fileService.GetDataFromFile("filters.json");
            return JsonConvert.DeserializeObject<FilterDto>(fileData);
        }
    }
}
