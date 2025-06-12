using System;

namespace DesignPattern.BehavioralPattern
{
  public interface IExpression
  {
    int Interpret();
  }

  public class NumberExpression : IExpression
  {
    private readonly int _number;

    public NumberExpression(int number)
    {
      _number = number;
    }

    public int Interpret()
    {
      return _number;
    }
  }

  public class AddExpression : IExpression
  {
    private readonly IExpression _left;
    private readonly IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
      _left = left;
      _right = right;
    }

    public int Interpret()
    {
      return _left.Interpret() + _right.Interpret();
    }
  }

  public class SubtractExpression : IExpression
  {
    private readonly IExpression _left;
    private readonly IExpression _right;

    public SubtractExpression(IExpression left, IExpression right)
    {
      _left = left;
      _right = right;
    }

    public int Interpret()
    {
      return _left.Interpret() - _right.Interpret();
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      IExpression expression = new AddExpression(
        new NumberExpression(5),
        new SubtractExpression(
          new NumberExpression(10),
          new NumberExpression(3)
        )
      );

      Console.WriteLine(expression.Interpret());
    }
  }
}
