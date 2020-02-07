using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wiprobackend.Services;
using Wiprobackend.DtoModels;

namespace Wiprobackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] TrainingDto trainingDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Data Model Error!");
            }
            try
            {
                int trainingDays =  _trainingService.AddTraining(trainingDto);
                return StatusCode(StatusCodes.Status201Created, trainingDays);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}