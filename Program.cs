using System;

class Program
{
    static async Task Main()
    {
        Console.Write("Input source path:");
        string filePath = Console.ReadLine();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No exist source");
            return;
        }
        using FileStream stream = new FileStream(filePath,FileMode.Open);
        Console.Write("Font size:");
        string fontSizeStr = Console.ReadLine();
        double fontSize = 0;
        if(!double.TryParse(fontSizeStr, out fontSize) || fontSize <= 0)
        {
            Console.WriteLine("Invalid Font Size");
            return;
        }
        Console.Write("Page Width:");
        string pageWidthStr = Console.ReadLine();
        double pageWidth = 0;
        if (!double.TryParse(pageWidthStr, out pageWidth) || pageWidth <= 0)
        {
            Console.WriteLine("Invalid Page Width");
            return;
        }
        Console.Write("Page Height:");
        string pageHeightStr = Console.ReadLine();
        double pageHeight = 0;
        if (!double.TryParse(pageHeightStr, out pageHeight) || pageHeight <= 0)
        {
            Console.WriteLine("Invalid Page Height");
            return;
        }
        Console.Write("Header & Footer Word Count:");
        string hafCountStr = Console.ReadLine();
        int hafCount = 0;
        if (!int.TryParse(hafCountStr, out hafCount) || hafCount < 0)
        {
            Console.WriteLine("Invalid Header & Footer Word Count");
            return;
        }
        int totalPages = await GetEstimatePageCount(stream,fontSize,pageWidth,pageHeight,hafCount);
        Console.WriteLine($"=> Estimated pages: {totalPages}");
    }
    public static async Task<int> GetEstimatePageCount(Stream file,double fontSize, double pageWidth, double pageHeight,int headerFooterWords)
    {
        int pageCount = 0;
        int piecelineCount = 0;
        int wordCountPerLine = (int)Math.Floor(pageWidth / fontSize);
        int headerLineCount = (int)Math.Ceiling((double)headerFooterWords / wordCountPerLine);
        int lineCountPerPage = (int)(pageHeight / fontSize);
        int bodyLinePerPage = lineCountPerPage - headerLineCount;
        using(BufferedStream stream = new BufferedStream(file))
        {
            using(StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    piecelineCount += (int)(Math.Ceiling((double)line.Count() / wordCountPerLine));
                    pageCount += piecelineCount / bodyLinePerPage;
                    piecelineCount = piecelineCount % bodyLinePerPage;
                }
            }
        }
        if(piecelineCount > 0)
        {
            pageCount++;
        }
        return pageCount;
    }
}
