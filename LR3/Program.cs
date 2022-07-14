using System;
using System.IO;
using System.Linq;

namespace LR3
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadable read = new Read();
            var conv = new Converter();
            var calc = new Calc();

            string fileName = "Input.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            var strings = read.GetNextLine(path);
            var varsDicts = conv.ConvertToDictionary(strings);
            var terms = strings.Where(x => !x.Contains("=")).ToList();
 
            foreach (var varDict in varsDicts)
                Console.WriteLine($"{varDict.Key} = {varDict.Value}");

            foreach (var term in terms)
            {
                Console.WriteLine($"Выражение: {term}");
                Console.WriteLine($"Результат: {calc.Calculate(conv.ReplaceLine(term, varsDicts))}");
            }

            Console.ReadKey();
        }
    }
}
