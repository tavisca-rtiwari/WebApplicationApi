using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloHiiController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "Something went wrong";
        }
        [HttpGet("{input}")]
        public string Get(string input)
        {
            if (input.Equals("Hii"))
            {
                return "Hello";
            }
            else if (input.Equals("Hello"))
            {
                return "Hii";
            }
            return "Something went wrong";
        }
    }
}
