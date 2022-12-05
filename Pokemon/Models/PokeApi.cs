using Microsoft.Extensions.Caching.Memory;

namespace Pokemon
{
    public class PokeApi
    {
        // add property for an instance of the cache provider
        private IMemoryCache _memoryCache;

        public PokeApi(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<Pokemon> GetPokemon(int id)
        {
            // get pokemon object
            // if our memory cache contains a pokemon for this id return a pokemon object
            // pokemon object must allow null, because if not found within the cache
            // we want to still output/return "null" and fetch from API
            if (_memoryCache.TryGetValue<Pokemon>(id, out Pokemon? pokemon))
            {
                // if we return a pokemon we know it's not null
                // because we found the id in the cache
                return pokemon!;
            }
            // else, make api call to get pokemon with that id 
            
            HttpClient client = new HttpClient();
            var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            Pokemon response = await pokeRequest.Content.ReadAsAsync<Pokemon>();
            // can set timer
            _memoryCache.Set(id, response);
            return response;
        }
    }
}
