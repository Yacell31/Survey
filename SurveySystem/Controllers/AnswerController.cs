using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Controllers.Interfaces;
using SurveySystem.Data.DTOModels.RequestObjects;
using SurveySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase, IAnswerController
    {
        private readonly IAnswerService answerService;
        private const string CREATE_ANSWERS_REST = "create-answers";

        public AnswerController(IAnswerService answerService)
        {
            this.answerService = answerService;
        }



        [HttpPost]
        [Route(CREATE_ANSWERS_REST)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult SaveAnswers([FromBody] IReadOnlyList<AnswerRequest> request)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            try
            {              
               this.answerService.SaveAnswers(request);
                return this.Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
