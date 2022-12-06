using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Pokemon.Controllers
{
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // create new instance of PokeApi
        // to reference instead of Pokemon.GetPokemon
        private PokeApi pokeApi;
        
        public PokemonController(IMemoryCache memoryCache)
        {
            pokeApi = new PokeApi(memoryCache);
        }

        [HttpGet]
        [Route("pokemon")]
        public async Task<IEnumerable<Pokemon>> GetAll()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            for(int i = 1; i <= 151; i++)
            {
                pokemons.Add( await pokeApi.GetPokemon(i));
            }
            return pokemons;
        }

        [HttpGet]
        [Route("pokemon/{id}")]
        public async Task<Pokemon> Get(int id)
        {
            return await pokeApi.GetPokemon(id);
        }
    }
}
