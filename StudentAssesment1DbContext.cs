using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using StudentAssesment1.Models;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

namespace StudentAssesment1
{
    public class StudentAssesmentDbContext : DbContext
    {

        public DbSet<Genre>? Genres { get; set; }
        public DbSet<SongGenre>? SongGenres { get; set; }
        public DbSet<Song>? Songs { get; set; }
        public DbSet<Artist>? Artists { get; set; }
        
        public StudentAssesmentDbContext(DbContextOptions<StudentAssesmentDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Genre>().HasData(new Genre[]
           {
            new Genre {Id = 1, Description = "Hip-Hop"},
            new Genre {Id = 2, Description = "Rhythm and blues"},
            new Genre {Id = 3, Description = "Funk"},
            new Genre {Id = 4, Description = "Reggae"},
            new Genre {Id = 5, Description = "Jazz"},
           });

            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
            new Artist {Id = 1, Name = "Jay-z", Age = 53, Bio = "Shawn Corey Carter, known professionally as Jay-Z, is an American rapper, record producer, and entrepreneur. Often regarded as the greatest rapper of all time, he has been central to the creative and commercial success of artists including Kanye West, Rihanna, and J. Cole."},
            new Artist {Id = 2, Name = "Marvin Gaye", Age = 44, Bio = "Marvin Pentz Gay Jr., known professionally as Marvin Gaye, was an American R&B and soul singer and songwriter"},
            new Artist {Id = 3, Name = "Parliament-Funkadelic", Age = 82, Bio = "Parliament-Funkadelic is an American music collective of rotating musicians headed by George Clinton, primarily consisting of the funk bands Parliament and Funkadelic, both active since the 1960s"},
            new Artist {Id = 4, Name = "Bob Marley", Age = 36, Bio = "Robert Nesta Marley OM was a Jamaican singer, musician, and songwriter. Considered one of the pioneers of reggae, his musical career was marked by fusing elements of reggae, ska, and rocksteady, as well as his distinctive vocal and songwriting style."},
            new Artist {Id = 5, Name = "Myles davis", Age = 65, Bio = "Miles Dewey Davis III was an American jazz musician, trumpeter, bandleader, and composer. He is among the most influential and acclaimed figures in the history of jazz and 20th-century music."},
            
            });

            modelBuilder.Entity<Song>().HasData(new Song[]
            {
            new Song {Id = 1, Title = "Takeover", ArtistsId = 1, Album = "Blueprint", Length = new DateTime(2023, 4, 20, 0, 3, 45)},
            new Song {Id = 2, Title = "Lets Get It On", ArtistsId = 2, Album = "Lets Get It On", Length = new DateTime(2023, 5, 2, 0, 4, 15)},
            new Song {Id = 3, Title = "Atomic Dog", ArtistsId = 3, Album = "Computer Games", Length = new DateTime(2023, 6, 30, 0, 5, 20)},
            new Song {Id = 4, Title = "Buffalo Soldier", ArtistsId = 4, Album = "Confrontation", Length = new DateTime(2023, 2, 20, 0, 3, 10)},
            new Song {Id = 5, Title = "Bye Bye Blackbird", ArtistsId = 5, Album = "Round About Midnight", Length = new DateTime(2023, 1, 28, 0, 2, 45)},
            });



            modelBuilder.Entity<SongGenre>().HasData(new SongGenre[]
            {
            new SongGenre {Id = 1, SongId = 1, GenreId = 1},
            new SongGenre {Id = 2, SongId = 2, GenreId = 2},
            new SongGenre {Id = 3, SongId = 3, GenreId = 3},
            new SongGenre {Id = 4, SongId = 4, GenreId = 4},
            new SongGenre {Id = 5, SongId = 5, GenreId = 5},
            });

            ;

        }
    }
}
