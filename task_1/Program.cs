/*Реализовать программный продукт, выполняющий подсчёт заработной платы сотрудника за месяц
в зависимости от типа его занятости 
- полная рабочая неделя (40 часов),
- сокращённая рн для лиц от 16 до 18 (36 часов), 
- сокращённая рн для лиц младше 16 (24 часа).
Стоимость часа работы выбрать самостоятельно.
Использовать паттерн реализации "Стратегия"*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOA_and_P_lab_1
{
    internal class Program
    {
        public interface ISalary    
        {
            void salary_calculation(double hour_price);
        }
        
        public class FullWeek : ISalary //полная рабочая неделя (40 часов)
        {
            int hours = 40;
            public void salary_calculation(double hour_price)
            {
                Console.WriteLine($"Зарплата за полную рабочую неделю: {hour_price * hours} рублей");
            }
        }

        public class HalfWeek : ISalary //сокращённая рн для лиц от 16 до 18 (36 часов), 

        {
            int hours = 36;
            public void salary_calculation(double hour_price)
            {
                Console.WriteLine($"Зарплата за сокращённую рабочую неделю для лиц от 16 до 18: {hour_price * hours} рублей");
            }
        }

        public class LittleWeek : ISalary //сокращённая рн для лиц младше 16 (24 часа)
        {
            int hours = 24;
            public void salary_calculation(double hour_price)
            {
                Console.WriteLine($"Зарплата за сокращённую рабочую неделю для лиц младше 16: {hour_price * hours} рублей");
            }
        }

        public class Worker
        {
            public double hour_price;
            ISalary type_of_salary { get; set; }
            public Worker(ISalary type_of_salary, double hour_price = 1000)
            {
                this.hour_price = hour_price;
                this.type_of_salary = type_of_salary;
            }
            public void salary_calculation()
            {
                type_of_salary.salary_calculation(this.hour_price);
            }

        }

        static void Main(string[] args)
        {
            Worker worker = new Worker(new FullWeek(), 1000);
            worker.salary_calculation();
            Console.ReadKey();

        }
    }
}
