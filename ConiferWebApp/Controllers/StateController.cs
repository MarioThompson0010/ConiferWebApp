using ConiferWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConiferWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository myStatesRepository;

        public StateController(IStateRepository context)
        {
            this.myStatesRepository = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMyStates()
        {
            var temp = await myStatesRepository.GetMyStates();
            return Ok(temp);
        }
    }
}
