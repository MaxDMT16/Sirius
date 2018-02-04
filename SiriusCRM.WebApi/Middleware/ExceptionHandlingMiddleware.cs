using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace SiriusCRM.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, exception);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var jObject = new JObject
            {
                ["StatusCode"] = context.Response.StatusCode,
                ["Message"] = exception.Message
            };

            while (exception.InnerException != null)
            {
                exception = exception.InnerException;
                jObject.Add("InnerException", new JObject
                {
                    ["Message"] = exception.Message
                });
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(jObject.ToString());
        }
    }
}