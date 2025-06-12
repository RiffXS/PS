using System;

namespace DesignPattern.BehavioralPattern
{
  public abstract class ReportGenerator
  {
    public void GenerateReport()
    {
      GenerateHeader();
      GenerateContent();
      Export();
    }

    protected virtual void GenerateHeader()
    {
      Console.WriteLine("Generating report header...");
    }

    protected virtual void GenerateContent()
    {
      Console.WriteLine("Generating report content...");
    }

    protected abstract void Export(); // Passo que será sobrescrito nas subclasses
  }

  public class PdfReportGenerator : ReportGenerator
  {
    protected override void Export()
    {
        Console.WriteLine("Exporting to PDF...");
    }
  }

  public class ExcelReportGenerator : ReportGenerator
  {
    protected override void Export()
    {
        Console.WriteLine("Exporting to Excel...");
    }
  }

  public class Program
  {
    public static void Main()
    {
      var pdfReport = new PdfReportGenerator();
      pdfReport.GenerateReport();

      Console.WriteLine();

      var excelReport = new ExcelReportGenerator();
      excelReport.GenerateReport();
    }
  }
}
