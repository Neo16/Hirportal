using Hirportal.Bll.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Hirportal.Web
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next; 
 
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;          
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessLogicException bEx)
            {
                await WriteAsJsonAsync(context, (HttpStatusCode)bEx.ErrorCode, new ErrorDto
                {
                    ErrorCode = bEx.ErrorCode,
                    ErrorMessages = new string[] { bEx.Message }
                });
            }
            catch (Exception ex)
            {              
                await WriteAsJsonAsync(context, HttpStatusCode.InternalServerError, null);
            }
        }

        private async Task WriteAsJsonAsync(HttpContext context, HttpStatusCode statusCode, object payload)
        {
            context.Response.Clear();
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(payload, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });           

            await context.Response.WriteAsync(json);
        }
    }
}
