using System;
using System.Collections.Generic;
using System.Linq;
using Plants;

namespace Plants
{
    class Village
    {
        public Dictionary<string, List<object>> Collections { get; } = new Dictionary<string, List<object>>();

        public void AddCollection(string key, List<object> collection)
        {
            Collections[key] = collection;
        }

        public void PrintAll<T>(Func<T, object> selector)
        {
            var items = Collections.SelectMany(c => c.Value).OfType<T>();
            foreach (var item in items)
            {
                Console.WriteLine(selector(item));
            }
        }
    }

    class Garden
    {
        public Queue<Plant> Plants { get; } = new Queue<Plant>();

        public void AddPlant(Plant plant)
        {
            Plants.Enqueue(plant);
        }

        public void PrintAllPlants()
        {
            foreach (var plant in Plants)
            {
                Console.WriteLine(plant.ToString());
            }
        }
    }

    class TreeCollection
    {
        public List<Tree> Trees { get; } = new List<Tree>();

        public void AddTree(Tree tree)
        {
            Trees.Add(tree);
        }

        public void PrintAllTrees()
        {
            foreach (var tree in Trees)
            {
                Console.WriteLine(tree.ToString());
            }
        }
    }

    class FlowerCollection
    {
        public List<Flower> Flowers { get; } = new List<Flower>();

        public void AddFlower(Flower flower)
        {
            Flowers.Add(flower);
        }

        public void PrintAllFlowers()
        {
            foreach (var flower in Flowers)
            {
                Console.WriteLine(flower.ToString());
            }
        }
    }
}
