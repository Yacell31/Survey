using SurveySystem.Data.DTOModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Repositories.Interfaces
{
    public interface IElementRepository
    {
        public IReadOnlyList<ElementResponse> getElementsByCategory(int IdCategory);
    }
}
