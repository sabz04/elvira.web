using Microsoft.EntityFrameworkCore;

namespace elvira.web.Models
{
    public class MusicModelContext:DbContext
    {
        public DbSet<MusicModel> _musicModelContext { get; set; }
        public MusicModelContext(DbContextOptions<MusicModelContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}