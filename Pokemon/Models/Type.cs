using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class Type
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<TypeRelation> damage_relations { get; set; }
    }
}
