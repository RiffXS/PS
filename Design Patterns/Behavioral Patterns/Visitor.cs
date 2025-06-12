using System;

namespace DesignPattern.BehavioralPattern
{
  public interface IVisitor
  {
    void Visit(ElementA elementA);
    void Visit(ElementB elementB);
  }

  public interface IElement
  {
    void Accept(IVisitor visitor);
  }

  public class ElementA : IElement
  {
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
  }

  public class ElementB : IElement
  {
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
  }

  public class ValidationVisitor : IVisitor
  {
    public void Visit(ElementA elementA)
    {
      Console.WriteLine("Validating ElementA...");
    }

    public void Visit(ElementB elementB)
    {
      Console.WriteLine("Validating ElementB...");
    }
  }

  public class Program
  {
    public static void Main()
    {
      var visitor = new ValidationVisitor();
      var elementA = new ElementA();
      var elementB = new ElementB();

      elementA.Accept(visitor);
      elementB.Accept(visitor);
    }
  }
}
