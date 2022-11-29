using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class Variety
    {
        public bool is_default { get; set; }
        // is this wrong? probably :(
        public Pokemon pokemon { get; set; }
    }
}
