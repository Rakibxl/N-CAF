using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Web.Core;
using Architecture.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Architecture.Web.Controllers.Common
{
    //[ApiController]
    public abstract class BaseController : ControllerBase
    {        
        public async Task<IActionResult> ModelValidation(Func<Task<IActionResult>> action)
        {

            if (!ModelState.IsValid)
            {
               return  ValidationResult(ModelState);
            }
            return await action();
        }
        public IActionResult OkResult(object data)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = 200,
                Status = "Success",
                Message = "Successful",
                Data = data
            };
            return ObjectResult(apiResult);
        }

        public IActionResult OkResult(object data, string message)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = 200,
                Status = "Success",
                Message = message,
                Data = data
            };
            return ObjectResult(apiResult);
        }

        public IActionResult ValidationResult(ModelStateDictionary modelState)
        {
            var apiResult = new ApiResponse
            {
                StatusCode = 400,
                Status = "ValidationError",
                Message = "Validation Fail",
                Errors = modelState.GetErrors()
            };
            return ObjectResult(apiResult);
        }

        public IActionResult ExceptionResult(Exception ex)
        {

            var apiResult = new ApiResponse
            {
                StatusCode = 500,
                Status = "Error",
                Message = ex.Message,
                Data = new object()
            };
            return ObjectResult(apiResult);
        }

        public IActionResult ObjectResult(ApiResponse model)
        {
            var result = new ObjectResult(model)
            {
                StatusCode = model.StatusCode
            };
            return result;
        }

        public string GetClaimValue(string claimType)
        {
            var claim = User.Claims.Where(dd => dd.Type == claimType).FirstOrDefault();
            return claim != null ? claim.Value : null;
        }
    }
}
