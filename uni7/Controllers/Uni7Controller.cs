using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uni7.DataSource;
using uni7.Domain;

namespace uni7.Controllers
{
    [ApiController]
    [Route("api")]
    public class Uni7Controller : ControllerBase
    {
        private readonly UniDbContext dbContext;

        public Uni7Controller(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbContext.Database.EnsureCreated();
        }
        [HttpGet("species")]
        public async Task<ActionResult<IEnumerable<Species>>> GetAllSpecies()
        {
            var allSpecies = await dbContext
                                    .Species
                                    .ToListAsync();
            return Ok(allSpecies);
        }
        [HttpGet("species/{id}/breeds")]
        public async Task<ActionResult<IEnumerable<BreedViewModel>>> GetBreedBySpecies(int id)
        {
            var breedsBySpeciesId = await dbContext.Breeds
                                    .Include(breed => breed.Species)
                                    .Where(b => b.SpeciesID == id)
                                    .Select(b => new BreedViewModel(b.Id, b.Name, b.Species.Name))
                                    .ToListAsync();
            return breedsBySpeciesId.Any()? Ok(breedsBySpeciesId) : NotFound(id);
                            
        }
    }

    public record BreedViewModel (int Id, string Name, string SpeciesName);
}
