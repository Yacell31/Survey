using Microsoft.AspNetCore.Mvc;
using SurveySystem.Data.DTOModels.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Controllers.Interfaces
{
    public interface IAnswerController
    {
        IActionResult SaveAnswers(IReadOnlyList<AnswerRequest> answerList);
    }
}
