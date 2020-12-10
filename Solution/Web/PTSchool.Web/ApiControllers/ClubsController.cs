using Microsoft.AspNetCore.Mvc;
using PTSchool.Services.Contracts;
using PTSchool.Services.Models.Club;
using System;
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
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isClubDeleted = await this.clubService.DeleteClubByIdAsync(id);

            if (!isClubDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/Clubs/{id}")]
        public async Task<IActionResult> Put([FromBody] ClubFullServiceModel club)
        {
            var clubUpdated = await this.clubService.UpdateClubAsync(club);

            return Ok(clubUpdated);
        }

        [HttpPost]
        [Route("api/Clubs")]
        public async Task<IActionResult> Post([FromBody] ClubFullServiceModel club)
        {
            var clubCreated = await this.clubService.CreateClubAsync(club);

            return Ok(clubCreated);
        }
    }
}
