using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace vmInterfacesFinderForMacTerminal;

public class InterfaceFinder
{
    public static void ListInterfaces()
    {
        Console.WriteLine("=== ПОИСК СЕТЕВЫХ ИНТЕРФЕЙСОВ ===");
        Console.WriteLine();

        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        if (interfaces.Length == 0)
        {
            Console.WriteLine("Сетевые интерфейсы не обнаружены.");
            return;
        }

        int counter = 0;
        foreach (NetworkInterface ni in interfaces)
        {
            Console.WriteLine($"{counter+1}. Интерфейс: {ni.Name}");
            Console.WriteLine($"   Описание:   {ni.Description}");
            Console.WriteLine($"   Тип:        {ni.NetworkInterfaceType}");
            
            string statusStr = ni.OperationalStatus == OperationalStatus.Up ? "АКТИВЕН (UP)" : "НЕАКТИВЕН (DOWN)";
            Console.WriteLine($"   Статус:     {statusStr}");
            
            IPInterfaceProperties ipProps = ni.GetIPProperties();
            bool hasIp = false;

            foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
            {
                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"   -> IPv4:    {ip.Address}");
                    hasIp = true;
                }
                else if (ip.Address.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    Console.WriteLine($"   -> IPv6:    {ip.Address}");
                    hasIp = true;
                }
            }

            if (!hasIp)
            {
                Console.WriteLine("   -> IP-адреса отсутствуют");
            }

            Console.WriteLine(new string('-', 50));
            counter++;
        }

        Console.WriteLine($"Найдено сетевых интерфейсов: {counter}");
        Console.WriteLine();
        Console.WriteLine("=== ПОИСК СЕТЕВЫХ ИНТЕРФЕЙСОВ ЗАВЕРШËН ===");
    }
}