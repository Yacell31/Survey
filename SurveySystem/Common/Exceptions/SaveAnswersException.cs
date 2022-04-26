using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Common.Exceptions
{
    public class SaveAnswersException : Exception
    {
        public SaveAnswersException(Exception e) : base(string.Empty, e)
        {
        }
    }
}
