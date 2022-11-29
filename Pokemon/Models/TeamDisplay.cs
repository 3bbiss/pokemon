using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon
{
    public class TeamDisplay
    {
        public int team_id { get; set; }
        public string team_name { get; set; }
        // doesn't matter where you get it from, it's still just an id that feeds wherever it go
        // (as long as it's the right id)
        public int trainer_id { get; set; }
        // never hurts to have id and name
        public string trainer_name { get; set; }
        // want list because we have a list of up to 6 pokemon within a team(single object)
        // we can use the pokemon class because it has an id, name, and moves
        // and move object has an id per move
        public List<TrainersPokemon> pokemon { get; set; }

        // remove trainer? no, need for name
        // remove pokemonteam from constructor as it's not being used and we will reference it later
        public TeamDisplay(Team team, List<TrainersPokemon> pokemon, Trainer trainer)
        {
            // do we need team id twice from both tables? - no see above
            team_id = team.id;
            team_name = team.name;
            //is trainer id from team or from trainer? - see above
            // do we care about trainer details for this class or no because we have endpoints for trainer already - never hurts
            trainer_id = trainer.id;
            trainer_name = trainer.name;
            //confirm any mapping is on desired class not originator class - doesn't matter
            this.pokemon = pokemon;
        }

        // AddTeam(TeamDisplay team)
        // {
        /*   new Team object(pass in team_id, trainer_id)
             new PokemonTeam(pass in team_id, pokemon_id, pokemonmove_id)
        */
        // }

        /*GetAllTeams()
         * List of pokemon display to get all teams
         */

        /*GetAllTeamsbyTrainer(int trainer_id)
        * List of pokemon display to get all teams by trainer
        */

        /*GetOneTeam(team_id)
        * 
        */

        // UpdateTeam(TeamDisplay team) // why whole class instead of a team id
        // {
        /*   update Team object(pass in team_id, trainer_id)
             update PokemonTeam(pass in team_id, pokemon_id, pokemonmove_id)
        */
        // }
    }


}
