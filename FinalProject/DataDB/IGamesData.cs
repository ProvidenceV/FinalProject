using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.DataDB
{
    public interface IGamesData
    {

        List<Game> GetGames();

        Game AddGame(Game game);
        Game GetGame(string title);

        Game UpdateGame(Game game);

        void DeleteGame(Game game);


    }
}
