using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public delegate int Voltage();
    public delegate int Upgrade();

    static class Boss
    {
        public static event Upgrade Upgrading;


        public static void Upgrade(Voltage valtage) 
        {
            Console.WriteLine("Допустимое значение напряжения :{0}", valtage());
        }

        public static void TurnOn(this Technique obj,int volt)
        {
            Upgrading += obj.AddVoltage100;
            if(obj.AllowableVoltage < volt )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Напряжение велико, процесс улучшения...");
            }
            else Console.ForegroundColor = ConsoleColor.Blue;

            while (obj.AllowableVoltage<volt && Upgrading!= null)
            {
                Upgrading?.Invoke();   
            }

            Console.WriteLine("Включено");
            Console.ResetColor();
            
            Upgrading = null;
        }

        public static void TurnOn(this SemiTechnique obj, int voltM,int voltT)
        {
            Upgrading += obj.AddVoltage50;
            Upgrading += () =>
            {
                Console.WriteLine("Человек(выносливость): Увеличено на 15");
                return obj.AllowableVoltageMen += 15;
            };

            if (obj.AllowableVoltageTechnuque < voltT || obj.AllowableVoltageMen < voltM)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Напряжение велико,процесс улучшения..");
            }
            else Console.ForegroundColor = ConsoleColor.Blue;

            while (obj.AllowableVoltageTechnuque < voltT ||obj.AllowableVoltageMen<voltM && Upgrading != null)
            {
                if(obj.AllowableVoltageTechnuque >= voltT)
                {                    
                    Upgrading -= obj.AddVoltage50;
                    Upgrading -= obj.AddVoltage100;
                }
                
                Upgrading?.Invoke();
            }
            
            Console.WriteLine("Включено");
            Console.ResetColor();
            Console.WriteLine();

            Upgrading = null;
        }
    }

    public class Technique
    {
        private int allowableVoltage;

        public Technique(int x)
        {
            this.AllowableVoltage = x;
            Console.WriteLine("Допустимое значение напряжения :{0}", this.AllowableVoltage);
        }

        public int AddVoltage50()
        {
            Console.WriteLine("Увеличено на 30");
            return AllowableVoltage += 30;
        }

        public int AllowableVoltage { get => allowableVoltage; set => allowableVoltage = value; }

        public int AddVoltage100()
        {
            Console.WriteLine("Увеличено на 80");
            return AllowableVoltage += 80;
        }
    }
    public class SemiTechnique
    {
        private int allowableVoltageMen;
        private int allowableVoltageTechnuque;

        public SemiTechnique(int AllowableVoltageMen, int AllowableVoltageTechnuque)
        {
            this.AllowableVoltageMen = AllowableVoltageMen;
            this.AllowableVoltageTechnuque = AllowableVoltageTechnuque;
            Console.WriteLine("Допустимое значение напряжения: \n*человек:{0}\n*техника:{1}", this.AllowableVoltageMen,this.AllowableVoltageTechnuque);
        }

        public int AllowableVoltageMen { get => allowableVoltageMen; set => allowableVoltageMen = value; }
        public int AllowableVoltageTechnuque { get => allowableVoltageTechnuque; set => allowableVoltageTechnuque = value; }

        public int AddVoltage100()
        {
            Console.WriteLine("Техника: Увеличено на 100");
            return AllowableVoltageTechnuque+=100;            
        }
        

        public int AddVoltage50()
        {
            Console.WriteLine("Техника: Увеличено на 50");

            return AllowableVoltageTechnuque += 50;
        }
         
    }
}
