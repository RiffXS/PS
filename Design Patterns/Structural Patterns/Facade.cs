using System;

namespace DesignPatterns.StructuralPatterns
{
  public class DvdPlayer
  {
    public void On() => Console.WriteLine("DVD Player ligado.");
    public void Play(string movie) => Console.WriteLine($"Reproduzindo filme: {movie}");
    public void Off() => Console.WriteLine("DVD Player desligado.");
  }

  public class Projector
  {
    public void On() => Console.WriteLine("Projetor ligado.");
    public void Off() => Console.WriteLine("Projetor desligado.");
  }

  public class Lights
  {
    public void Dim() => Console.WriteLine("Luzes em modo cinema.");
    public void On() => Console.WriteLine("Luzes acesas.");
  }

  public class SoundSystem
  {
    public void On() => Console.WriteLine("Som ligado.");
    public void SetVolume(int level) => Console.WriteLine($"Volume em: {level}");
    public void Off() => Console.WriteLine("Som desligado.");
  }

  public class HomeTheaterFacade
  {
    private readonly DvdPlayer _dvdPlayer;
    private readonly Projector _projector;
    private readonly Lights _lights;
    private readonly SoundSystem _soundSystem;

    public HomeTheaterFacade(DvdPlayer dvd, Projector projector, Lights lights, SoundSystem soundSystem)
    {
      _dvdPlayer = dvd;
      _projector = projector;
      _lights = lights;
      _soundSystem = soundSystem;
    }

    public void PlayMovie(string movie)
    {
      Console.WriteLine("\nIniciando filme...\n");

      _lights.Dim();
      _projector.On();
      _soundSystem.On();
      _soundSystem.SetVolume(15);
      _dvdPlayer.On();
      _dvdPlayer.Play(movie);

      Console.WriteLine("\nFilme em reprodução!\n");
    }

    public void EndMovie()
    {
      Console.WriteLine("\nEncerrando filme...\n");

      _dvdPlayer.Off();
      _soundSystem.Off();
      _projector.Off();
      _lights.On();

      Console.WriteLine("\nSessão encerrada.\n");
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      var dvd = new DvdPlayer();
      var projector = new Projector();
      var lights = new Lights();
      var sound = new SoundSystem();

      var homeTheater = new HomeTheaterFacade(dvd, projector, lights, sound);

      homeTheater.PlayMovie("Matrix");
      homeTheater.EndMovie();
    }
  }
}
