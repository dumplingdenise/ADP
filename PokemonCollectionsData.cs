using Microsoft.EntityFrameworkCore;

namespace PokemonPocket
{
    public class PokemonCollectionsData : DbContext
    {
        public DbSet<PokemonCollection> Pokemonslist { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PokemonCollection.db");
        }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        // }

    }

}
