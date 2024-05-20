using PaginationEstimator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Services.Interfaces
{
    public interface IPageEstimator
    {
        Task<PageEstimationResponse> GetEstimatePageCount(PageEstimationRequest request);
    }
}
