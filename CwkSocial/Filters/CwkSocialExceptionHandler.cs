using CwkSocial.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace CwkSocial.Api.Filters
{
    public class CwkSocialExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var apiResponse = new ErrorResponse();

            apiResponse.StatusCode = 500;
            apiResponse.StatusMessage = "Internal server error";
            apiResponse.Timestamp = DateTime.Now;   
            apiResponse.Errors.Add(context.Exception.Message);

            context.Result = new JsonResult(apiResponse) { StatusCode = 500};
        }
    }
}
