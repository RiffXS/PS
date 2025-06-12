using System;

namespace DesignPattern.BehavioralPattern
{
  public class Player
  {
    public int Position { get; set; }
    public int Health { get; set; }

    public PlayerMemento SaveState()
    {
      return new PlayerMemento(Position, Health);
    }

    // Restaura o estado salvo
    public void RestoreState(PlayerMemento memento)
    {
      Position = memento.Position;
      Health = memento.Health;
    }
  }

  public class PlayerMemento
  {
    public int Position { get; }
    public int Health { get; }

    public PlayerMemento(int position, int health)
    {
      Position = position;
      Health = health;
    }
  }

  public class Caretaker
  {
    private PlayerMemento _memento;

    public void Save(PlayerMemento memento)
    {
      _memento = memento;
    }

    public void Restore(Player player)
    {
      if (_memento != null)
      {
        player.RestoreState(_memento);
      }
    }
  }

  public class Program
  {
    public static void Main()
    {
      var player = new Player();
      player.Position = 5;
      player.Health = 100;

      var caretaker = new Caretaker();
      caretaker.Save(player.SaveState());

      player.Position = 10;

      caretaker.Restore(player);
      Console.WriteLine(player.Position);
    }
  }
}
