using SurveySystem.Common.Exceptions;
using SurveySystem.Data.DTOModels.ResponseObjects;
using SurveySystem.Repositories.Interfaces;
using SurveySystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Services
{
    public class ElementService : IElementService
    {

        private IElementRepository elementRepository;

        public ElementService(IElementRepository elementRepository)
        {
            this.elementRepository = elementRepository;
        }
        public IReadOnlyList<ElementResponse> getElementsByCategory(int IdCategory)
        {
            IReadOnlyList<ElementResponse> result = null;
            try
            {
                result = this.elementRepository.getElementsByCategory(IdCategory);
            }
            catch (Exception ex)
            {
               // log.Error(ex.Message);
                throw new GetElementsException(ex);
            }

            return result;
        }
    }
}
