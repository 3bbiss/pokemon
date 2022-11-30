using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; } // Do we want this for a default image/version?
        // could be used for just the initial image display and then have a conditional for when we don't want it

        public int order { get; set; } // idk what this is
        public int weight { get; set; }
        public List<Move> moves { get; set; }
        public PokemonSprites sprites { get; set; }

        // may be nested - separate from species call in pokemon resource
        public SpeciesName species { get; set; }
        public List<Stats> stats { get; set; }
        public List<Type> types { get; set; }




        public static async Task<Pokemon> GetPokemon(int id)
        {
            HttpClient client = new HttpClient();
            var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            Pokemon response = await pokeRequest.Content.ReadAsAsync<Pokemon>();

            return response;
        }



        public static async Task<List<Pokemon>> GetAllPokemon()
        {
            HttpClient client = new HttpClient();
            var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/?limit=150");
            List<Pokemon> response = await pokeRequest.Content.ReadAsAsync<List<Pokemon>>();

            return response;
        }


    }
}
