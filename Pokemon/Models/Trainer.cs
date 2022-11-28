using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    [Table("trainer")]
    public class Trainer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}