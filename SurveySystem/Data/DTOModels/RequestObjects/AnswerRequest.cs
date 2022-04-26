using SurveySystem.Data.DTOModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Data.DTOModels.RequestObjects
{
    public class AnswerRequest: RequestAbstractBase
    {
        public string Element { get; set; } = string.Empty;
        public int ParentId { get; set; } = 0;
        public string ElementType { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public bool? IsActive { get; set; } = true;
    }
}
