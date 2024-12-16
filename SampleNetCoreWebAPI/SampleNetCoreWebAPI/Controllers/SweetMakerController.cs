using Microsoft.AspNetCore.Mvc;
using SampleNetCoreWebAPI.Business.Class;
using SampleNetCoreWebAPI.Business.Interface;
using SampleNetCoreWebAPI.Model;

namespace SampleNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetMakerController : ControllerBase
    { 
        private readonly ILogger<SweetMakerController> _logger;
        private readonly ISweetMakerBL _sweetMakerBL;

        public SweetMakerController(ILogger<SweetMakerController> logger, ISweetMakerBL sweetMakerBL)
        {
            _logger = logger;
            _sweetMakerBL = sweetMakerBL;
        }

        [HttpPost(Name = "calculate-max-sweets")]
        public SweetCount CalculateMaxSweets(Ingredient ingredient)
        {
            return _sweetMakerBL.CalculateMaxSweets(ingredient);
        }
    }
}