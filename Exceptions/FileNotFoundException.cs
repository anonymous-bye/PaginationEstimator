using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Exceptions
{
    public class FileNotFoundException : Exception
    {
        public FileNotFoundException(string path)
         : base(string.Format("File path {0} is not valid.", path))
        {

        }
    }
}
