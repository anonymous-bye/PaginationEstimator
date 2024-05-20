using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Exceptions
{
    public class InValidParameterException : Exception
    {
        public InValidParameterException(string parameter)
          : base(string.Format("Parameter {0} is not valid.", parameter))
        {

        }
    }
}
