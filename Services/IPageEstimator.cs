using PaginationEstimator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Services
{
    public interface IPageEstimator
    {
        Task<int> GetEstimatePageCount(PageEstimationRequest request);
    }
}
