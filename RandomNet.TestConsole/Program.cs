using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNet.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RandomOrg.IntegerGenerator(10, 1, 6);
            foreach (var item in result) Console.WriteLine(item);
        }
    }
}
