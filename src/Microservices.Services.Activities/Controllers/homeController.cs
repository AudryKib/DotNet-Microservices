﻿namespace Microservices.Services.Activities.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    namespace Actio.Api.Controllers
    {
        [Route("")]
        public class HomeController : Controller
        {
            [HttpGet("")]
            public IActionResult Get() => Content("Hello from Activities API !");
        }
    }
}
