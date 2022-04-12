using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models; 

namespace Capstone.DAO
{
    public interface IGameDAO
    {
        Game CreateGame(Game game);

        List<Game> GetGamesByUser(int id);

        Game GetGamesById(int id);
    }
}
