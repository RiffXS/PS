using System;

namespace DesignPatterns.StructuralPatterns
{
  public interface INotification
  {
    void Send(string message);
  }

  public class BaseNotification : INotification
  {
    public void Send(string message)
    {
      Console.WriteLine($"Base: {message}");
    }
  }

  public class EmailDecorator : INotification
  {
    private readonly INotification _notification;

    public EmailDecorator(INotification notification)
    {
      _notification = notification;
    }

    public void Send(string message)
    {
      _notification.Send(message);
      Console.WriteLine($"E-mail: {message}");
    }
  }

  public class SMSDecorator : INotification
  {
    private readonly INotification _notification;

    public SMSDecorator(INotification notification)
    {
      _notification = notification;
    }

    public void Send(string message)
    {
      _notification.Send(message);
      Console.WriteLine($"SMS: {message}");
    }
  }

  public class PushDecorator : INotification
  {
    private readonly INotification _notification;

    public PushDecorator(INotification notification)
    {
      _notification = notification;
    }

    public void Send(string message)
    {
      _notification.Send(message);
      Console.WriteLine($"Push: {message}");
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      // Notificação apenas por e-mail
      INotification emailOnly = new EmailDecorator(new BaseNotification());
      emailOnly.Send("Promoção especial!");

      Console.WriteLine("\n---\n");

      // Notificação por e-mail + SMS
      INotification emailSms = new SMSDecorator(new EmailDecorator(new BaseNotification()));
      emailSms.Send("Seu pedido foi enviado!");

      Console.WriteLine("\n---\n");

      // Notificação por e-mail + SMS + Push
      INotification fullNotify = new PushDecorator(new SMSDecorator(new EmailDecorator(new BaseNotification())));
      fullNotify.Send("Você recebeu uma nova mensagem!");
    }
  }
}
