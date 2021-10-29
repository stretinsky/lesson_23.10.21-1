using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_met_23._10._21
{
    class BankAccount
    {
        enum accountType { current, saving }
        private static int id = 101;
        private decimal balance = 0;
        private accountType type;
        private int ID = id;
        public void SetType()
        {
            byte action;
            Console.WriteLine("Выберите тип аккаунта:\n0 - текущий\n1 - сберегательный");
            while (!byte.TryParse(Console.ReadLine(), out action) | action < 0 | action > 1)
            {
                Console.WriteLine("Некорректное значение, попробуйте снова");
            }
            type = (accountType)action;
        }
        public void SwitchType()
        {
            if (type == accountType.current)
            {
                type = accountType.saving;
            }
            else
            {
                type = accountType.current;
            }
            Console.Clear();
            Console.WriteLine("Тип аккаунта изменен на " + type);
        }
        public void Deposite(decimal amount)
        {
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.Clear();
                Console.WriteLine("Деньги выведены со счета");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Недостаточно средств");
            }
        }
        public void GetAccountInfo()
        {
            Console.WriteLine("Номер счета: {0}\nТип счёта: {1}\nБаланс: {2}", ID, type, balance);
        }
        public void Trasfer(int a, int b, decimal amount, List<BankAccount> accounts)
        {
            if (accounts[a].GetBalance() >= amount)
            {
                accounts[a].Withdraw(amount);
                accounts[b].Deposite(amount);
                Console.Clear();
                Console.WriteLine("Деньги переведены");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Недостаточно средств для перевода");
            }
        }
        public int GetID()
        {
            return ID;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public static int AddID()
        {
            return ++id;
        }
    }
}
