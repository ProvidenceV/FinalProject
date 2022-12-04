using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.DataDB
{
    public class SQLPokemonData : IPokemonData
    {
        private CoreDbContext _pokemonContext;
        public SQLPokemonData(CoreDbContext pokemonContext)
        {
            _pokemonContext = pokemonContext;
        }
        public Pokemon AddPokemon(Pokemon pokemon)
        {
            pokemon.Name = pokemon.Name;
            _pokemonContext.Pokemons.Add(pokemon);
            _pokemonContext.SaveChanges();
            return pokemon;
        }

        public void DeletePokemon(Pokemon pokemon)
        {

            _pokemonContext.Pokemons.Remove(pokemon);
            _pokemonContext.SaveChanges();

        }

        public List<Pokemon> GetPokemons()
        {
            return _pokemonContext.Pokemons.ToList();
        }

        public Pokemon GetPokemon(string name)
        {
            var pokemon = _pokemonContext.Pokemons.Find(name);
            return pokemon;
        }

        public Pokemon UpdatePokemon(Pokemon pokemon)
        {
            var existingPokemon = _pokemonContext.Pokemons.Find(pokemon.Name);
            if (existingPokemon != null)
            {
                _pokemonContext.Pokemons.Update(pokemon);
                _pokemonContext.SaveChanges();
            }
            return pokemon;
        }
    }
}

