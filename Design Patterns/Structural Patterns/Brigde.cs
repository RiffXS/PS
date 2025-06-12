using System;

namespace DesignPatterns.StructuralPatterns
{
  public interface IColor
  {
    void ApplyColor();
  }

  public class RedColor : IColor
  {
    public void ApplyColor()
    {
      Console.Write("vermelho\n");
    }
  }

  public class BlueColor : IColor
  {
    public void ApplyColor()
    {
      Console.Write("azul\n");
    }
  }

  public abstract class Shape
  {
    protected IColor color;

    public Shape(IColor color)
    {
      this.color = color;
    }

    public abstract void Draw();
  }

  public class Circle : Shape
  {
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
      Console.Write("Círculo ");
      color.ApplyColor();
    }
  }

  public class Square : Shape
  {
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
      Console.Write("Quadrado ");
      color.ApplyColor();
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      IColor red = new RedColor();
      IColor blue = new BlueColor();

      Shape redCircle = new Circle(red);
      Shape blueSquare = new Square(blue);
      Shape blueCircle = new Circle(blue);
      Shape redSquare = new Square(red);

      Console.WriteLine("Combinações de formas e cores:");
      redCircle.Draw();
      blueSquare.Draw();
      blueCircle.Draw();
      redSquare.Draw();
    }
  }
}
