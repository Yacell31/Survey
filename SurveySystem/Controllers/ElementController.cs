using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Controllers.Interfaces;
using SurveySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase, IElementController
    {
        private readonly IElementService elementService;

        public ElementController(IElementService elementService)
        {
            this.elementService = elementService;
        }

        private const string GET_ELEMENTS_REST = "get-elements";

        [HttpGet]
        [Route(GET_ELEMENTS_REST)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetElementsByCategory(int IdCategory)
        {
            try
            {
                return new JsonResult(this.elementService.getElementsByCategory(IdCategory));
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
