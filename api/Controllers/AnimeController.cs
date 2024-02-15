using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/anime")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public AnimeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var animes = _context.Animes.ToList()
            .Select(s => s.ToAnimeDto());

            return Ok(animes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var anime = _context.Animes.Find(id);
            if (anime == null)
                return NotFound();
            return Ok(anime.ToAnimeDto());
        }
    }
}