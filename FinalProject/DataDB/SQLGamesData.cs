using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.DataDB
{
    public class SQLGamesData : IGamesData
    {
        private CoreDbContext _gamesData;
        public SQLGamesData(CoreDbContext gamesData)
        {
            _gamesData = gamesData;
        }
        public Game AddGame(Game game)
        {
            game.Title = game.Title;
            _gamesData.Games.Add(game);
            _gamesData.SaveChanges();
            return game;
        }

        public void DeleteGame(Game game)
        {

            _gamesData.Games.Remove(game);
            _gamesData.SaveChanges();

        }

        public List<Game> GetGames()
        {
            return _gamesData.Games.ToList();
        }

        public Game GetGame(string title)
        {
            var game = _gamesData.Games.Find(title);
            return game;
        }

        public Game UpdateGame(Game game)
        {
            var existingGame = _gamesData.Games.Find(game.Title);
            if (existingGame != null)
            {
                _gamesData.Games.Update(game);
                _gamesData.SaveChanges();
            }
            return game;
        }
    }
}


