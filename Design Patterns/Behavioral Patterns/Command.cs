using System;

using System.Collections.Generic;

namespace DesignPattern.BehavioralPattern
{
  public interface ICommand
  {
    void Execute();
    void Undo();
  }

  public class TextEditor
  {
    public string Text { get; private set; } = "";

    public void Write(string newText)
    {
      Text += newText;
    }

    public void Delete(int length)
    {
      if (length <= Text.Length)
      {
        Text = Text.Substring(0, Text.Length - length);
      }
    }

    public void Print()
    {
      Console.WriteLine(Text);
    }
  }

  public class WriteTextCommand : ICommand
  {
    private readonly TextEditor _editor;
    private readonly string _text;

    public WriteTextCommand(TextEditor editor, string text)
    {
      _editor = editor;
      _text = text;
    }

    public void Execute()
    {
      _editor.Write(_text);
    }

    public void Undo()
    {
      _editor.Delete(_text.Length);
    }
  }

  public class CommandManager
  {
    private Stack<ICommand> _undoStack = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
      command.Execute();
      _undoStack.Push(command);
      _redoStack.Clear();
    }

    public void Undo()
    {
      if (_undoStack.Count > 0)
      {
        var command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
      }
    }

    public void Redo()
    {
      if (_redoStack.Count > 0)
      {
        var command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
      }
    }
  }

  public class Program
  {
    public static void Main(string[] args)
    {
      var editor = new TextEditor();
      var commandManager = new CommandManager();

      commandManager.ExecuteCommand(new WriteTextCommand(editor, "Hello, "));
      commandManager.ExecuteCommand(new WriteTextCommand(editor, "world!"));

      commandManager.Undo();
      commandManager.Undo();
      commandManager.Redo();

      editor.Print();
    }
  }
}
