using System;
using System.IO;
using System.Linq;

namespace Day_8a
{
    class Program
    {
        static void Main(string[] args)
        {
            const int width = 25;
            const int height = 6;

            string raw = File.ReadAllText(@"day8a-input.txt").Replace("\n", "");

            //split into rows
            var results = raw.Select((x, i) => i)
                .Where(i => i % width == 0)
                .Select(i => raw.Substring(i, raw.Length - i >= width ? width : raw.Length - i));

            //split into layers
            var layeredResults = results
                .Select((s, i) => i)
                .Where(i => i % height == 0)
                .Select(i => results.Where((s, index) => index >= i && index < i + height));

            //grab layer with least 0s
            var smallestLayer = layeredResults.OrderBy(x => x.Sum(x => x.Count(x => x == '0'))).First();

            //get count of 1 digits in layer
            var oneDigits = smallestLayer.Sum(x => x.Count(y => y == '1'));

            //get count of 2 digits in layer
            var twoDigits = smallestLayer.Sum(x => x.Count(y => y == '2'));

            Console.WriteLine($"Checksum: {oneDigits * twoDigits}");
        }
    }
}
