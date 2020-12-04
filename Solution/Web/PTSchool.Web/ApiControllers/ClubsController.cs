using Microsoft.AspNetCore.Mvc;
using PTSchool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Web.ApiControllers
{
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private IClubService clubService;

        public ClubsController(IClubService clubService)
        {
            this.clubService = clubService;
        }

        [HttpGet]
        [Route("api/Clubs")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1)
        {
            var clubs = await this.clubService.GetAllClubsLightByPageAsync(page);

            return Ok(clubs);
        }

        [HttpGet]
        [Route("api/Clubs/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var club = await this.clubService.GetClubFullByIdAsync(id);

            return Ok(club);
        }
    }
}
