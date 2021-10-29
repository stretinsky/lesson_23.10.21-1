using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_23._10._21
{
    enum Sign { sysEngineer, developer, bosses }
    enum Type { develop, web }
    class Program
    {
        public struct Task
        {
            public Sign sign;
            public Type type;
            public string name;
        }

        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "employee.txt"), System.Text.Encoding.Default))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Task task;
                    task.name = s.Split(' ')[0];
                    task.sign = (Sign)byte.Parse(s.Split(' ')[1]);
                    task.type = (Type)byte.Parse(s.Split(' ')[2]);
                    tasks.Add(task);
                }
            }
            Console.ReadKey();
        }
    }
}
