using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Allin.Common.Web
{
    public class GeneralApiResult
    {
        public bool IsSuccess { get; set; }
        public string TraceId { get; set; }
        public object? Data { get; set; }
        public string Error { get; set; }
        public IEnumerable<ValidationFailure>? ValidationErrors { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public static new GeneralApiResult Ok(string traceId)
        {
            return new GeneralApiResult()
            {
                IsSuccess = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                TraceId = traceId
            };
        }

        public static new GeneralApiResult Ok<T>(string traceId, T data = default)
        {
            return new GeneralApiResult()
            {
                IsSuccess = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Data = data,
                TraceId = traceId
            };
        }

        public static GeneralApiResult Fail(string traceId, string error)
        {
            return new GeneralApiResult()
            {
                IsSuccess = false,
                Error = error,
                HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
                TraceId = traceId
            };
        }

        public static GeneralApiResult ValidationError(IEnumerable<string> errors)
        {
            return new GeneralApiResult()
            {
                IsSuccess = false,
                ValidationErrors = errors.Select(msg => new ValidationFailure("", msg)),
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public static GeneralApiResult ValidationError(string errorReason)
        {
            return new GeneralApiResult()
            {
                IsSuccess = false,
                ValidationErrors = new List<ValidationFailure> { new ValidationFailure("", errorReason) },
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public static GeneralApiResult ValidationError(IEnumerable<ValidationFailure>? errors = null)
        {
            return new GeneralApiResult()
            {
                IsSuccess = false,
                ValidationErrors = errors,
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public IActionResult MakeErrorActionResult()
        {
            var result = new { this.ValidationErrors };
            switch (this.HttpStatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(result);
                case System.Net.HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(result);
                default:
                    return new BadRequestObjectResult(result);
            }
        }
        public IActionResult MakeSuccessActionResult()
        {
            switch (this.HttpStatusCode)
            {
                case System.Net.HttpStatusCode.NoContent:
                    return new NoContentResult();
                default:
                    return new OkObjectResult(this.Data);
            }
        }
        public IActionResult MakeActionResult()
        {
            if (this.IsSuccess)
            {
                return this.MakeSuccessActionResult();
            }
            return this.MakeErrorActionResult();

        }
    }
}
