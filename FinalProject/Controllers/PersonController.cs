using FinalProject.DataDB;
using FinalProject.Dtos;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FinalProject.Controllers
{

    [ApiController]
    public class PersonController : Controller
    {
        private IPersonData _personData;
        public PersonController(IPersonData personData)
        {
            _personData = personData;
        }
        //Read
        [HttpGet]
        [Route("api/personcontroller/people")]
        public IActionResult GetPeople()
        {
            return Ok(_personData.GetPeople());
        }
        [HttpGet]
        [Route("api/personcontroller/person/{FullName}")]
        public IActionResult GetPerson(string fullName)
        {
            if (fullName != null)
            {
                return Ok(_personData.GetPerson(fullName));
            }
            return NotFound($"Person : {fullName} is not found.");
        }
        //Create
        [HttpPost]
        [Route("api/personcontroller/addPerson")]
        public IActionResult AddPerson(PersonDto personDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("\n", ModelState.SelectMany(x => x.Value.Errors));
                return BadRequest(errorMessages);
            }

            Person person = PersonDto.GetPerson(personDto);
            _personData.AddPerson(person);

            return Created(HttpContext.Request + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + person.FullName, person);
        }
        //Delete
        [HttpDelete]
        [Route("api/personcontroller/deletePerson/{FullName}")]
        public IActionResult DeletePerson(string fullName)
        {
            var person = _personData.GetPerson(fullName);
            if (person != null)
            {
                _personData.DeletePerson(person);
                return Ok($"Person : {fullName} has been deleted.");
            }
            return NotFound($"Person : {fullName} is not found.");
        }
        //Update
        [HttpPatch]
        [Route("api/personcontroller/updatePerson/{FullName}")]
        public IActionResult UpdatePerson(string fullName, Person person)
        {
            var existingPerson = _personData.GetPerson(fullName);
            if (existingPerson != null)
            {
                //full name doesn't get updated? why?
                person.FullName = existingPerson.FullName;
                _personData.UpdatePerson(person);

                return Ok($"{person.FullName} has been updated." + person);
            }
            return BadRequest();
        }
    }
}
