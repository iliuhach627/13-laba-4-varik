using System;
using System.Collections.Generic;
 
namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clients> clientList = new List<Clients>();

            Info.Reader(clientList);
            Info.Writer(clientList);
            Console.Clear();

            foreach (Clients client in clientList)
            {
                client.PrintInfo();
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.Write("Введите дату, с которой клиента начали сотрудничать с банком: ");
            DateTime askDate = new DateTime();
            askDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();
            int foundClients = 0;

            foreach (var client in clientList)
            {
                if (client.IsClientByDate(askDate))
                {
                    client.PrintInfo();
                    foundClients++;
                    Console.WriteLine();
                }
            }
            if (foundClients == 0)
            {
                Console.WriteLine("Клиенты по данной дате не найдены.");
            }
            Console.ReadLine();

        }
    }
}