using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using System.Runtime.CompilerServices;

namespace Pokemon
{
    public class TeamDisplay
    {
        public int team_id { get; set; }
        public string team_name { get; set; } 
        public int trainer_id { get; set; }
        public string? trainer_name { get; set; }
        public List<TrainersPokemon> pokemon { get; set; }
        public TeamDisplay() { }  // AA 12/1/2022 10:45 -- Do we need this empty constructor?
                                  // BH 12/1 7:51pm - yis, since we have the constructor below to easily populate within c#
                                  // the default for c# classes/models has an empty constructor - but since we have one, it would be
                                  // unable to deserialize the json we get back
                                  // example: https://github.com/neuecc/MessagePack-CSharp/issues/1449

        public TeamDisplay(Team team, List<TrainersPokemon> pokemon, Trainer trainer)
        {
            
            team_id = team.id;
            team_name = team.name;
            
            trainer_id = trainer.id;
            trainer_name = trainer.name;
            
            this.pokemon = pokemon;
        }

        public static async Task<List<TeamDisplay>> GetAllTeams()  //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            List<Team> teams = DB.GetAll<Team>().ToList();
            List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().ToList();
            List<Trainer> trainers = DB.GetAll<Trainer>().ToList();

            List<TeamDisplay> teamDisplays = new List<TeamDisplay>();

