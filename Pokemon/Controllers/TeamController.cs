using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon.Controllers
{
    
    [ApiController]
    public class TeamController : ControllerBase
    {
        
        [HttpGet]
        [Route("team")]
        public async Task<IEnumerable<TeamDisplay>> GetAll()
        {
            return await TeamDisplay.GetAllTeams();
        }

        [HttpGet]
        [Route("team/{id}")]
        public async Task<TeamDisplay> Get(int team_id)
        {
            return await TeamDisplay.GetOneTeam(team_id);
        }

        [HttpGet]
        [Route("team/trainer/{id}")]
        public async Task<IEnumerable<TeamDisplay>> GetAllTrainerTeams(int trainer_id)
        {
            return await TeamDisplay.GetAllTeamsbyTrainer(trainer_id);
        }

        [HttpPost]
        [Route("team")]
        public void Add(TeamDisplay team)
        {
            TeamDisplay.AddTeam(team);
        }

        [HttpDelete]
        [HttpDelete("{id}")]
        [Route("team/{id}")]
        public void Delete(int id)
        {
            TeamDisplay.DeleteTeam(id);
        }
       
        [HttpPut]
        [Route("team")]
        public void Update(TeamDisplay team)
        {
            TeamDisplay.UpdateTeam(team);
        }

    }
}
