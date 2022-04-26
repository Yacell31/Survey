using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Controllers.Interfaces
{
    public interface IElementController
    {
        IActionResult GetElementsByCategory(int IdCategory);
    }
}
