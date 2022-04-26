using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveySystem.Common.Exceptions
{
    public class GetElementsException : Exception
    {
        public GetElementsException(Exception e) : base(string.Empty, e)
        {
        }
    }
}
