using FinalProject.DataDB;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class PokemonController : Controller
    {
        private IPokemonData _pokemonData;
        public PokemonController(IPokemonData pokemonData)
        {
            _pokemonData = pokemonData;
        }
        //Read
        [HttpGet]
        [Route("api/pokemoncontroller/pokemon")]
        public IActionResult GetPokemons()
        {
            return Ok(_pokemonData.GetPokemons());
        }
        [HttpGet]
        [Route("api/pokemoncontroller/pokemon/{name}")]
        public IActionResult GetPokemon(string name)
        {
            if (name != null)
            {
                return Ok(_pokemonData.GetPokemon(name));
            }
            return NotFound($"Pokemon : {name} is not found.");
        }
        //Create
        [HttpPost]
        [Route("api/pokemoncontroller/addPokemon")]
        public IActionResult AddPokemon(Pokemon pokemon)
        {
            _pokemonData.AddPokemon(pokemon);

            return Created(HttpContext.Request + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + pokemon.Name, pokemon);
        }
        //Delete
        [HttpDelete]
        [Route("api/pokemoncontroller/deletePokemon/{name}")]
        public IActionResult DeletePokemon(string name)
        {
            var pokemon = _pokemonData.GetPokemon(name);
            if (pokemon != null)
            {
                _pokemonData.DeletePokemon(pokemon);
                return Ok($"Pokemon : {name} has been deleted.");
            }
            return NotFound($"Pokemon : {name} is not found.");
        }
        //Update
        [HttpPatch]
        [Route("api/pokemoncontroller/updatePokemon/{name}")]
        public IActionResult updatePokemon(string name, Pokemon pokemon)
        {
            var existingPokemon = _pokemonData.GetPokemon(name);
            if (existingPokemon != null)
            {
                //full name doesn't get updated? why?
                pokemon.Name = existingPokemon.Name;
                _pokemonData.UpdatePokemon(pokemon);
                return Ok($"{pokemon.Name} has been updated." + pokemon);
            }
            return BadRequest();
        }
    }
}
