using StudentAssesment1.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using StudentAssesment1;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<StudentAssesmentDbContext>(builder.Configuration["StudentAssesment1DbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/songs", (StudentAssesmentDbContext db) =>
{
    return db.Songs.ToList();
});

app.MapPost("api/songs", (StudentAssesmentDbContext db, Song songs) =>
{
    db.Songs.Add(songs);
    db.SaveChanges();
    return Results.Created($"/api/Songs/{songs.Id}", songs);
});

app.MapDelete("api/songs/{id}", (StudentAssesmentDbContext db, int id) =>
{
    Song song = db.Songs.SingleOrDefault(pr => pr.Id == id);
    if (song == null)
    {
        return Results.NotFound();
    }
    db.Songs.Remove(song);
    db.SaveChanges();
    return Results.NoContent();
});

/*app.MapPut("/api//{id}", (CreekRiverDbContext db, int id, Campsite campsite) =>
{
    Campsite campsiteToUpdate = db.Campsites.SingleOrDefault(campsite => campsite.Id == id);
    if (campsiteToUpdate == null)
    {
        return Results.NotFound();
    }
    campsiteToUpdate.Nickname = campsite.Nickname;
    campsiteToUpdate.CampsiteTypeId = campsite.CampsiteTypeId;
    campsiteToUpdate.ImageUrl = campsite.ImageUrl;

    db.SaveChanges();
    return Results.NoContent();
});*/

app.Run();

