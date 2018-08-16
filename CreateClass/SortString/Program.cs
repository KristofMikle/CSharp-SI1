using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortString
{
    class Program
    {
        private static string s;

        static void Main(string[] args)
        {
            string str = "Microsoft .NET Framework 2.0 Application Development Foundation";
            string[] words = str.Split(' ');
            Array.Sort(words);
            s = string.Join(" ", words);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