            foreach (Team team in teams)
            {
                // reference constructor
                Trainer trainer = (trainers.First(x => x.id == team.trainer_id));
                List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();
                // to list because of multiple entries for pokemon to 1 team
                List<PokemonTeam> pokemonTeam = pokemonTeams.Where(x => x.team_id == team.id).ToList();
                foreach (PokemonTeam pt in pokemonTeam)
                {
                    TrainersPokemon trainersPokemon = new TrainersPokemon();
                    trainersPokemon.pokemon_id = pt.pokemon_id;
                    trainersPokemon.move_id = pt.move_id;
                    Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
                    trainersPokemon.pokemon_name = pokemon.name;
                    trainersPokemon.pokemon_pics = pokemon.sprites;
                    trainersPokemon.height = pokemon.height;
                    trainersPokemon.weight = pokemon.weight;

                    foreach (Type type in pokemon.types)
                    {
                        trainersPokemon.type.Add(type.type.name);
                    }

                    trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
                    trainersPokemon.move_name = pokemon.moves.FirstOrDefault(x => x.move.GetId() == pt.move_id)?.move?.name ?? "";

                    trainersPokemons.Add(trainersPokemon);
                }
                TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);
                teamDisplays.Add(teamDisplay);
            }
            DB.Close();
            return teamDisplays;
        }

        public static async Task<TeamDisplay> GetOneTeam(int team_id)  //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            Team team = DB.Get<Team>(team_id);
            List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().Where(x => x.team_id == team_id).ToList();
            Trainer trainer = DB.Get<Trainer>(team.trainer_id);

            List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();

            foreach (PokemonTeam pt in pokemonTeams)
            {
                TrainersPokemon trainersPokemon = new TrainersPokemon();
                trainersPokemon.pokemon_id = pt.pokemon_id;
                trainersPokemon.move_id = pt.move_id;
                Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
                trainersPokemon.pokemon_name = pokemon.name;
                trainersPokemon.pokemon_pics = pokemon.sprites;
                trainersPokemon.height = pokemon.height;
                trainersPokemon.weight = pokemon.weight;

                foreach (Type type in pokemon.types)
                {
                    trainersPokemon.type.Add(type.type.name);
                }

                trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
                trainersPokemon.move_name = pokemon.moves.FirstOrDefault(x => x.move.GetId() == pt.move_id)?.move?.name ?? "";

                trainersPokemons.Add(trainersPokemon);
            }
            TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);

            DB.Close();
            return teamDisplay;
        }

        public static async Task<List<TeamDisplay>> GetAllTeamsbyTrainer(int trainer_id)  //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            Trainer trainer = DB.Get<Trainer>(trainer_id);
            List<Team> teams = DB.GetAll<Team>().Where(x => x.trainer_id == trainer_id).ToList();
            List<PokemonTeam> pokemonTeams = DB.GetAll<PokemonTeam>().ToList();

            List<TeamDisplay> teamDisplays = new List<TeamDisplay>();

            foreach (Team team in teams)
            {
                List<TrainersPokemon> trainersPokemons = new List<TrainersPokemon>();

                List<PokemonTeam> pokemonTeam = pokemonTeams.Where(x => x.team_id == team.id).ToList();

                foreach (PokemonTeam pt in pokemonTeam)
                {
                    TrainersPokemon trainersPokemon = new TrainersPokemon();
                    trainersPokemon.pokemon_id = pt.pokemon_id;
                    trainersPokemon.move_id = pt.move_id;
                    Pokemon pokemon = await Pokemon.GetPokemon(pt.pokemon_id);
                    trainersPokemon.pokemon_name = pokemon.name;
                    trainersPokemon.pokemon_pics = pokemon.sprites;
                    trainersPokemon.height = pokemon.height;
                    trainersPokemon.weight = pokemon.weight;

                    foreach (Type type in pokemon.types)
                    {
                        trainersPokemon.type.Add(type.type.name);
                    }

                    trainersPokemon.hp = pokemon.stats.First(x => x.stat.name == "hp").base_stat;
                    trainersPokemon.move_name = pokemon.moves.FirstOrDefault(x => x.move.GetId() == pt.move_id)?.move?.name ?? "";

                    trainersPokemons.Add(trainersPokemon);
                }
                TeamDisplay teamDisplay = new TeamDisplay(team, trainersPokemons, trainer);
                teamDisplays.Add(teamDisplay);
            }

            DB.Close();
            return teamDisplays;
        }

        public static void AddTeam(TeamDisplay teamDisplay) //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            Team team = new Team();
            team.trainer_id = teamDisplay.trainer_id;
            team.name = teamDisplay.team_name;
            DB.Insert(team);

            foreach (TrainersPokemon pokemon in teamDisplay.pokemon)
            {
                // limit number of pokemon on a team to 6 in frontend
                PokemonTeam pokemonTeam = new PokemonTeam();
                pokemonTeam.team_id = team.id;
                pokemonTeam.pokemon_id = pokemon.pokemon_id;
                pokemonTeam.move_id = pokemon.move_id;
                DB.Insert(pokemonTeam);
            }

            DB.Close();
        }

        public static void DeleteTeam(int id) //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            DB.Delete(new PokemonTeam { team_id = id });
            DB.Delete(new Team { id = id });

            DB.Close();
        }



        // NOT currently referencing this function anywhere. Do we need to keep the old one too (above)?
        // because it's being reference in TeamController.cs

        // Do we want 2 different delete() functions?
        // One where they're just deleting a team, and one where the team is
        // being deleted because they're deleting a trainer..

        // My thinking for the flow below...
            // For each pokemon... in each team... in list of trainer's teams
                // delete each pokemon
                // then, delete each team


        public static async Task DeleteTrainerTeams(int trainer_id)
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            Trainer trainer = new Trainer() { id = trainer_id};
            
            List<TeamDisplay> teams = await GetAllTeamsbyTrainer(trainer_id);

            foreach (TeamDisplay trainerTeam in teams)
            {
                TeamDisplay.DeleteTeam(trainerTeam.team_id);

                //foreach (TrainersPokemon pokemon in trainerTeam.pokemon)
                //{

                //    //DB.Delete<TrainersPokemon>(pokemon);
                //}

                //DB.Delete(new PokemonTeam { team_id = trainerTeam.team_id });
                
            }

            DB.Close();

        }


        public static void UpdateTeam(TeamDisplay team) //DB Team
        {
            MySqlConnection DB = new MySqlConnection(DAL.CS);
            DB.Open();

            DB.Update(new Team
            {
                id = team.team_id,
                name = team.team_name,
                trainer_id = team.trainer_id,
            });
            DB.Delete(new PokemonTeam { team_id = team.team_id });

            foreach (TrainersPokemon pokemon in team.pokemon)
            {
                // limit number of pokemon on a team to 6 in frontend
                PokemonTeam pokemonTeam = new PokemonTeam();
                pokemonTeam.team_id = team.team_id;
                pokemonTeam.pokemon_id = pokemon.pokemon_id;
                pokemonTeam.move_id = pokemon.move_id;
                DB.Insert(pokemonTeam);
            }

            DB.Close();
        }

    }


}
