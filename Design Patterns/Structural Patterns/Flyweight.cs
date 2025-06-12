using System;

using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
  public class TreeType
  {
    public string Name { get; }
    public string Color { get; }
    public string Texture { get; }

    public TreeType(string name, string color, string texture)
    {
      Name = name;
      Color = color;
      Texture = texture;
    }

    public void Display(int x, int y)
    {
      Console.WriteLine($"Desenhando árvore '{Name}' na posição ({x}, {y}) com cor {Color} e textura '{Texture}'");
    }
  }

  public class TreeFactory
  {
    private static Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
      string key = $"{name}_{color}_{texture}";

      if (!_treeTypes.ContainsKey(key))
      {
        _treeTypes[key] = new TreeType(name, color, texture);
      }

      return _treeTypes[key];
    }
  }

  public class Tree
  {
    private int _x;
    private int _y;
    private TreeType _type;

    public Tree(int x, int y, TreeType type)
    {
      _x = x;
      _y = y;
      _type = type;
    }

    public void Display()
    {
      _type.Display(_x, _y);
    }
  }
  public class Program
  {
    public static void Main(string[] args)
    {
      List<Tree> forest = new List<Tree>();

      TreeType oakType = TreeFactory.GetTreeType("Carvalho", "Verde", "TexturaCarvalho.png");
      TreeType pineType = TreeFactory.GetTreeType("Pinheiro", "VerdeEscuro", "TexturaPinheiro.png");

      forest.Add(new Tree(10, 20, oakType));
      forest.Add(new Tree(15, 25, oakType));
      forest.Add(new Tree(50, 80, pineType));
      forest.Add(new Tree(60, 90, pineType));
      forest.Add(new Tree(100, 200, oakType));

      Console.WriteLine("Renderizando floresta com árvores compartilhadas:\n");
      foreach (var tree in forest)
      {
        tree.Display();
      }
    }
  }
}
