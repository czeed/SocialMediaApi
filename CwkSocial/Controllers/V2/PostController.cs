using CwkSocial.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = new Post { Id = id, Text = "Hello to v2" };

            return Ok(post);
        }
    }
}
