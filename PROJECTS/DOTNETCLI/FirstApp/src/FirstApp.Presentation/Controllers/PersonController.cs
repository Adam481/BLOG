using System.Threading.Tasks;
using FirstApp.Application;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Presentation.Controllers
{
    [Route("api/person")]
    [Produces("application/json")]
    public class PersonController : Controller
    {
        private PersonService _personService;

        public PersonController()
        {
            _personService = new PersonService();
        }


        [HttpPost]
        public IActionResult Create([FromBody] PersonCreateDTO personCreateCommand)
        {
            try
            {
                _personService.Handle(personCreateCommand);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}