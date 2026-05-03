using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400097;

namespace TP_MODUL10_103022400097.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> _filmList = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetAll()
        {
            return Ok(_filmList);
        }

        
        [HttpGet("{index}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 0 || index >= _filmList.Count) return NotFound();

            return Ok(_filmList[index]);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Film baru)
        {
            _filmList.Add(baru);
            return Ok(_filmList); 
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= _filmList.Count) return NotFound();

            _filmList.RemoveAt(index);
            return Ok(new { message = "Film berhasil dihapus" });
        }
    }
}