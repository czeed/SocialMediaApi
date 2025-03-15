using CwkSocial.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;

namespace CwkSocial.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var apiResponse = new ErrorResponse();

                apiResponse.StatusCode = 400;
                apiResponse.StatusMessage = "Bad Request";
                apiResponse.Timestamp = DateTime.Now;

                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    apiResponse.Errors.Add(error.Value.ToString());
                }
                
                context.Result = new BadRequestObjectResult(apiResponse);
            }
        }

    }
}
