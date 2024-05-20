using PaginationEstimator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNotFoundException = PaginationEstimator.Exceptions.FileNotFoundException;

namespace PaginationEstimator
{
    public static class InputValidators
    {
        public static void ValidateFilePathParameter(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
        }
        public static double ValidateDoubleParameter(string parameter)
        {
            double result = 0;
            if (!double.TryParse(parameter, out result) || result <= 0)
            {
                throw new InValidParameterException(parameter);
            }
            return result;
        }
        public static int ValidateIntParameter(string parameter)
        {
            int result = 0;
            if (!int.TryParse(parameter, out result) || result <= 0)
            {
                throw new InValidParameterException(parameter);
            }
            return result;
        }
    }
}
