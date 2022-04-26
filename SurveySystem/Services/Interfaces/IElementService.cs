using SurveySystem.Data.DTOModels.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Services.Interfaces
{
    public interface IElementService
    {
       public IReadOnlyList<ElementResponse> getElementsByCategory(int IdCategory);
    }
}
