using Microservices.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Microservices.Api.Controllers
{

    [Route("[controller]")]
    //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;

        /// <summary>
        /// NOTE!!! It would be better to have some ApplicationService interface which is expose necessary actions with IActivityRepository.
        /// </summary>
        //private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IBusClient busClient /*IActivityRepository activityRepository*/)
        {
            _busClient = busClient;
            // _activityRepository = activityRepository;
        }

        //[HttpGet("")]
        //public async Task<IActionResult> Get()
        //{
        //    var activities = await _activityRepository.BrowseAsync(Guid.Parse(User.Identity.Name));

        //    return Json(activities.Select(x => new { x.Id, x.Name, x.Category, x.CreatedAt }));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var activity = await _activityRepository.GetAsync(id);
        //    if (activity == null)
        //    {
        //        return NotFound();
        //    }
        //    if (activity.UserId != Guid.Parse(User.Identity.Name))
        //    {
        //        return Unauthorized();
        //    }
        //    return Json(activity);
        //}

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            // command.UserId = Guid.Parse(User.Identity.Name);

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}
