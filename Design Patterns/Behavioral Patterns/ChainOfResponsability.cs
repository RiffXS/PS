using System;

namespace DesignPattern.BehavioralPattern
{
  public abstract class DocumentHandler
  {
    protected DocumentHandler _next;

    public DocumentHandler SetNext(DocumentHandler next)
    {
      _next = next;
      return next;
    }

    public void Handle(string documentType)
    {
      if (!Process(documentType) && _next != null)
      {
        _next.Handle(documentType);
      }
      else if (_next == null)
      {
        Console.WriteLine($"Cannot process {documentType}.");
      }
    }

    protected abstract bool Process(string documentType);
  }

  public class InvoiceHandler : DocumentHandler
  {
    protected override bool Process(string documentType)
    {
      if (documentType == "Invoice")
      {
        Console.WriteLine("Processing Invoice...");
        return true;
      }
      return false;
    }
  }

  public class ReceiptHandler : DocumentHandler
  {
    protected override bool Process(string documentType)
    {
      if (documentType == "Receipt")
      {
        Console.WriteLine("Processing Receipt...");
        return true;
      }
      return false;
    }
  }

  public class BillHandler : DocumentHandler
  {
    protected override bool Process(string documentType)
    {
      if (documentType == "Bill")
      {
        Console.WriteLine("Processing Bill...");
        return true;
      }
      return false;
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      var handler = new InvoiceHandler();
      handler.SetNext(new ReceiptHandler()).SetNext(new BillHandler());

      handler.Handle("Invoice");
      handler.Handle("Unknown");
    }
  }
}
