using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.HolloWorld();
            Console.ReadKey();
        }

        public string HolloWorld()
        {
            Test.Get();
            return "Hello World!";
        }
    }

}
