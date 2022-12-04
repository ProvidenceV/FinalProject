using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.DataDB
{
    public interface IPokemonData
    {
        List<Pokemon> GetPokemons();

        Pokemon AddPokemon(Pokemon pokemon);
        Pokemon GetPokemon(string name);

        Pokemon UpdatePokemon(Pokemon pokemon);

        void DeletePokemon(Pokemon pokemon);
    }
}
