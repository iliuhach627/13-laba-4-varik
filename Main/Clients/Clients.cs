using System;

namespace Lab_13
{
    public abstract class Clients
    {
        public abstract void PrintInfo();
        public abstract bool IsClientByDate(DateTime date);

        public class Investor : Clients
        {
            public string Surname { get; set; }
            public DateTime DepositDate { get; set; }
            public decimal DepositAmount { get; set; }
            public double DepositInterest { get; set; }

            public Investor(string surname, DateTime depositDate, decimal depositAmount, double depositInterest)
            {
                Surname = surname;
                DepositDate = depositDate;
                DepositAmount = depositAmount;
                DepositInterest = depositInterest;
            }


            public override void PrintInfo()
            {
                Console.WriteLine("Фамилия вкладчика: {0}", Surname);
                Console.WriteLine("Дата открытия вклада: {0}", DepositDate.ToShortDateString());
                Console.WriteLine("Размер вклада: {0}", DepositAmount);
                Console.WriteLine("Процент по вкладу: {0}%", DepositInterest);
            }

            public override bool IsClientByDate(DateTime date)
            {
                if (DepositDate == date)
                    return true;
                return false;
            }
        }

        public class Creditor : Clients
        {
            public string Surname { get; set; }
            public DateTime CreditDate { get; set; }
            public decimal CreditAmount { get; set; }
            public double CreditInterest { get; set; }
            public decimal CreditBalance { get; set; }

            public Creditor(string surname, DateTime creditDate, decimal creditAmount, double creditInterest,
                            decimal creditBalance)
            {
                Surname = surname;
                CreditDate = creditDate;
                CreditAmount = creditAmount;
                CreditInterest = creditInterest;
                CreditBalance = creditBalance;
            }

            public override void PrintInfo()
            {
                Console.WriteLine("Фамилия вкладчика: {0}", Surname);
                Console.WriteLine("Дата выдачи кредита: {0}", CreditDate.ToShortDateString());
                Console.WriteLine("Размер кредита: {0}", CreditAmount);
                Console.WriteLine("Процент по кредиту: {0}%", CreditInterest);
                Console.WriteLine("Остаток долга: {0}", CreditBalance);
            }

            public override bool IsClientByDate(DateTime date)
            {
                if (CreditDate == date)
                    return true;
                return false;
            }
        }

        public class Organization : Clients
        {
            public string Name { get; set; }
            public DateTime AccountDate { get; set; }
            public int AccountNumber { get; set; }
            public decimal AccountAmount { get; set; }

            public Organization(string name, DateTime accountDate, int accountNumber, decimal accountAmount)
            {
                Name = name;
                AccountDate = accountDate;
                AccountNumber = accountNumber;
                AccountAmount = accountAmount;
            }

            public override void PrintInfo()
            {
                Console.WriteLine("Название организации: {0}", Name);
                Console.WriteLine("Дата открытия счета: {0}", AccountDate.ToShortDateString());
                Console.WriteLine("Номер счета: {0}", AccountNumber);
                Console.WriteLine("Сумма на счету: {0}", AccountAmount);
            }

            public override bool IsClientByDate(DateTime date)
            {
                if (AccountDate == date)
                    return true;
                return false;
            }
        }
    }
}
