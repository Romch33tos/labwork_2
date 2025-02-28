using System;
using System.Collections.Generic;

public class Document
{  
  public string Name { get; set; }
  public string Author { get; set; }
  public string Keywords { get; set; }
  public string Theme { get; set; }
  public string FilePath { get; set; }

  public virtual string GetInfo()
  {
    return $"Название документа: {Name}, Автор: {Author}, Ключевые слова: {Keywords}, Тема: {Theme}, Путь к файлу: {FilePath}";
  }
}

public class WordDocument : Document
{
    public int WordCount { get; set; }

    public override string GetInfo()
    {
      return base.GetInfo() + $", Число слов: {WordCount}";
    }
}

public class PdfDocument : Document
{
  public string PdfVersion { get; set; }

  public override string GetInfo()
  {
    return base.GetInfo() + $", Версия PDF: {PdfVersion}";
  }
}

public class ExcelDocument : Document
{
  public int SheetCount { get; set; }

  public override string GetInfo()
  {
    return base.GetInfo() + $", Число листов: {SheetCount}";
  }
}

public class TxtDocument : Document
{
  public string Title { get; set; }

  public override string GetInfo()
  {
    return base.GetInfo() + $", Заголовок: {Title}";
  }
}

public class HtmlDocument : Document
{
    public string Encoding { get; set; }

    public override string GetInfo()
    {
      return base.GetInfo() + $", Кодировка файла: {Encoding}";
    }
}

public class DocumentManager
{
  private static DocumentManager _instance;

  private DocumentManager() { }

  public static DocumentManager Instance
  {
    get
      {
        if (_instance == null)
        {
          _instance = new DocumentManager();
        }
          return _instance;
        }
    }

    public List<Document> documents = new List<Document>(); 

    public void AddDocument(Document document)
    {
      documents.Add(document);
    }
}

class Program
{
  static void Main(string[] args)
  {
    DocumentManager manager = DocumentManager.Instance;
      
    manager.AddDocument(new WordDocument { Name = "Отчет", Author = "Romch33tos", Keywords = "Программирование", Theme = "Тема 1", FilePath = "C:\\Docs\\Отчет.docx", WordCount = 2220 });
    manager.AddDocument(new PdfDocument { Name = "Методическое пособие", Author = "Romcheetos", Keywords = "Паттерн", Theme = "Тема 2", FilePath = "C:\\Docs\\Методическое_пособие.pdf", PdfVersion = "1.7" });
    manager.AddDocument(new ExcelDocument { Name = "Таблица тимлидов", Author = "Romch33tos", Keywords = "Тимлид", Theme = "Тема 3", FilePath = "C:\\Docs\\Таблица_тимлидов.xlsx", SheetCount = 27 });
    manager.AddDocument(new TxtDocument { Name = "Заметки", Author = "Romch33tos", Keywords = "Дневник", Theme = "Тема 4", FilePath = "C:\\Docs\\Заметки.txt", Title = "Текстовый документ" });
    manager.AddDocument(new HtmlDocument { Name = "Страница", Author = "Romcheetos", Keywords = "Разметка", Theme = "Тема 5", FilePath = "C:\\Docs\\Страница.html", Encoding = "UTF-8" });

    string choice;
    while (true)
    {
      Console.WriteLine("Выберите номер документа:");
      Console.WriteLine("1 - Word");
      Console.WriteLine("2 - PDF");
      Console.WriteLine("3 - Excel");
      Console.WriteLine("4 - TXT");
      Console.WriteLine("5 - HTML");
      Console.WriteLine("0 - Выход");
      choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          Console.WriteLine(manager.documents[0].GetInfo());
          break;
        case "2":
          Console.WriteLine(manager.documents[1].GetInfo());
          break;
        case "3":
          Console.WriteLine(manager.documents[2].GetInfo());
          break;
        case "4":
          Console.WriteLine(manager.documents[3].GetInfo());
          break;
        case "5":
          Console.WriteLine(manager.documents[4].GetInfo());
          break;
        case "0":
          return;
        default:
          Console.WriteLine("Некорректная команда!");
          break;
      }
    }
  }
}
