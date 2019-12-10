using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Api.Contracts.Models;
using Api.Contracts.Error.Exceptions;
using Resources = Api.Contracts.Error.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ContactsInventory.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        
        public ErrorHandlingMiddleware()
        {
           
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            ApiErrorResponse apiResponse = new ApiErrorResponse();

            if (exception is ApiException apiException)
            {
                code = (HttpStatusCode)apiException.HttpStatusCode;
                apiResponse.Code = apiException.Code;
                apiResponse.Message = apiException.Message;
                
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                apiResponse.Code = Convert.ToInt32(Resources.FaultCode.InternalServerError);
                apiResponse.Message = Resources.FaultMessage.InternalServerError;
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new Newtonsoft.Json.Converters.StringEnumConverter(true) },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            string result = JsonConvert.SerializeObject(apiResponse, jsonSerializerSettings);
                        
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
