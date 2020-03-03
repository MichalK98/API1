using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPlayers()
        {
            return Ok(PlayersDataStore.Current.Players);
        }

        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var playerReturn = PlayersDataStore.Current.Players.FirstOrDefault(
                player => player.Id == id
            );

            if (playerReturn == null)
            {
                return NotFound();
            }

            return Ok(playerReturn);
        }
    }
}
