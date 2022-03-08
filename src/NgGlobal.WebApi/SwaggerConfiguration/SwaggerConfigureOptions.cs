using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NgGlobal.WebApi.SwaggerConfiguration
{
    public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public SwaggerConfigureOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "NgGlobal.WebApi Client", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "NgGlobal.WebApi Admin", Version = "v2" });
            }
        }
    }

}
