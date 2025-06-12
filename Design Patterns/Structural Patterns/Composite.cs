using System;

using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
  public interface IMenuComponent
  {
    void Display(int depth = 0);
    void Add(IMenuComponent component);
  }
  public class MenuItem : IMenuComponent
  {
    public string Name { get; }

    public MenuItem(string name)
    {
      Name = name;
    }

    public void Display(int depth = 0)
    {
      Console.WriteLine(new string('-', depth * 2) + Name);
    }

    public void Add(IMenuComponent component)
    {
      Console.WriteLine("Não é possível adicionar a um item de menu.");
    }
  }

  public class Menu : IMenuComponent
  {
    public string Title { get; }
    public List<IMenuComponent> _components = new List<IMenuComponent>();

    public Menu(string title)
    {
      Title = title;
    }

    public void Add(IMenuComponent component)
    {
      _components.Add(component);
    }

    public void Display(int depth = 0)
    {
      Console.WriteLine(new string('-', depth * 2) + $"Menu {Title}");

      foreach (var component in _components) {
        component.Display(depth + 1);
      }
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      MenuItem arroz = new MenuItem("Arroz");
      MenuItem feijao = new MenuItem("Feijão");
      MenuItem bife = new MenuItem("Bife");
      MenuItem suco = new MenuItem("Suco de Laranja");
      MenuItem sobremesa = new MenuItem("Pudim");

      Menu almocoExecutivo = new Menu("Almoço Executivo");
      almocoExecutivo.Add(arroz);
      almocoExecutivo.Add(feijao);
      almocoExecutivo.Add(bife);
      almocoExecutivo.Add(suco);

      Menu sobremesas = new Menu("Sobremesas");
      sobremesas.Add(sobremesa);

      Menu menuPrincipal = new Menu("Menu Principal");
      menuPrincipal.Add(almocoExecutivo);
      menuPrincipal.Add(sobremesas);

      Console.WriteLine("Menu completo:");
      menuPrincipal.Display();
    }
  }
}
