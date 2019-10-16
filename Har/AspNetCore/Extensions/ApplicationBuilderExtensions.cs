using Microsoft.AspNetCore.Builder;

namespace Har.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureApplicationRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureEngineRequestPipeline(application);
        }
    }
}
