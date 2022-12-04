using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject.DataDB
{

    public interface IChampionData
    {
        List<Champion> GetChampions();

        Champion AddChampion(Champion champion);
        Champion GetChampion(string name);

        Champion UpdateChampion(Champion champion);

        void DeleteChampion(Champion champion);


    }
}


