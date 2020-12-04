using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await this._next.Invoke(httpContext);

            switch (httpContext.Response.StatusCode)
            {
                case 404:
                    httpContext.Response.Redirect("/Home/PageNotFound");
                    break;

                case 500:
                    httpContext.Response.Redirect("/Home/Error");
                    break;
            }
        }
    }
}
