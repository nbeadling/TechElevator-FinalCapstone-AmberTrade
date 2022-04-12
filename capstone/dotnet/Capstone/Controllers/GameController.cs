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
    [Authorize]
    public class GameController : Controller
    {
        private IGameDAO gameDAO;

        public GameController(IGameDAO gameDAO)
        {
            this.gameDAO = gameDAO;
        }

        [HttpPost()]

        public ActionResult<Game> CreateGame(Game game)
        {
            Game added = gameDAO.CreateGame(game);
            return Created($"/game/{added.GameId}", added); 
        }

        [HttpGet("{id}")]
        public Game GetGameByGameId(int id)
        {
            return gameDAO.GetGamesById(id); 
        }

        //[HttpGet("/users/game")]

        //public Game GetGameByUserId(int id)
        //{
        //    return gameDAO.GetGamesByUser(id); 
        //}
    }
}
