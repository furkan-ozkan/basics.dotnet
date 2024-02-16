using api.Data;
using api.Mappers;
using api.Dtos.Anime;
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
            .Select(s => s.ToAnimeRequestDto());

            return Ok(animes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var anime = _context.Animes.Find(id);
            if (anime == null)
                return NotFound();
            return Ok(anime.ToAnimeRequestDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimeRequestDto animeDto)
        {
            var animeModel = animeDto.ToAnimeFromCreateDTO();
            _context.Animes.Add(animeModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = animeModel.id }, animeModel.ToAnimeRequestDto());

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateAnimeRequestDto animeDto)
        {
            var animeModel = _context.Animes.Find(id);
            if (animeModel == null)
                return NotFound();
            animeDto.UpdateToAnimeFromAnimeDTO(animeModel);
            _context.SaveChanges();
            return Ok(animeModel.ToAnimeRequestDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var animeModel = _context.Animes.Find(id);
            if (animeModel == null)
                return NotFound();
            _context.Animes.Remove(animeModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}