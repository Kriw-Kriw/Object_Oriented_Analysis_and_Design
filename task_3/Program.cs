//Вариант 9
//Используя паттерн абстрактная фабрика реализовать завод по производству автомобилей различных типов на разных заводах


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_and_P_lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TS heavy = new TS(new BlueHeavy());
            heavy.Construct();
            heavy.Paint();

            Console.WriteLine();
            ////////////////////////////////////////////////////////////////////////////////////

            TS light = new TS(new RedLight());
            light.Construct();  
            light.Paint();


            Console.ReadKey();
        }

        //абстрактный класс - тип транспорта
        abstract class Transport
        {
            public abstract void construct();
        }

        // абстрактный класс - цвета авто
        abstract class Color
        {
            public abstract void paint();
        }

        // класс грузовика
        class Heavy : Transport
        {
            public override void construct()
            {
                Console.WriteLine("Производим Грузовик");
            }
        }
       
        // класс легковушки
        class Light : Transport
        {
            public override void construct()
            {
                Console.WriteLine("Производим легковой автомобиль");
            }
        }
       
        // класс - красного цвета
        class Red : Color
        {
            public override void paint()
            {
                Console.WriteLine("Красный");
            }
        }
        
        // класс - голубого цвета
        class Blue : Color
        {
            public override void paint()
            {
                Console.WriteLine("Синий");
            }
        }

        // класс абстрактной фабрики
        abstract class TransportFactory
        {
            public abstract Transport chooseType();
            public abstract Color chooseColor();
        }



        // Фабрика создания голубого грузовика
        class BlueHeavy : TransportFactory
        {
            public override Transport chooseType()
            {
                return new Heavy();
            }

            public override Color chooseColor()
            {
                return new Blue();
            }
        }

        // Фабрика создания красной легковушки
        class RedLight : TransportFactory
        {
            public override Transport chooseType()
            {
                return new Light();
            }

            public override Color chooseColor()
            {
                return new Red();
            }
        }

        // клиент - само ТС
        class TS
        {
            private Transport transport;
            private Color color;
            public TS(TransportFactory factory)
            {
                transport = factory.chooseType();
                color = factory.chooseColor();
            }
            public void Construct()
            {
                transport.construct();
            }
            public void Paint()
            {
                color.paint();
            }
        }

    }
}
