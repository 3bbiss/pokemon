using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace Pokemon.Controllers
{
    [Route("team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TeamDisplay>> GetAll()
        {
            return await DAL.GetAllTeams();
        }

        [HttpPost]
        public void Add(TeamDisplay team)
        {
            DAL.AddTeam(team);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DAL.DeleteTeam(id);
        }
       
        [HttpPut]
        public void Update(TeamDisplay team)
        {
            DAL.UpdateTeam(team);
        }
    }
}
