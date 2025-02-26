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
        return $"Name: {Name}, Author: {Author}, Keywords: {Keywords}, Theme: {Theme}, FilePath: {FilePath}";
    }
}

public class WordDocument : Document
{
    public int WordCount { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Word Count: {WordCount}";
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

        manager.AddDocument(new WordDocument { Name = "Doc1", Author = "Author1", Keywords = "Keyword1", Theme = "Theme1", FilePath = "C:\\Docs\\Doc1.docx", WordCount = 500 });
        
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
                    Console.WriteLine("2");
                    break;
                case "3":
                    Console.WriteLine("3");
                    break;
                case "4":
                    Console.WriteLine("4");
                    break;
                case "5":
                    Console.WriteLine("5");
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