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

class Program
{
    static void Main(string[] args)
    {
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
                    Console.WriteLine("1");
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