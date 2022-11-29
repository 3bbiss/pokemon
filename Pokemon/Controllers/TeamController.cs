using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    [Route("team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Team> GetAll()
        {
            return DAL.GetAllTeams();
        }

        [HttpPost]
        public Team Add(Team team)
        {
            return DAL.AddTeam(team);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DAL.DeleteTeam(id);
        }

        [HttpPut]
        public void Update(Team team)
        {
            DAL.UpdateTeam(team);
        }
    }
}
