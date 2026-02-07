using Microsoft.EntityFrameworkCore;
using Poke_Repo.Model;

namespace Poke_Repo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
      public DbSet<PokemonModel> Pokemons => Set<PokemonModel>();
    }

    
}
