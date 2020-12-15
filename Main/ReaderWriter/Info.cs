using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Lab_13
{
    public class Info
    {
        public static void Reader(List<Clients> clientList)
        {
            StreamReader sr = new StreamReader(@"ClientList.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (s.Length == 5)
                {
                    clientList.Add(new Clients.Creditor(s[0], Convert.ToDateTime(s[1]), Convert.ToDecimal(s[2]),
                                                      Convert.ToDouble(s[3]), Convert.ToDecimal(s[4])));
                }
                if (s.Length == 4)
                {
                    int number;
                    if (Int32.TryParse(s[2], out number))
                    {
                        clientList.Add(new Clients.Organization(s[0], Convert.ToDateTime(s[1]),
                                                     number, Convert.ToDecimal(s[3])));
                    }
                    else
                    {
                        clientList.Add(new Clients.Investor(s[0], Convert.ToDateTime(s[1]),
                                  Convert.ToDecimal(s[2]), Convert.ToDouble(s[3])));
                    }
                }
            }
            sr.Close();
        }
        public static void Writer(List<Clients> clientList)
        {


            Console.WriteLine("Введите количество Клиентов, которых желаете ввести в список:\n\t" +
                "Если не желаете добавлять, введите: 0");
            int n = int.Parse(Console.ReadLine());
            if (n == 0) return;

            for (int i = 0; i < n; i++)
            {
                string Surname = null;
                string DateString = null;
                var Date = new DateTime();
                decimal Amount = default;
                double Interest = default;
                decimal Balance = default;
                int Number = default;
                Console.WriteLine("Введите клиента, которого вы хотите добавить (1-Вкладчик, 2-Кредитор, 3-Организация):");
                int m = int.Parse(Console.ReadLine());
                if (m == 1)
                {
                    Console.Write("Фамилия вкладчика: "); Surname = Console.ReadLine();
                    Console.Write("Дата открытия вклада: "); Date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Размер вклада: "); Amount = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Процент по вкладу: "); Interest = Convert.ToDouble(Console.ReadLine());
                    DateString = Date.ToShortDateString();
                    using (StreamWriter sw = File.AppendText(@"ClientList.txt"))
                    {
                        sw.WriteLine($"{Surname} {DateString} {Amount} {Interest}");
                    }
                    clientList.Add(new Clients.Investor(
                        Surname,
                        Date,
                        Amount,
                        Interest
                        ));
                }
                else if (m == 2)
                {
                    Console.Write("\nФамилия вкладчика: "); Surname = Console.ReadLine();
                    Console.Write("Дата выдачи кредита: "); Date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Размер кредита: "); Amount = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Процент по кредиту: "); Interest = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Остаток долга: "); Balance = Convert.ToDecimal(Console.ReadLine());
                    DateString = Date.ToShortDateString();
                    using (StreamWriter sw = File.AppendText(@"ClientList.txt"))
                    {
                        sw.WriteLine($"{Surname} {DateString} {Amount} {Interest} {Balance}");
                    }
                    clientList.Add(new Clients.Creditor(
                        Surname,
                        Date,
                        Amount,
                        Interest,
                        Balance
                        ));
                }
                else if (m == 3)
                {
                    Console.Write("Название организации: "); Surname = Console.ReadLine();
                    Console.Write("Дата открытия счета: "); Date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Номер счета: "); Number = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Сумма на счету: "); Amount = Convert.ToDecimal(Console.ReadLine());
                    DateString = Date.ToShortDateString();
                    using (StreamWriter sw = File.AppendText(@"ClientList.txt"))
                    {
                        sw.WriteLine($"{Surname} {DateString} {Number} {Amount}");
                    }
                    clientList.Add(new Clients.Organization(
                        Surname,
                        Date,
                        Number,
                        Amount
                        ));
                }
            }
            Console.ReadLine();
        }
    }
}
