using ConiferWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConiferWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository myRegionsRepository;

        public RegionController(IRegionRepository context)
        {
            this.myRegionsRepository = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMyRegions()
        {
            var temp = await myRegionsRepository.GetMyRegions();
            return Ok(temp);
        }
    }
}
