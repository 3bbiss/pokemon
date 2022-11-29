using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    [Route("trainer")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Trainer> GetAllTrainers()
        {
            return DAL.GetAllTrainers();
        }

        [HttpGet("{id}")]
        public Trainer GetTrainer(int id)
        {
            return DAL.GetTrainer(id);
        }

        [HttpPost]
        public Trainer AddTrainer(Trainer trainer)
        {
            return DAL.AddTrainer(trainer);
        }

        [HttpDelete("{id}")]
        public void DeleteTrainer(int id)
        {
            DAL.Delete(id);
        }

        [HttpPut]
        public void Update(Trainer trainer)
        {
            DAL.Update(trainer);
        }
    }
}
