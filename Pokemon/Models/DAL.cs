using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using System.Diagnostics.Metrics;

namespace Pokemon
{
    public class DAL
    {
        // hola
        public static MySqlConnection DB;
        public static string CS; // Connection String


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

        //public static async Task<Pokemon> GetPokemon(int id)
        //{
        //    HttpClient client = new HttpClient();
        //    var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
        //    Pokemon response = await pokeRequest.Content.ReadAsAsync<Pokemon>();

        //    return response;
        //}

        //public static async Task<List<Pokemon>> GetAllPokemon()
        //{
        //    HttpClient client = new HttpClient();
        //    var pokeRequest = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/?limit=150");
        //    List<Pokemon> response = await pokeRequest.Content.ReadAsAsync<List<Pokemon>>();

        //    return response;
        //}


        //public static async Task<List<TeamDisplay>> GetAllTeams()  //DB Team
        //{
        //    List<Team> teams = DB.GetAll<Team>().ToList();
        //    List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().ToList();
        //    List<Trainer> trainers = DB.GetAll<Trainer>().ToList();

        //    List<TeamDisplay> teamDisplays = new List<TeamDisplay>();
            
        //    foreach(Team team in teams)
        //    {
        //        // reference constructor
        //        Trainer trainer = (trainers.First(x => x.id == team.trainer_id));
        //        List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();
        //        // to list because of multiple entries for pokemon to 1 team
        //        List<PokemonTeam> pokemonTeam = pokemonTeams.Where(x => x.team_id == team.id).ToList();
        //        foreach(PokemonTeam pt in pokemonTeam)
        //        {
        //            TrainersPokemon trainersPokemon = new TrainersPokemon();
        //            trainersPokemon.pokemon_id = pt.pokemon_id;
        //            trainersPokemon.move_id = pt.move_id;
        //            Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
        //            trainersPokemon.pokemon_name = pokemon.name;
        //            trainersPokemon.pokemon_pics = pokemon.sprites;
        //            trainersPokemon.height = pokemon.height;
        //            trainersPokemon.weight = pokemon.weight;
                    
        //            foreach(Type type in pokemon.types)
        //            {
        //                trainersPokemon.type.Add(type.type.name);
        //            }

        //            trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
        //            trainersPokemon.move_name = pokemon.moves.First(x => x.move.GetId() == pt.move_id).move.name;

        //            trainersPokemons.Add(trainersPokemon);
        //        }
        //        TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);
        //        teamDisplays.Add(teamDisplay);
        //    }
        //    return teamDisplays;
        //}

        // this one uses the team id
        //public static async Task<TeamDisplay> GetOneTeam(int team_id)  //DB Team
        //{
        //    Team team = DB.Get<Team>(team_id);
        //    List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().Where(x => x.team_id == team_id).ToList();
        //    Trainer trainer = DB.Get<Trainer>(team.trainer_id);

        //    List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();

        //    foreach (PokemonTeam pt in pokemonTeams)
        //    {
        //        TrainersPokemon trainersPokemon = new TrainersPokemon();
        //        trainersPokemon.pokemon_id = pt.pokemon_id;
        //        trainersPokemon.move_id = pt.move_id;
        //        Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
        //        trainersPokemon.pokemon_name = pokemon.name;
        //        trainersPokemon.pokemon_pics = pokemon.sprites;
        //        trainersPokemon.height = pokemon.height;
        //        trainersPokemon.weight = pokemon.weight;

        //        foreach (Type type in pokemon.types)
        //        {
        //            trainersPokemon.type.Add(type.type.name);
        //        }

        //        trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
        //        trainersPokemon.move_name = pokemon.moves.First(x => x.move.GetId() == pt.move_id).move.name;

        //        trainersPokemons.Add(trainersPokemon);
        //    }
        //    TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);

        //    return teamDisplay;
        //}

