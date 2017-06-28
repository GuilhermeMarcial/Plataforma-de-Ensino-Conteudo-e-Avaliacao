using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PlataformaDeEnsino.Presenter.Middlewares.XFrameOptions
{
    public class XFrameOptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public XFrameOptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            return this._next(context);
        }
    }
}