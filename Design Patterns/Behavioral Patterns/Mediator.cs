using System;

using System.Collections.Generic;

namespace DesignPattern.BehavioralPattern
{
  public interface IMediator
  {
    void SendMessage(string message, User sender);
    void RegisterUser(User user);
  }

  public class User
  {
    public string Name { get; }
    private IMediator _mediator;

    public User(string name, IMediator mediator)
    {
      Name = name;
      _mediator = mediator;
      _mediator.RegisterUser(this);
    }

    public void SendMessage(string message)
    {
      _mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message, User sender)
    {
      Console.WriteLine($"{sender.Name} to {Name}: {message}");
    }
  }

  public class ChatMediator : IMediator
  {
    private List<User> _users = new List<User>();

    public void RegisterUser(User user)
    {
      if (!_users.Contains(user))
      {
        _users.Add(user);
      }
    }

    public void SendMessage(string message, User sender)
    {
      foreach (var user in _users)
      {
        if (user != sender)
        {
          user.ReceiveMessage(message, sender);
        }
      }
    }
  }

  public class Program
  {
    public static void Main()
    {
      var mediator = new ChatMediator();

      var user1 = new User("Alice", mediator);
      var user2 = new User("Bob", mediator);

      user1.SendMessage("Hello, Bob!");
      user2.SendMessage("Hi, Alice!");
    }
  }
}
