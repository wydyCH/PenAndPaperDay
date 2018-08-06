using Microsoft.EntityFrameworkCore;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data
{
    public class PenAndPaperDBContext : DbContext
    {
        public PenAndPaperDBContext(DbContextOptions<PenAndPaperDBContext> options) : base(options)
        {
        }

        public DbSet<TimeRange> TimeRanges { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<ErrorLogEntry> ErrorLogEntries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<OfferedGame> OfferedGames { get; set; }

        public DbSet<UserOnOfferedGame> UserOnOfferedGames { get; set; }

        public DbSet<OfferedGameOnTag> OfferedGameOnTags { get; set; }
    }
}
