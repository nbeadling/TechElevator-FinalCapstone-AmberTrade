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
        private IGameDao gameDAO;

        public GameController(IGameDao gameDAO)
        {
            this.gameDAO = gameDAO;
        }

        [HttpPost("create")]
        public int CreateGame(CreateGame gameInfo)
        {
            int userId = gameInfo.UserId;
            string gameName = gameInfo.GameName;
            DateTime startDate = gameInfo.StartDate;
            DateTime endDate = gameInfo.EndDate;
            int createdGameId = gameDAO.CreateGameId(gameName, userId, startDate, endDate);
            return createdGameId;
        }

        [HttpGet("{userId}")]
        public List<Holdings> ViewGameByUserId(int userId)
        {
            List<Holdings> listGames = gameDAO.ViewGamesByUserId(userId);
            return listGames;
        }

        [HttpPost("invte/{userId}")]
        public ActionResult<int> InvitePlayerGame(int userId, CreateGame gameId)
        {
            int added = gameDAO.InvitePlayer(userId, gameId);
            return Created($"/game/{added}", added);
        }
    }
}
