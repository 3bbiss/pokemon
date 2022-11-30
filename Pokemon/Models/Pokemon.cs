using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public bool is_default { get; set; } 
        public int order { get; set; } 
        public int weight { get; set; }
        public List<Move> moves { get; set; }
        public PokemonSprites sprites { get; set; }
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

        // busted - issue with how data returns from api when doing limit
        // is different from the pokemon object for get one
        //public static async Task<List<Pokemon>> GetAllPokemon()
        //{
        //    HttpClient client = new HttpClient();
        //    var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/?limit=150");
        //    List<Pokemon> response = await pokeRequest.Content.ReadAsAsync<List<Pokemon>>();

        //    return response;
        //}


    }
}
