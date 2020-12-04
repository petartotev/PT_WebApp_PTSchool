using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly IParentService parentService;

        public ParentsController(IParentService parentService)
        {
            this.parentService = parentService;
        }

        [HttpGet]
        [Route("api/Parents")]
        public async Task<IActionResult> Get([FromQuery] int page = 1)
        {
            var playlists = await this.parentService.GetAllParentsLightByPageAsync(page);

            return Ok(playlists);
        }

        [HttpGet]
        [Route("api/Parents/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var playlist = await this.parentService.GetParentFullByIdAsync(id);

            return Ok(playlist);
        }
    }
}
