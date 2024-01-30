using Microsoft.AspNetCore.Mvc;
using ApiMusicDaniiiii.Data;
using ApiMusicDaniiiii.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMusicDaniiiii.Controllers;  

[Route("api/[controller]")]
[ApiController]
public class SongsController : ControllerBase
{
    private readonly ApiDbContext dbContext;

    public SongsController(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    // GET: api/<SongsController>
    [HttpGet]
    public IEnumerable<Songs> Get()
    {
        return dbContext.Songs;
    }

    // GET api/<SongsController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var song = dbContext.Songs.FirstOrDefault(s => s.Id == id);

        if (song == null)
        {
            return NotFound();
        }

        return Ok(song);
    }


    [HttpPost]


    // PUT api/<SongsController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Songs updatedSong)
    {

        //Valida si es nulo y si estamos modificando el id de la canción correcta.
        if (updatedSong == null || id != updatedSong.Id)
        {
            return BadRequest();
        }

        var existingSong = dbContext.Songs.FirstOrDefault(s => s.Id == id);

        if (existingSong == null)
        {
            return NotFound();
        }

        existingSong.Title = updatedSong.Title;
        existingSong.Language = updatedSong.Language;

        dbContext.SaveChanges();

        return NoContent();
    }


    // DELETE api/<SongsController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var songToDelete = dbContext.Songs.FirstOrDefault(s => s.Id == id);

        if (songToDelete == null)
        {
            return NotFound();
        }

        dbContext.Songs.Remove(songToDelete);
        dbContext.SaveChanges();

        return NoContent();
    }

}
