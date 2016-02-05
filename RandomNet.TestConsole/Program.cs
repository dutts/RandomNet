using System;

namespace RandomNet.TestConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var result = IntegerGenerator.GenerateAsync(10, 1, 6).Result;
            foreach (var item in result) Console.WriteLine(item.ToString());

            Console.WriteLine("---");


            result = SequenceGenerator.GenerateAsync(1, 6).Result;
            foreach (var item in result) Console.WriteLine(item.ToString());
        }
    }
}
