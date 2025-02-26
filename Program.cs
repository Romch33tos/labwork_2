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

public class PdfDocument : Document
{
    public string PdfVersion { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", PDF Version: {PdfVersion}";
    }
}

public class ExcelDocument : Document
{
    public int SheetCount { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Sheet Count: {SheetCount}";
    }
}

public class TxtDocument : Document
{
    public string Title { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Title: {Title}";
    }
}

public class HtmlDocument : Document
{
    public string Encoding { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Encoding: {Encoding}";
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
        manager.AddDocument(new PdfDocument { Name = "Doc2", Author = "Author2", Keywords = "Keyword2", Theme = "Theme2", FilePath = "C:\\Docs\\Doc2.pdf", PdfVersion = "1.7" });
        manager.AddDocument(new ExcelDocument { Name = "Doc3", Author = "Author3", Keywords = "Keyword3", Theme = "Theme3", FilePath = "C:\\Docs\\Doc3.xlsx", SheetCount = 2220 });
        manager.AddDocument(new TxtDocument { Name = "Doc4", Author = "Author4", Keywords = "Keyword4", Theme = "Theme4", FilePath = "C:\\Docs\\Doc4.txt", Title = "Текстовый документ" });
        manager.AddDocument(new HtmlDocument { Name = "Doc5", Author = "Author5", Keywords = "Keyword5", Theme = "Theme5", FilePath = "C:\\Docs\\Doc5.html", Encoding = "UTF-8" });

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