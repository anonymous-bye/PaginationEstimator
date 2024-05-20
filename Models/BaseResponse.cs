using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Models
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            ErrorMessage = string.Empty;
        }
        public string ErrorMessage { get; set; }
        public bool Success
        {
            get
            {
                return ErrorMessage == string.Empty;
            }
        }
    }
}
