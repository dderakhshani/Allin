using System;
using System.Collections.Generic;
using Allin.Common.Web;
using FluentValidation;
using Microsoft.AspNetCore.Http;


namespace Allin.Common.Validations
{
    public class BuesinessRuleException : Exception
    {
        public IEnumerable<string> Errors { get; private set; }
        public BuesinessRuleException(IEnumerable<string> errors)
        {
            this.Errors = errors;
        }

    }
    public sealed class ValidationExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {

                var validationDetails = GeneralApiResult.ValidationError(exception.Errors);
                context.Response.StatusCode = (int)validationDetails.HttpStatusCode;
                await context.Response.WriteAsJsonAsync(validationDetails);

            }
            catch (BuesinessRuleException exception)
            {

                var validationDetails = GeneralApiResult.ValidationError(exception.Errors);
                context.Response.StatusCode = (int)validationDetails.HttpStatusCode;
                await context.Response.WriteAsJsonAsync(validationDetails);

            }
            // catch (Exception exception)
            // {

            //     throw;

            // }
        }
    }
}
