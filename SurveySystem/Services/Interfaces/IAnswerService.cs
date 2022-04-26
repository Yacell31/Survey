using SurveySystem.Data.DTOModels.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Services.Interfaces
{
    public interface IAnswerService
    {
        void SaveAnswers(IReadOnlyList<AnswerRequest> answerList);
    }
}
