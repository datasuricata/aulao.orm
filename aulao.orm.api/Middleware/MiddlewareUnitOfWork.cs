using aulao.orm.service.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aulao.orm.api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareUnitOfWork
    {
        private readonly RequestDelegate _next;

        public MiddlewareUnitOfWork(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            var core = (IServiceBase)httpContext.RequestServices.GetService(typeof(IServiceBase));

            await core.Commit();
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareUnitOfWork>();
        }
    }
}
