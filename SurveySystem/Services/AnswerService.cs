using SurveySystem.Common.Constants;
using SurveySystem.Common.Exceptions;
using SurveySystem.Data.DTOModels.RequestObjects;
using SurveySystem.Repositories.Interfaces;
using SurveySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Services
{
    public class AnswerService : IAnswerService
    {

        private IAnswerRepository answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            this.answerRepository = answerRepository;
        }
        public void SaveAnswers(IReadOnlyList<AnswerRequest> answerList)
        {
            try
            {
               // answerList = answerList.Where(x => x.ElementType==Constants.ElementAnswerType).ToList();
                this.answerRepository.AddAnswers(answerList);
            }
            catch (Exception ex)
            {
                throw new SaveAnswersException(ex);

            }
        }
    }
}
