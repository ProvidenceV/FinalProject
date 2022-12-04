using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.DataDB
{
    public class SQLChampionData : IChampionData
    {
        private CoreDbContext _championData;
        public SQLChampionData(CoreDbContext championData)
        {
            _championData = championData;
        }
        public Champion AddChampion(Champion champion)
        {
            champion.ChampionName = champion.ChampionName;
            _championData.Champions.Add(champion);
            _championData.SaveChanges();
            return champion;
        }

        public void DeleteChampion(Champion champion)
        {

            _championData.Champions.Remove(champion);
            _championData.SaveChanges();

        }

        public List<Champion> GetChampions()
        {
            return _championData.Champions.ToList();
        }

        public Champion GetChampion(string name)
        {
            var champion = _championData.Champions.Find(name);
            return champion;
        }

        public Champion UpdateChampion(Champion champion)
        {
            var existingChampion = _championData.Champions.Find(champion.ChampionName);
            if (existingChampion != null)
            {
                existingChampion.ChampionName = champion.ChampionName;
                _championData.Champions.Update(existingChampion);
                _championData.SaveChanges();
            }
            return champion;
        }
    }
}

