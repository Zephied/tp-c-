using Microsoft.EntityFrameworkCore;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using (var context = new GameDbContext())
        {
            context.Database.EnsureCreated();
        }
    }
}
