using CwkSocial.Api.Contracts.Common;
using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CwkSocial.Api.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse (List<Application.Models.Error> errors)
        {
            var apiError = new ErrorResponse();

            if(errors.Any(e => e.Code == ErrorCodes.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCodes.NotFound);

                apiError.StatusCode = 404;
                apiError.StatusMessage = "Not found";
                apiError.Timestamp = DateTime.Now;
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            apiError.StatusCode = 500;
            apiError.StatusMessage = "Internalserver error";
            apiError.Timestamp = DateTime.Now;
            apiError.Errors.Add("Unknown error");

            return StatusCode(500, apiError);

        }
    }
}
