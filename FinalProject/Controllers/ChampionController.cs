using FinalProject.DataDB;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ChampionController : Controller
    {
        private IChampionData _championData;
        public ChampionController(IChampionData championData)
        {
            _championData = championData;
        }
        //Read
        [HttpGet]
        [Route("api/championcontroller/champions")]
        public IActionResult GetChampions()
        {
            return Ok(_championData.GetChampions());
        }
        [HttpGet]
        [Route("api/championcontroller/champion/{name}")]
        public IActionResult GetChampion(string name)
        {
            if (name != null)
            {
                return Ok(_championData.GetChampion(name));
            }
            return NotFound($"Person : {name} is not found.");
        }
        //Create
        [HttpPost]
        [Route("api/championcontroller/champion/")]
        public IActionResult AddChampion(Champion champion)
        {
            _championData.AddChampion(champion);

            return Created(HttpContext.Request + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + champion.ChampionName, champion);
        }
        //Delete
        [HttpDelete]
        [Route("api/championcontroller/deleteChampion/{name}")]
        public IActionResult DeleteChampion(string name)
        {
            var champion = _championData.GetChampion(name);
            if (champion != null)
            {
                _championData.DeleteChampion(champion);
                return Ok($"Person : {name} has been deleted.");
            }
            return NotFound($"Person : {name} is not found.");
        }
        //Update
        [HttpPatch]
        [Route("api/championcontroller/updateChampion/{name}")]
        public IActionResult UpdateChampion(string champName, Champion champion)
        {
            var existingChampion = _championData.GetChampion(champName);
            if (existingChampion != null)
            {
                //full name doesn't get updated? why?
                champion.ChampionName = existingChampion.ChampionName;
                _championData.UpdateChampion(existingChampion);
                return Ok($"{champion.ChampionName} has been updated." + champion);
            }
            return BadRequest();
        }
    }
}
