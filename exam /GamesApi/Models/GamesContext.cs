using Microsoft.EntityFrameworkCore; 

namespace GamesApi.Models {

    public class GamesContext : DbContext {

        public GamesContext(DbContextOptions<GamesContext> options) : base(options){}

        public DbSet<Game> Game { get; set; }
    }
}