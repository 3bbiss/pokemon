using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    [ApiController]
    public class PokemonController : ControllerBase
    {
        [HttpGet]
        [Route("pokemon")]
        public async Task<IEnumerable<Pokemon>> GetAll()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            for(int i = 1; i <= 150; i++)
            {
                pokemons.Add( await Pokemon.GetPokemon(i));
            }
            return pokemons;
        }

        [HttpGet]
        [Route("pokemon/{id}")]
        public async Task<Pokemon> Get(int id)
        {
            return await Pokemon.GetPokemon(id);
        }
    }
}
