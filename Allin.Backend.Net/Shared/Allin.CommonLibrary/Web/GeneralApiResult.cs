using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Allin.Common.Web
{
    public class GeneralApiResult: GeneralServiceResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public static new GeneralApiResult Ok()
        {
            return new GeneralApiResult<object>()
            {
                IsSuccess = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
            };
        }

        public static new GeneralApiResult Ok(object Data)
        {
            return new GeneralApiResult<object>()
            {
                IsSuccess = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Data = Data
            };
        }
        public static new GeneralApiResult<T> Ok<T>(T Data)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Data = Data
            };
        }

        public static  GeneralApiResult NotFound(string? errorReason = null)
        {
            return NotFound<object>(errorReason);
        }

        public static GeneralApiResult<T> NotFound<T>(string? errorReason = null)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = false,
                Errors = new List<ValidationFailure> { new ValidationFailure("", errorReason) },
                HttpStatusCode = System.Net.HttpStatusCode.NotFound
            };
        }

        public static GeneralApiResult BadRequest(string? errorReason = null)
        {
            return BadRequest<object>(errorReason);
        }

        public static GeneralApiResult<T> BadRequest<T>(string? errorReason = null)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = false,
                Errors = new List<ValidationFailure> { new ValidationFailure("", errorReason) },
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        public static GeneralApiResult ValidationError(IEnumerable<string> errors)
        {
            return ValidationError<object>(errors);
        }

        public static GeneralApiResult ValidationError(string errorReason)
        {
            return ValidationError<object>(errorReason);
        }

        public static GeneralApiResult ValidationError(IEnumerable<ValidationFailure>? errors = null)
        {
            return ValidationError<object>(errors);
        }

        public static GeneralApiResult<T> ValidationError<T>(IEnumerable<string> errors)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = false,
                Errors = errors.Select(msg => new ValidationFailure("", msg)),
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public static GeneralApiResult<T> ValidationError<T>(string errorReason)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = false,
                Errors = new List<ValidationFailure> { new ValidationFailure("", errorReason) },
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public static GeneralApiResult<T> ValidationError<T>(IEnumerable<ValidationFailure>? errors = null)
        {
            return new GeneralApiResult<T>()
            {
                IsSuccess = false,
                Errors = errors,
                HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity
            };
        }

        public IActionResult MakeErrorActionResult()
        {
            var result = new { this.Errors };
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

    public class GeneralApiResult<T>: GeneralApiResult
    {
       

    }
}
