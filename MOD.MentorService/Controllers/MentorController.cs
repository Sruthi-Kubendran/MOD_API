using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.DtosLibrary;
using MOD.MentorLibrary.Repositories;

namespace MOD.MentorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MentorController : ControllerBase
    {
        IMentorRepository mentorRepository;
        public MentorController(IMentorRepository mentorRepository)
        {
            this.mentorRepository = mentorRepository;
        }



        [HttpPut("acceptrequest/{id}")]
        public IActionResult PutAcceptRequest(int id)
        {
            mentorRepository.PutAcceptRequest(id);
            return Ok();
        }

        [HttpPut("rejectrequest/{id}")]
        public IActionResult PutRejectrequest(int id)
        {
            mentorRepository.PutRejectrequest(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid && id == userProfileDto.Id)
            {
                bool result = mentorRepository.UpdateUser(id, userProfileDto);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest(ModelState);

        }
    }
}