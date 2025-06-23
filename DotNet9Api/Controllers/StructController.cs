using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet9.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructController : ControllerBase
    {
        public ActionResult<Person> GetPersons()
        {

            return new OkObjectResult(new Person());
        }
    }

    public struct Person
    {
        public Person() {
            Name = "testname";
            Age = 1;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
