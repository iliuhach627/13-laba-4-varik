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
            Console.ReadLine();
            string search = Console.ReadLine();
            foreach (var s in FindSurname(clientList, search))
                s.PrintInfo();

            //foreach (Clients client in clientList)
            //{
            //    client.PrintInfo();
            //    Console.WriteLine();
            //}
        }
        private static IEnumerable<Clients> FindSurname(List<Clients> clients, string name)
        {
            foreach (var s in clients)
                if (s is Clients)
                    if ((s as Clients.Investor).Surname.Contains(name) || (s as Clients.Creditor).Surname.Contains(name) || (s as Clients.Organization).Name.Contains(name))
                        yield return s;
        }
    }
}