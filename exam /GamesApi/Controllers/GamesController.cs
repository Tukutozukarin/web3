using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using GamesApi.Models;

namespace GamesApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GamesController : Controller
    {

        private readonly GamesContext _context;
        public GamesController(GamesContext context)
        {
            _context = context;
        }


        /* 
            - Get the game(s)
            - https://localhost:5001/games or whichever the port you are running
        */
        [HttpGet]
        public async Task<IEnumerable<Game>> GetTask()
        {

            List<Game> gameList = await _context.Game.ToListAsync();
            return gameList;
        }


        // Create a new game
        [HttpPost]
        public async Task<Game> Post(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        // Updating a existing game
        [HttpPut]
        public async Task<Game> Put(Game updateGame)
        {
            _context.Update(updateGame);
            await _context.SaveChangesAsync();
            return updateGame;

        }

        // To delete a specific game, input the id of the game
        [HttpDelete("{id}")]
        public async Task<Game> Delete(int id)
        {
            Game gameToDelete = await _context.Game.FirstAsync(game => game.Id == id);
            _context.Game.Remove(gameToDelete);
            await _context.SaveChangesAsync();
            return gameToDelete;
        }
    }
}