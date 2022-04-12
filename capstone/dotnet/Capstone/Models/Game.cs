using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public string GameName { get; set; }

        public Game(int gameId, string gameName)
        {
            this.GameId = gameId;
            this.GameName = gameName;
        }

        public Game()
        {

        }
    }
}
