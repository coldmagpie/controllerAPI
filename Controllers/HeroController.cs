using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroAPI.Models;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private static List<Hero> _heros = new List<Hero>()
        {
            new Hero() { Id = 1, Name = "Tony Stark", Team = "Avengers", SuperHeroName = "IronMan" },
            new Hero() {Id = 2, Name = "Bruce Wayne", Team = "Justice League", SuperHeroName = "BatMan"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heros);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heros.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heros.Add(hero);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {
            var heroToUpdate = _heros.FirstOrDefault(x => x.Id == hero.Id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team = hero.Team;
            heroToUpdate.SuperHeroName = hero.SuperHeroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete = _heros.FirstOrDefault(x => x.Id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }

            _heros.Remove(heroToDelete);
            return Ok();
        }

    }
}
