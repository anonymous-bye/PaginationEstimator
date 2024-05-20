using PaginationEstimator;
using PaginationEstimator.Models;
using PaginationEstimator.Services;
using System;
using System.Reflection.Metadata;

public class Program
{
    static async Task Main()
    {
        Console.Write("Input source path:");
        string filePath = Console.ReadLine();
        InputValidators.ValidateFilePathParameter(filePath);

        Console.Write("Font size:");
        string fontSizeStr = Console.ReadLine();
        double fontSize = InputValidators.ValidateDoubleParameter(fontSizeStr);
        
        Console.Write("Page Width:");
        string pageWidthStr = Console.ReadLine();
        double pageWidth = InputValidators.ValidateDoubleParameter(pageWidthStr);
        
        Console.Write("Page Height:");
        string pageHeightStr = Console.ReadLine();
        double pageHeight = InputValidators.ValidateDoubleParameter(pageHeightStr);
        
        Console.Write("Header & Footer Word Count:");
        string headerAndFooterWordsCountStr = Console.ReadLine();
        int headerAndFooterWordsCount = InputValidators.ValidateIntParameter(headerAndFooterWordsCountStr);

        IPageEstimator estimator = new PageEstimator();
        int totalPages = await estimator.GetEstimatePageCount(new PageEstimationRequest {
            FilePath = filePath,
            FontSize = fontSize,
            PageWidth = pageWidth,
            PageHeight = pageHeight,
            HeaderFooterWords = headerAndFooterWordsCount
        });
        Console.WriteLine($"=> Estimated pages: {totalPages}");
    }
}
