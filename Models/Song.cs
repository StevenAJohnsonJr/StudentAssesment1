using Microsoft.AspNetCore.Routing.Constraints;

namespace StudentAssesment1.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int  ArtistId { get; set; }
        public string Album { get; set;}
        public DateTime Length { get; set;}
    }
}
