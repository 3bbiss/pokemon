using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using System.Diagnostics.Metrics;

namespace Pokemon
{
    public class DAL
    {
        // hola
        public static MySqlConnection DB;
        // Do we want to do this the new way Jeff showed us during Flex week? E.g... opening and closing
        // the MySqlConnection properly each time we use it to avoid those annoying errors.

        // So, 
        // "public static string CS"  **CS stands for Connection String and lives in DAL.cs**
        // Instead of "public static mySqlConnection DB"
        // Then, we'd create 2 variables in "program.cs"
        //      string connstring = app.Configuration.GetConnectionString("db");
        //      DAL.CS = connstring;

        // Example below of referencing connection string new way 
        /*
         
        public static List<ShortRepairList> getAll()
        {
            // Here's how we do it with just a query and not a view
            //return DAL.DB.Query<ShortRepairOrder>("select ro.id, ro.customer, ins.name as Instrument from repairorder ro join instrument ins on ro.instrument_id = ins.id;").ToList();
            // But some argue that putting queries in C# code is not the best idea.
            MySqlConnection db = new MySqlConnection(DAL.CS);
            db.Open();
            var result = db.GetAll<ShortRepairList>().ToList();
            db.Close();
            return result;
        } 

         */


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




        // TRAINER Static CRUD Operations (OLD WAY)

        public static IEnumerable<Trainer> GetAllTrainers()
        {
            return DB.GetAll<Trainer>();
        }

        public static Trainer GetTrainer(int id)
        {
            return DB.Get<Trainer>(id);
        }

        public static Trainer AddTrainer(Trainer trainer)
        {
            DB.Insert(trainer);
            return trainer;
        }

        public static void Update(Trainer trainer)
        {
            DB.Update(trainer);
        }

        public static void Delete(int id)
        {
            DB.Delete(new Trainer { id = id });
        }


    }
}
