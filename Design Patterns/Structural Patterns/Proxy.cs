using System;

namespace DesignPatterns.StructuralPatterns
{
  public interface IImage
  {
    void Display();
  }

  public class RealImage : IImage
  {
    private string _filename;

    public RealImage(string filename)
    {
      _filename = filename;
      LoadFromDisk();
    }

    private void LoadFromDisk()
    {
      Console.WriteLine($"Carregando imagem '{_filename}' do disco...");
    }

    public void Display()
    {
      Console.WriteLine($"Exibindo imagem '{_filename}'.");
    }
  }

  public class ProxyImage : IImage
  {
    private string _filename;
    private RealImage _realImage;

    public ProxyImage(string filename)
    {
      _filename = filename;
    }

    public void Display()
    {
      if (_realImage == null)
      {
        _realImage = new RealImage(_filename);
      }
      _realImage.Display();
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      IImage image1 = new ProxyImage("foto1.jpg");
      IImage image2 = new ProxyImage("foto2.jpg");

      Console.WriteLine("As imagens foram criadas, mas ainda não carregadas.\n");

      Console.WriteLine("Agora exibindo a imagem 1:");
      image1.Display();

      Console.WriteLine("\nExibindo a imagem 1 novamente:");
      image1.Display();

      Console.WriteLine("\nExibindo a imagem 2:");
      image2.Display();
    }
  }
}
