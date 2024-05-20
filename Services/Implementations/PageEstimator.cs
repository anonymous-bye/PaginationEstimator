using PaginationEstimator.Models;
using PaginationEstimator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationEstimator.Services.Implementations
{
    public class PageEstimator : IPageEstimator
    {
        public async Task<PageEstimationResponse> GetEstimatePageCount(PageEstimationRequest request)
        {
            var response = new PageEstimationResponse();
            response.PageCount = 0;

            int piecelineCount = 0;
            int wordCountPerLine = (int)Math.Floor(request.PageWidth / request.FontSize);
            int headerLineCount = (int)Math.Ceiling((double)request.HeaderFooterWords / wordCountPerLine);
            int lineCountPerPage = (int)Math.Floor(request.PageHeight / request.FontSize);
            int bodyLinePerPage = lineCountPerPage - headerLineCount;

            using FileStream file = new FileStream(request.FilePath, FileMode.Open);
            using (BufferedStream stream = new BufferedStream(file))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = await reader.ReadLineAsync();
                        piecelineCount += (int)Math.Ceiling((double)line.Count() / wordCountPerLine);
                        response.PageCount += piecelineCount / bodyLinePerPage;
                        piecelineCount = piecelineCount % bodyLinePerPage;
                    }
                }
            }

            if (piecelineCount > 0)
            {
                response.PageCount++;
            }
            return response;
        }
    }
}
