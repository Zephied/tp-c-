using Microsoft.EntityFrameworkCore;
using WpfApp4.Model;

public class GameDbContext : DbContext
{
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=ExerciceMonster;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Monster>().HasData(
            new Monster { Id = 1, Name = "Pikachu", Health = 100, ImageUrl = "pikachu.png" },
            new Monster { Id = 2, Name = "Charmander", Health = 120, ImageUrl = "charmander.png" }
        );

        modelBuilder.Entity<Spell>().HasData(
            new Spell { Id = 1, Name = "Thunderbolt", Damage = 50, Description = "A powerful electric attack" },
            new Spell { Id = 2, Name = "Flamethrower", Damage = 60, Description = "A fiery blast that scorches the opponent" }
        );
    }
}
