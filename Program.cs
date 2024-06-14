using System;
using System.Collections.Generic;
using System.Linq;
using Plants;


namespace Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            var village = new Village();
            var garden = new Garden();
            var treeCollection = new TreeCollection();
            var flowerCollection = new FlowerCollection();
            var authors = new List<Author>(); // Предположим, что это коллекция авторов

            // Добавление некоторых элементов для демонстрации
            AddSampleData(village, garden, treeCollection, flowerCollection, authors);

            // Выполнение запросов с использованием LINQ запросов и методов расширения
            ExecuteQueries(village, garden, treeCollection, flowerCollection, authors);

            // Меню
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. View Selected Data Using LINQ Queries");
                Console.WriteLine("2. View Selected Data Using Extension Methods");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ExecuteQueries(village, garden, treeCollection, flowerCollection, authors);
                        break;
                    case "2":
                        ExecuteQueriesUsingExtensionMethods(village, garden, treeCollection, flowerCollection, authors);
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddSampleData(Village village, Garden garden, TreeCollection treeCollection, FlowerCollection flowerCollection, List<Author> authors)
        {
            // Добавление тестовых данных
            garden.AddPlant(new Plant("Rose", "Red", 1, 2.5));
            treeCollection.AddTree(new Tree("Oak", "Brown", 15.0, 3));
            flowerCollection.AddFlower(new Flower("Tulip", "Red", "Sweet", 1));
            authors.Add(new Author(1, "John Doe")); // Добавляем автора для демонстрации
        }

        static void ExecuteQueries(Village village, Garden garden, TreeCollection treeCollection, FlowerCollection flowerCollection, List<Author> authors)
        {

            // Выполнение запросов с использованием LINQ запросов
            Console.WriteLine("\nLINQ Queries:");
            var joinedData = authors.Join(treeCollection.Trees,
                              author => author.Id, // KeySelector for the first sequence
                              tree => tree.Id, // KeySelector for the second sequence
                              (author, tree) => new { AuthorName = author.Name, TreeColor = tree.Color }); // ResultSelector
            foreach (var data in joinedData)
            {
                Console.WriteLine($"Author: {data.AuthorName}, Tree Color: {data.TreeColor}");
            }
        }

        static void ExecuteQueriesUsingExtensionMethods(Village village, Garden garden, TreeCollection treeCollection, FlowerCollection flowerCollection, List<Author> authors)
        {


            // Выполнение запросов с использованием методов расширения
            Console.WriteLine("\nExtension Methods:");
            // Аналогично предыдущему методу, предполагается логическая связь между Author и Tree
            var joinedData = authors.Join(treeCollection.Trees,
                                          author => author.Id,
                                          tree => tree.Id,
                                          (author, tree) => new { AuthorName = author.Name, TreeColor = tree.Color })
                                    .ToList();
            foreach (var data in joinedData)
            {
                Console.WriteLine($"Author: {data.AuthorName}, Tree Color: {data.TreeColor}");
            }
        }
    }
}
