using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Models
{
    public class PageEstimationRequest
    {
        public string FilePath { get; set; }
        public double FontSize { get; set; }
        public double PageWidth { get; set; }
        public double PageHeight { get; set; }
        public int HeaderFooterWords { get; set; }
    }
}
