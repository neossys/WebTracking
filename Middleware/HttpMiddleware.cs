﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Webtracking.Middleware
{
    public class HttpMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string[] UrlParameter = context.Request.Path.Value.Split('/');
            if (UrlParameter.Length==6)
            {

            }
            await _next.Invoke(context);
        }
    }

    public static class HttpMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpMiddleware>();
        }
    }
}
