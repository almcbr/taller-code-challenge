using Microsoft.EntityFrameworkCore;

namespace Car.API.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
