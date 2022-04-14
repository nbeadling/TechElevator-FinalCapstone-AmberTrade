using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization; 

namespace Capstone.Controllers
{
    [Route("game")]
    [ApiController]
  
    public class GameController : Controller
    {
        private IGameDAO gameDAO;

        public GameController(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }

        [HttpPost("create")]
        public int CreateGame(Game gameInfo)
        {
            int userId = gameInfo.UserId;
            string gameName = gameInfo.GameName;
            int createdGameId = gameDAO.CreateGameId(userId, gameName);
            //return Created($"/game/{added.GameId}", added);
            return createdGameId;
        }

        [HttpGet("{userId}")]
        public List<Holdings> ViewGameByUserId(int userId)
        {
            List<Holdings> listGames = gameDAO.ViewGamesByUserId(userId);
            return listGames;
        }

        [HttpPost("invte/{userId}")]
        public ActionResult<int> InvitePlayerGame(int userId, Game gameId)
        {
            int added = gameDAO.InvitePlayer(userId, gameId);
            return Created($"/game/{added}", added);
        }
    }
}
