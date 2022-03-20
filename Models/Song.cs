namespace SongAPI.Models
{
    // Låt-klass
    public class Song
    {
        // Properties
        // Id
        public int Id { get; set; }

        // Låtnamn
        public string? Name { get; set; }

        // Artist
        public string? Artist { get; set; }

        // Året då låten gavs ut
        public string? Year { get; set; }

        // Längd
        public string? Length { get; set; }

        // Genre
        public string? Genre { get; set; }
    }
}
