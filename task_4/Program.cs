//паттерн команда, вкл/выкл лампочку и изменение тональности

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_and_P_lab_4
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Switch @switch = new Switch();
            Lamp lamp = new Lamp();
            @switch.SetCommand(new LampCommand(lamp));
            @switch.PressButton();
            @switch.PressUndo();

            Tone tone = new Tone();
            @switch.SetCommand(new ToneCommand(tone));
            @switch.PressButton();
            @switch.PressUndo();

            Console.ReadKey();

        }

        interface ICommand
        {
            void Execute();
            void Undo();
        }

        class Lamp
        {
            public void ON ()
            {
                Console.WriteLine("Лампочка включена");
            }

            public void OFF()
            {
                Console.WriteLine("Лампочка выключена");
            }
        }

        class Tone
        {
            public void Tone1()
            {
                Console.WriteLine("Смена тональности на \"холодную\"");
            }

            public void Tone2()
            {
                Console.WriteLine("Смена тональности обратно на \"тёмную\"");
            }
        }

        class ToneCommand : ICommand
        {
            Tone tone;

            public ToneCommand(Tone tone)
            {
                this.tone = tone;
            }

            public void Execute()
            {
                tone.Tone1();
            }

            public void Undo()
            {
                tone.Tone2();
            }
        }


        class LampCommand : ICommand
        {
            Lamp lamp;

            public LampCommand(Lamp lamp)
            {
                this.lamp = lamp; 
            }

            public void Execute()
            {
                lamp.ON();
            }

            public void Undo()
            {
               lamp.OFF();
            }
        }

        class Switch
        {
            ICommand command;

            public void  SetCommand(ICommand command)
            {
                this.command = command;
            }

            public void PressButton()
            {
                command.Execute();
            }

            public void PressUndo()
            {
                command.Undo();
            }

        }



    }
}
