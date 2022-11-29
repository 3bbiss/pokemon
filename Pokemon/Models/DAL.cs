using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;


namespace Pokemon
{
    public class DAL
    {
        // hola
        public static MySqlConnection DB;

        public static IEnumerable<Team> GetAllTeams()  //DB Team
        {
            return DB.GetAll<Team>();
        }

        public static Team AddTeam(Team team) //DB Team
        {
            DB.Insert(team);
            return team;
        }

        public static void DeleteTeam(int id) //DB Team
        {
            DB.Delete(new Team { id = id });
        }

        public static void UpdateTeam(Team team) //DB Team
        {
            DB.Update(team);
        }
    }
}
