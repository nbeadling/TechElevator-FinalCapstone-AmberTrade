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
        public ActionResult<int> CreateGame(Game game)
        {

            Game added = gameDAO.CreateGameId(game);
            //return Created($"/game/{added.GameId}", added);
            return added.GameId;

        }

        //[HttpGet("{id}")]
        //public Game GetGameByGameId(int id)
        //{
        //    return gameDAO.GetGamesById(id); 
        //}

        [HttpGet("{userId}")]

        public List<Game> ViewGameByUserId(int userId)
        {
            List<Game> listGames = gameDAO.ViewGamesByUserId(userId);
            return listGames;
        }

        //[HttpPost("/invte/{userId}")]

        //public ActionResult<Game> InvitePlayer(int userID, String gameName)
        //{
        //    Game added = gameDAO.CreateGame(game);
        //    return Created($"/game/{added.GameId}", added);
        //}
    }
}
