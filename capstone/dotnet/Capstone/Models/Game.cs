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

        public string UserName { get; set; } = "";

        public int UserId { get; set; }

        public Game(int gameId, string gameName, int userId)
        {
            this.GameId = gameId;
            this.GameName = gameName;
            this.UserId = userId;

        }

        public Game()
        {

        }

  
    }
}
