using Microsoft.Data.SqlClient;
using static Azure.Core.HttpHeader;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Application.Exceptions;

namespace Services.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Wrapper.Response();

            switch (error)
            {
                case SqlException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case CustomValidationException e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.ValidationErrors = e.Errors;
                    break;
                case ValidationException e:
                    response.StatusCode = 400;
                    responseModel.Message = e.Message;
                    break;
                case KeyNotFoundException e:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    break;
                case AuthenticationException e:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    responseModel.Message = e.Message;
                    break;
                case HttpRequestException e:
                    response.StatusCode = 400;
                    responseModel.Message = e.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = error.Message;
                    break;
            }
            var result = JsonConvert.SerializeObject(responseModel);
            return response.WriteAsync(result);
        }
    }
}
