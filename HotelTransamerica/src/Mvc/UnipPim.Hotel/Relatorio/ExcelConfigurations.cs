using System.IO;

namespace UnipPim.Hotel.Relatorio
{
    public static class ExcelConfigurations
    {
        public static string SpreadsheetTemplate = Path.Combine(Directory.GetCurrentDirectory(), "Relatorio/Planilha.xlsx");
        public static string GenerationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ReportSheets_Temp/");
    }
}