        // this uses the trainer id
        //public static async Task<List<TeamDisplay>> GetAllTeamsbyTrainer(int trainer_id)  //DB Team
        //{
        //    Trainer trainer = DB.Get<Trainer>(trainer_id);
        //    List<Team> teams = DB.GetAll<Team>().Where(x => x.trainer_id == trainer_id).ToList();
        //    List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().ToList();

        //    List<TeamDisplay> teamDisplays = new List<TeamDisplay>();

        //    foreach (Team team in teams)
        //    {
        //        List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();
                
        //        List<PokemonTeam> pokemonTeam = pokemonTeams.Where(x => x.team_id == team.id).ToList();

        //        foreach (PokemonTeam pt in pokemonTeam)
        //        {
        //            TrainersPokemon trainersPokemon = new TrainersPokemon();
        //            trainersPokemon.pokemon_id = pt.pokemon_id;
        //            trainersPokemon.move_id = pt.move_id;
        //            Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
        //            trainersPokemon.pokemon_name = pokemon.name;
        //            trainersPokemon.pokemon_pics = pokemon.sprites;
        //            trainersPokemon.height = pokemon.height;
        //            trainersPokemon.weight = pokemon.weight;

        //            foreach (Type type in pokemon.types)
        //            {
        //                trainersPokemon.type.Add(type.type.name);
        //            }

        //            trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
        //            trainersPokemon.move_name = pokemon.moves.First(x => x.move.GetId() == pt.move_id).move.name;

        //            trainersPokemons.Add(trainersPokemon);
        //        }
        //        TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);
        //        teamDisplays.Add(teamDisplay);
        //    }
        //    return teamDisplays;
        //}

        //public static void AddTeam(TeamDisplay teamDisplay) //DB Team
        //{
        //    Team team = new Team();
        //    team.trainer_id = teamDisplay.trainer_id;
        //    team.name = teamDisplay.team_name;
        //    DB.Insert(team);

        //    foreach (TrainersPokemon pokemon in teamDisplay.pokemon)
        //    {
        //        // limit number of pokemon on a team to 6 in frontend
        //        PokemonTeam pokemonTeam = new PokemonTeam();
        //        pokemonTeam.team_id = team.id;
        //        pokemonTeam.pokemon_id = pokemon.pokemon_id;
        //        pokemonTeam.move_id = pokemon.move_id;
        //        DB.Insert(pokemonTeam);
        //    }
        //}

        //public static void DeleteTeam(int id) //DB Team
        //{
        //    DB.Delete(new PokemonTeam { team_id = id });
        //    DB.Delete(new Team { id = id });
        //}

        //public static void UpdateTeam(TeamDisplay team) //DB Team
        //{
        //    DB.Update(new Team
        //    {
        //        id = team.team_id,
        //        name = team.team_name,
        //        trainer_id = team.trainer_id,
        //    });
        //    DB.Delete(new PokemonTeam { team_id = team.team_id });

        //    foreach (TrainersPokemon pokemon in team.pokemon)
        //    {
        //        // limit number of pokemon on a team to 6 in frontend
        //        PokemonTeam pokemonTeam = new PokemonTeam();
        //        pokemonTeam.team_id = team.team_id;
        //        pokemonTeam.pokemon_id = pokemon.pokemon_id;
        //        pokemonTeam.move_id = pokemon.move_id;
        //        DB.Insert(pokemonTeam);
        //    }
        //}




        // TRAINER Static CRUD Operations (OLD WAY)

        //public static IEnumerable<Trainer> GetAllTrainers()
        //{
        //    return DB.GetAll<Trainer>();
        //}

        //public static Trainer GetTrainer(int id)
        //{
        //    return DB.Get<Trainer>(id);
        //}

        //public static Trainer AddTrainer(Trainer trainer)
        //{
        //    DB.Insert(trainer);
        //    return trainer;
        //}

        //public static void Update(Trainer trainer)
        //{
        //    DB.Update(trainer);
        //}

        //public static void Delete(int id)
        //{
        //    DB.Delete(new Trainer { id = id });
        //}


    }
}
