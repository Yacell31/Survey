using SurveySystem.Data.DTOModels.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Repositories.Interfaces
{
    public interface IAnswerRepository
    {
      public void AddAnswers(IReadOnlyList<AnswerRequest> answerList);
    }
}
