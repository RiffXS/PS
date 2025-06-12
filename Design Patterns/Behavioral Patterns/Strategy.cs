using System;

namespace DesignPattern.BehavioralPattern
{
  public interface IShippingStrategy
  {
    decimal Calculate(decimal distance);
  }

  public class EconomyShipping : IShippingStrategy
  {
    public decimal Calculate(decimal distance)
    {
      return distance * 0.10m; // 10% do valor
    }
  }

  public class ExpressShipping : IShippingStrategy
  {
    public decimal Calculate(decimal distance)
    {
      return distance * 0.25m; // 25% do valor
    }
  }

  public class LocalShipping : IShippingStrategy
  {
    public decimal Calculate(decimal distance)
    {
      return 5.00m; // Frete fixo para entregas locais
    }
  }

  public class ShippingCalculator
  {
    private IShippingStrategy _strategy;

    public ShippingCalculator(IShippingStrategy strategy)
    {
      _strategy = strategy;
    }

    public void SetStrategy(IShippingStrategy strategy)
    {
      _strategy = strategy;
    }

    public decimal Calculate(decimal distance)
    {
      return _strategy.Calculate(distance);
    }
  }

  public class Program
  {
    public static void Main()
    {
      var calculator = new ShippingCalculator(new EconomyShipping());
      Console.WriteLine(calculator.Calculate(100)); // Saída: 10

      calculator.SetStrategy(new ExpressShipping());
      Console.WriteLine(calculator.Calculate(100)); // Saída: 25
    }
  }
}
