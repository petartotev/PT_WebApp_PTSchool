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
            var clubsToGet = await this.clubService.GetAllClubsLightByPageAsync(page);

            return Ok(clubsToGet);
        }

        [HttpGet]
        [Route("api/Clubs/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var clubToGet = await this.clubService.GetClubFullByIdAsync(id);

            return Ok(clubToGet);
        }

        [HttpDelete]
        [Route("api/Clubs/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isClubDeleted = await this.clubService.DeleteClubByIdAsync(id);

            if (!isClubDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
