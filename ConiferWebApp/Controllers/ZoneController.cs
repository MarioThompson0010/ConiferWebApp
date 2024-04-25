using ConiferWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
namespace ConiferWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository myClientRepository;

        public ZoneController(IZoneRepository context)
        {
            this.myClientRepository = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMyZone()
        {
            var temp = await myClientRepository.GetMyZones();// GetMyClientSp(email);
            return Ok(temp);
        }
    }


}
