using System;

namespace DesignPattern.BehavioralPattern
{
  public interface IState
  {
    void InsertCoin();
    void SelectProduct();
    void DispenseProduct();
  }

  public class VendingMachine
  {
    private IState _state;

    public readonly IState NoCoinState;
    public readonly IState HasCoinState;
    public readonly IState SoldState;

    public VendingMachine()
    {
      NoCoinState = new NoCoinState(this);
      HasCoinState = new HasCoinState(this);
      SoldState = new SoldState(this);

      _state = NoCoinState; // Estado inicial
    }

    public void SetState(IState state)
    {
      _state = state;
    }

    public void InsertCoin() => _state.InsertCoin();
    public void SelectProduct() => _state.SelectProduct();
    public void DispenseProduct() => _state.DispenseProduct();
  }

  public class NoCoinState : IState
  {
    private readonly VendingMachine _machine;

    public NoCoinState(VendingMachine machine)
    {
      _machine = machine;
    }

    public void InsertCoin()
    {
      Console.WriteLine("Coin inserted.");
      _machine.SetState(_machine.HasCoinState);
    }

    public void SelectProduct()
    {
      Console.WriteLine("Insert coin first.");
    }

    public void DispenseProduct()
    {
      Console.WriteLine("Insert coin and select product first.");
    }
  }

  public class HasCoinState : IState
  {
    private readonly VendingMachine _machine;

    public HasCoinState(VendingMachine machine)
    {
      _machine = machine;
    }

    public void InsertCoin()
    {
      Console.WriteLine("Coin already inserted.");
    }

    public void SelectProduct()
    {
      Console.WriteLine("Product selected.");
      _machine.SetState(_machine.SoldState);
    }

    public void DispenseProduct()
    {
      Console.WriteLine("Select product first.");
    }
  }

  public class SoldState : IState
  {
    private readonly VendingMachine _machine;

    public SoldState(VendingMachine machine)
    {
      _machine = machine;
    }

    public void InsertCoin()
    {
      Console.WriteLine("Wait, dispensing in progress.");
    }

    public void SelectProduct()
    {
      Console.WriteLine("Already selected.");
    }

    public void DispenseProduct()
    {
      Console.WriteLine("Product dispensed.");
      _machine.SetState(_machine.NoCoinState);
    }
  }

  public class Program
  {
    public static void Main()
    {
      var vendingMachine = new VendingMachine();

      vendingMachine.InsertCoin();
      vendingMachine.SelectProduct();
      vendingMachine.DispenseProduct();
    }
}
}
