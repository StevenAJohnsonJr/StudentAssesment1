using Microsoft.AspNetCore.Routing.Constraints;

namespace StudentAssesment1.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public int ArtistsId { get; set; }
        public string Album { get; set; }
        public DateTime Length { get; set; }

        public List<Genre> Genres { get; set; }
       
    }
}

