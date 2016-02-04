using System;

namespace RandomNet.TestConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var result = RandomOrg.IntegerGenerator(10, 1, 6);
            foreach (var item in result) Console.WriteLine(item.ToString());
        }
    }
}
