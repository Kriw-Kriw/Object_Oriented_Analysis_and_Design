//адаптер

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_and_P_lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserOfClock user = new UserOfClock();
            user.setClock(new DigitalClock());
            user.checkTime();
            user.setTime(0, 20);
            user.checkTime();
            UserOfClock user2 = new UserOfClock();
            user2.setClock(new ArrowClockAdapter(new ArrowsClock()));
            user2.checkTime();
            user2.setTime(0, 20);
            user2.checkTime();

            Console.ReadKey();
        }

     
        //клиент
        class UserOfClock
        {
            IDigitalClock clock;
            public void setClock(IDigitalClock clock)
            {
               this.clock = clock;
            }
            public void checkTime()
            {
                clock.Watch();
            }
            public void setTime(int hours, int minutes)
            {
                clock.Change(hours, minutes);
            }

        }

        interface IDigitalClock
        {
            void Watch();
            void Change(int hours, int minutes);
        }
       
        //электронные часы
        class DigitalClock : IDigitalClock
        {
            int hours;
            int minutes;
            public DigitalClock(int hours = 11, int minutes = 11)
            {
                if(hours > 23 || hours < 0 || minutes < 0 || minutes > 59)
                {
                    this.hours = 11;
                    this.minutes = 11;
                    Console.WriteLine("Время введено не корректо, " +
                                        $"\n установлено значение по умолчанию: {this.hours}:{this.minutes}");
                }
                else
                {
                    this.hours = hours;
                    this.minutes = minutes;
                }

            }
            public void Watch()
            {
                Console.WriteLine($"Сейчас {this.hours}:{this.minutes}");
            }
            public void Change(int hours, int minutes)
            {
                if (hours > 23 || hours < 0 || minutes < 0 || minutes > 59)
                {
                    this.hours = 11;
                    this.minutes = 11;
                    Console.WriteLine("Время введено не корректо, " +
                                        $"\n установлено значение по умолчанию: {this.hours}:{this.minutes}");
                }
                else
                {
                    this.hours = hours;
                    this.minutes = minutes;
                }
            }
        }


        interface IArrowsClock
        {
            void Watch();
            void TwistArrows(int hours, int minutes, bool Times_of_Day);
        }

        //стрелочные часы
        class ArrowsClock : IArrowsClock
        {
            int hours;
            int minutes;
            bool Times_of_Day;

            private string Times_of_Day_Check()
            {
                if (this.Times_of_Day) return " дня ";
                else return " ночи ";
            }

            public ArrowsClock(int hours = 11, int minutes = 11, bool Times_of_Day = true)
            {
                if (hours > 12 || hours < 1 || minutes < 0 || minutes > 59)
                {
                    this.hours = 11;
                    this.minutes = 11;
                    this.Times_of_Day = true;

                    Console.WriteLine("Время введено не корректо, " +
                                        $"\n установлено значение по умолчанию: {this.hours} часов {this.minutes} минут{Times_of_Day_Check()}");
                }
                else
                {
                    this.hours = hours;
                    this.minutes = minutes;
                    this.Times_of_Day = Times_of_Day;
                }
            }

            public void Watch()
            {
                Console.WriteLine($"Сейчас {this.hours} часов {this.minutes} минут{Times_of_Day_Check()}");
            }

            public void TwistArrows(int hours, int minutes, bool Times_of_Day)
            {
                if (hours > 12 || hours < 1 || minutes < 0 || minutes > 59)
                {
                    this.hours = 11;
                    this.minutes = 11;
                    this.Times_of_Day = true;

                    Console.WriteLine("Время введено не корректо, " +
                                        $"\n установлено значение по умолчанию: {this.hours} часов {this.minutes} минут{Times_of_Day_Check()}");
                }
                else
                {
                    this.hours = hours;
                    this.minutes = minutes;
                    this.Times_of_Day = Times_of_Day;
                }
            }
        }

        //адаптер для стрелочных часов
        class ArrowClockAdapter : IDigitalClock
        {
            ArrowsClock ac;

            public ArrowClockAdapter(ArrowsClock ac)
            {
                this.ac = ac;
            }

            public void Watch()
            {
                ac.Watch();
            }

            public int HoursAdapt(int hours, ref bool Times_of_Day)
            {
                if (hours > 12 || hours == 0)
                {
                    Times_of_Day = false;
                }

                if (hours > 12 && hours <= 23)
                {
                    hours = hours - 12;
                }

                if (hours == 0)
                {
                    hours = 12;
                }

                return hours;
            }

            public void Change(int hours, int minutes)
            {
                bool Times_of_Day = true;

                hours = HoursAdapt(hours, ref Times_of_Day);

                ac.TwistArrows(hours, minutes, Times_of_Day);
            }
        }
    }
}
