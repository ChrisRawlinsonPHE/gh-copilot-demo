using albums_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace albums_api.Controllers
{
    [Route("albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        // GET: api/album
        [HttpGet]
        public IActionResult Get()
        {
            var albums = Album.GetAll();

            return Ok(albums);
        }

        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // here we will get the album by id
            var album = Album.GetById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);

        }

        // function that retrieves albums and sorts them by title, artist or price
        // if no sort parameter is provided, it returns all albums ordered by id
        [HttpGet("sorted")]
        public IActionResult GetSorted(string? sort)
        {
            var albums = Album.GetAll();

            if (string.IsNullOrWhiteSpace(sort))
            {
                albums = albums.OrderBy(a => a.Id).ToList();
                return Ok(albums);
            }

            switch (sort.Trim().ToLower())
            {
                case "title":
                    albums = albums.OrderBy(a => a.Title).ToList();
                    break;
                case "artist":
                    albums = albums.OrderBy(a => a.Artist).ToList();
                    break;
                case "price":
                    albums = albums.OrderBy(a => a.Price).ToList();
                    break;
                default:
                    return BadRequest("Invalid sort parameter");
            }

            return Ok(albums);
        }

    }
}
