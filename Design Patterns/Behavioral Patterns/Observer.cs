using System;

using System.Collections.Generic;

namespace DesignPattern.BehavioralPattern
{
  public interface IObserver
  {
    void Update(string status);
  }

  public interface ISubject
  {
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
  }

  public class Order : ISubject
  {
    private readonly List<IObserver> _observers = new List<IObserver>();
    private string _status;

    public void Attach(IObserver observer)
    {
      _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
      _observers.Remove(observer);
    }

    public void UpdateStatus(string status)
    {
      _status = status;
      Notify();
    }

    public void Notify()
    {
      foreach (var observer in _observers)
      {
        observer.Update(_status);
      }
    }
  }

  public class EmailNotifier : IObserver
  {
    public void Update(string status)
    {
      Console.WriteLine($"Email: Your order is now {status}.");
    }
  }

  public class SmsNotifier : IObserver
  {
    public void Update(string status)
    {
      Console.WriteLine($"SMS: Your order is now {status}.");
    }
  }

  public class AppNotifier : IObserver
  {
    public void Update(string status)
    {
      Console.WriteLine($"App Notification: Your order is now {status}.");
    }
  }

  public class Program
  {
    public static void Main()
    {
      var order = new Order();

      order.Attach(new EmailNotifier());
      order.Attach(new SmsNotifier());
      // Você pode também adicionar o AppNotifier se quiser:
      // order.Attach(new AppNotifier());

      order.UpdateStatus("Shipped");
    }
  }
}
