using FinalProject.DataDB;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class GameController : Controller
    {
        private IGamesData _gamesData;
        public GameController(IGamesData gamesData)
        {
            _gamesData = gamesData;
        }
        //Read
        [HttpGet]
        [Route("api/gamecontroller/games")]
        public IActionResult GetGames()
        {
            return Ok(_gamesData.GetGames());
        }
        [HttpGet]
        [Route("api/gamecontroller/games/{title}")]
        public IActionResult GetGame(string title)
        {
            if (title != null)
            {
                return Ok(_gamesData.GetGame(title));
            }
            return NotFound($"Game : {title} is not found.");
        }
        //Create
        [HttpPost]
        [Route("api/gamecontroller/addGames/")]
        public IActionResult AddGames(Game game)
        {
            _gamesData.AddGame(game);

            return Created(HttpContext.Request + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + game.Title, game);
        }
        //Delete
        [HttpDelete]
        [Route("api/gamecontroller/deleteGames/{title}")]
        public IActionResult DeleteGames(string title)
        {
            var game = _gamesData.GetGame(title);
            if (game != null)
            {
                _gamesData.DeleteGame(game);
                return Ok($"Game : {title} has been deleted.");
            }
            return NotFound($"Game : {title} is not found.");
        }
        //Update
        [HttpPatch]
        [Route("api/gamecontroller/updateGames/{title}")]
        public IActionResult UpdateGames(string title, Game game)
        {
            var existingGame = _gamesData.GetGame(title);
            if (existingGame != null)
            {
                //full name doesn't get updated? why?
                game.Title = existingGame.Title;
                _gamesData.UpdateGame(game);
                return Ok($"{game.Title} has been updated." + game);
            }
            return BadRequest();
        }
    }
}
