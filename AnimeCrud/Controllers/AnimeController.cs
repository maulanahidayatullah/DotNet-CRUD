using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnimeCrud.Models;
using AnimeCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeCrud.Controllers
{
    [Route("api/anime")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private readonly ApiContext _context;

        public AnimeController(ApiContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAnime()
        {
            return Ok(await _context.Animes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAnime (AddAnimeRequest request)
        {
            var anime = new Anime()
            {
                id = Guid.NewGuid(),
                nama = request.nama,
                deskripsi = request.deskripsi,
            };

            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();

            return Ok(anime);
        }
    }
}
