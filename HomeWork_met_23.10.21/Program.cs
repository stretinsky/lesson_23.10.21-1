using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_met_23._10._21
{
    class Program
    {
        static BankAccount CreateAccount()
        {
            BankAccount account = new BankAccount();
            account.SetType();
            BankAccount.AddID();
            Console.Clear();
            Console.WriteLine("Счёт открыт. Его номер: {0}", account.GetID());
            return account;
        }
        static string Reverse(string s)
        {
            List<char> chars = new List<char>();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                chars.Add(s[i]);
            }
            return string.Join("", chars);
        }
        static void SearchString(string str, ref string s)
        {
            if (str.Contains(s))
            {
                s = str.Split('#')[1];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 8.1");
            List<BankAccount> accounts = new List<BankAccount>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nВведите:\n1 - чтобы открыть новый счёт\n2 - выполить действия со счетами\n3 - чтобы перевести деньги с одного счёта на другой\nДругое - завершить работу программы");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        accounts.Add(CreateAccount());
                        break;
                    case "2":
                        if (accounts.Count < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Cначала откройте хотя бы 1 счёт");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите счёт");
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                Console.WriteLine("{0} - {1}", i, accounts[i].GetID());
                            }
                            int number;
                            while (!int.TryParse(Console.ReadLine(), out number) | number > (accounts.Count - 1) | number < 0)
                            {
                                Console.WriteLine("Некорректное значение, попробуйте снова");
                            }
                            Console.Clear();
                            accounts[number].GetAccountInfo();
                            Console.WriteLine("\nВыберите действие:\n1 - пополнить счёт\n2 - Вывести со счёта\n3 - изменить тип счета\nДругое - вернуться на главное меню");
                            decimal amount;
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("Введите сумму");
                                    while (!decimal.TryParse(Console.ReadLine(), out amount) | amount <= 0)
                                    {
                                        Console.WriteLine("Некорректное значение, попробуйте снова");
                                    }
                                    accounts[number].Deposite(amount);
                                    Console.Clear();
                                    Console.WriteLine("Счет пополнен");
                                    break;
                                case "2":
                                    Console.WriteLine("Введите сумму");
                                    while (!decimal.TryParse(Console.ReadLine(), out amount) | amount <= 0)
                                    {
                                        Console.WriteLine("Некорректное значение, попробуйте снова");
                                    }
                                    accounts[number].Withdraw(amount);
                                    break;
                                case "3":
                                    accounts[number].SwitchType();
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case "3":
                        if (accounts.Count < 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Отройте хотя бы 2 счёта");
                        }
                        else
                        {
                            int a, b;
                            decimal amount;
                            Console.Clear();
                            Console.WriteLine("Выберите счёт, с которого будете переводить деньги");
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                Console.WriteLine("{0} - {1}", i, accounts[i].GetID());
                            }
                            while (!int.TryParse(Console.ReadLine(), out a) | a < 0 | a > (accounts.Count - 1))
                            {
                                Console.WriteLine("Некорректное значение, попробуйте снова");
                            }
                            Console.Clear();
                            Console.WriteLine("Выбран счёт номер {0}. Доступно {1}\n\nВыберите счёт, на который будете переводить деньги", accounts[a].GetID(), accounts[a].GetBalance());
                            for (int i = 0; i < accounts.Count; i++)
                            {
                                if (i == a) { continue; }
                                Console.WriteLine("{0} - {1}", i, accounts[i].GetID());
                            }
                            while (!int.TryParse(Console.ReadLine(), out b) | b < 0 | b > (accounts.Count - 1) | b == a)
                            {
                                Console.WriteLine("Некорректное значение, попробуйте снова");
                            }
                            Console.Clear();
                            Console.WriteLine("Выбран счёт {0}\n\nВведите сумму. Доступно {1} рублей", accounts[b].GetID(), accounts[a].GetBalance());
                            while (!decimal.TryParse(Console.ReadLine(), out amount) | amount > accounts[a].GetBalance() | amount <= 0)
                            {
                                Console.WriteLine("Некорректное значение, попробуйте снова");
                            }
                            accounts[0].Trasfer(a, b, amount, accounts);
                        }
                        break;
                    default:
                        flag = false;
                        break;
                }

            }

            Console.WriteLine("\nTask 8.2\nВведите строку");
            string s = Console.ReadLine();
            Console.WriteLine("Вот строка в обратном порядке: '{0}'", Reverse(s));

            try
            {
                Console.WriteLine("\nTask 8.3\nВведите имя файла");
                string path = Path.Combine(Directory.GetCurrentDirectory(), String.Join("", Console.ReadLine(), ".txt"));
                if (File.Exists(path))
                {
                    Console.WriteLine("Файл существует. Текст записан в файл output.txt");
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                    {
                        s = sr.ReadToEnd().ToUpper();
                    }
                    using (StreamWriter sw = new StreamWriter(String.Join("", Directory.GetCurrentDirectory(), @"/output.txt")))
                    {
                        sw.Write(s);
                    }
                }
                else
                {
                    Console.WriteLine("Файл не существует");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Что-то не так");
            }

            Console.WriteLine("\nHomeWork 8.1");
            List<string> mails = new List<string>();
            List<string> names = new List<string>();
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "FIOandMail.txt"), System.Text.Encoding.Default))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    names.Add(str.Split('#')[0]);
                    mails.Add(str.Split('#')[1]);
                }
            }
            using (StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "mails.txt")))
            {
                foreach (var mail in mails)
                {
                    sw.WriteLine(mail);
                }
            }
            Console.WriteLine("Файл с почтами создан\nВведите имя сотрудника из доступных");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            s = Console.ReadLine();
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "FIOandMail.txt"), System.Text.Encoding.Default))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    SearchString(str, ref s);
                }
            }
            Console.WriteLine("Его почта " + s);

            /*Console.WriteLine("HomeWork 8.2");
            List<Song> songs = new List<Song>();
            Song song = new Song();
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "songs.txt"), System.Text.Encoding.Default))
            {
                Console.WriteLine("Список песен");
                while ((s = sr.ReadLine()) != null)
                {
                    song.SetName(s.Split('#')[0]);
                    song.SetAuthor(s.Split('#')[1]);
                    song.SetPrev(songs);
                    songs.Add(song);
                    Console.WriteLine(songs.Last().Title());
                }
            }
            foreach (var soong in songs)
            {
                Console.WriteLine("{0} {1} : {2} {3}", soong.Title(), soong.prev);
            }
            Console.WriteLine(song.Equals(songs[1]));*/ // не работает
            Console.ReadKey();
        }
    }
}
