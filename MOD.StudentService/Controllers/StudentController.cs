using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.DtosLibrary;
using MOD.ModelLibrary;
using MOD.StudentLibrary.Repositories;

namespace MOD.StudentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        IStudentRepository studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpPost("training")]
        public IActionResult PostTraining([FromBody] TrainingDtls training)
        {
            if (ModelState.IsValid)
            {
                bool result = studentRepository.AddTraining(training);
                return Created("AddTraining", training);
            }
            return BadRequest(ModelState);
        }


        [HttpPost("payment")]
        public IActionResult PostPayment([FromBody] PaymentDtls payment)
        {
            if (ModelState.IsValid)
            {
                bool result = studentRepository.AddPayment(payment);
                return Created("AddPayment", payment);
            }
            return BadRequest(ModelState);
        }


        [HttpGet("searchdata")]
        public IActionResult GetSearchData(string trainertechnology)
        {
            if (trainertechnology != null)
            {
                var result = studentRepository.GetSearchData(trainertechnology);
                return Ok(result);
            }
            else
            {
                return Ok("Error Fetching Data");
            }
        }


        [HttpPut("updateTrainingProgressById")]
        public IActionResult PutupdateTrainingProgressById(int id, int progressValue)
        {
            studentRepository.PutupdateTrainingProgressById(id, progressValue);
            return Ok();
        }


        [HttpPut("updateTrainingRatingById")]
        public IActionResult PutupdateTrainingRatingById(int id, int rating)
        {
            studentRepository.PutupdateTrainingRatingById(id, rating);
            return Ok();
        }


        [HttpPut("updateTrainingStatusById/{id}")]
        public IActionResult PutupdateTrainingStatusById(int id)
        {
            studentRepository.PutupdateTrainingStatusById(id);
            return Ok();
        }

        [HttpPut("updateTrainingAndPaymentStatusbyId/{id}")]
        public IActionResult PutupdateTrainingAndPaymentStatusbyId(int id)
        {
            studentRepository.PutupdateTrainingAndPaymentStatusbyId(id);
            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid && id == userProfileDto.Id)
            {
                bool result = studentRepository.UpdateUser(id, userProfileDto);
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