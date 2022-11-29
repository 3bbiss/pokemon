using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class TrainersPokemon
    {
        // not including species only default is stored
        // will have buttons to toggle to show variety
        // fun idea for another time :)
        public int pokemon_id { get; set; }
        public int move_id { get; set; }
        public string pokemon_name {get; set; }
        public string move_name {get; set; }
        public PokemonSprites pokemon_pics {get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public List<string> type { get; set; }
        public int hp { get; set; }
    }
}
