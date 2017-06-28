using Microsoft.AspNetCore.Builder;

namespace PlataformaDeEnsino.Presenter.Middlewares.XFrameOptions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseXFrameOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<XFrameOptionsMiddleware>();
        }
    }
}