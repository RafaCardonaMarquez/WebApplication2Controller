using ClassLibrary;
using EntityFramework.Database;
using Microsoft.AspNetCore.Mvc;
using WebApplication2Controller.Dtos;

namespace WebApplication2Controller.Controllers
{
    [ApiController]
    [Route("Persons")]
    public class PersonController : Controller
    {
        private IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        public IActionResult GetPersons()
        {
            var person = _personRepository.GetPersons();
            return Ok(person);
        }

        [HttpGet("{personId}")]
        public IResult GetPerson(int personId)
        {
            var personDto = _personRepository.GetPerson(personId);
            if (personDto == null)
                return Results.NotFound();
            return Results.Ok(personDto);
        }

        [ProducesResponseType(201)]
        [HttpPost]
        public IActionResult PostPerson(NewPersonDto person)
        {
            _personRepository.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { personId = person.Id }, person);
        }

        [HttpPut]
        public IActionResult UpdatePeson(PersonDto person)
        {
            _personRepository.UpdatePerson(person);
            return Ok();
        }

        [HttpDelete]    
        public IActionResult RemovePerson(int personId)
        {
            _personRepository.RemovePerson(personId);
            return Ok();
        }

    }
}
