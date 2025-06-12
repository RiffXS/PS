using System;

using System.Collections;
using System.Collections.Generic;

namespace DesignPattern.BehavioralPattern
{
  public class Playlist : IEnumerable<string>
  {
    private List<string> _songs = new List<string>();
    private bool _shuffle = false;
    private Random _random = new Random();

    public void Add(string song)
    {
      _songs.Add(song);
    }

    public void SetShuffle(bool shuffle)
    {
      _shuffle = shuffle;
    }

    public IEnumerator<string> GetEnumerator()
    {
      if (_shuffle)
      {
        var shuffled = new List<string>(_songs);
        int n = shuffled.Count;
        while (n > 1)
        {
          n--;
          int k = _random.Next(n + 1);
          (shuffled[k], shuffled[n]) = (shuffled[n], shuffled[k]);
        }

        foreach (var song in shuffled)
          yield return song;
      }
      else
      {
        foreach (var song in _songs)
          yield return song;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }

  public class Program
  {
    public static void Main()
    {
      var playlist = new Playlist();
      playlist.Add("Song 1");
      playlist.Add("Song 2");
      playlist.Add("Song 3");

      Console.WriteLine("🎵 Modo ordenado:");
      playlist.SetShuffle(false);
      foreach (var song in playlist)
      {
        Console.WriteLine(song);
      }

      Console.WriteLine("\n🔀 Modo aleatório:");
      playlist.SetShuffle(true);
      foreach (var song in playlist)
      {
        Console.WriteLine(song);
      }
    }
  }
}
