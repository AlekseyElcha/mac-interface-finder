using System;

namespace vmInterfacesFinderForMacTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для поиска сетевых интерфейсов на macOS");
            Console.WriteLine("Версия v.1.0.0");
            Console.WriteLine();
            InterfaceFinder.ListInterfaces();
        }
    }
}