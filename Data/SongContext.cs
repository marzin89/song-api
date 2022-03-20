using Microsoft.EntityFrameworkCore;
using SongAPI.Models;

namespace SongAPI.Data
{
    // Klass för databasanslutning
    public class SongContext : DbContext
    {
        // Konstruktor
        public SongContext(DbContextOptions<SongContext> options) : base(options) {}

        // Skapar tabellen
        public DbSet<Song> SongS { get; set; }

    }
}
