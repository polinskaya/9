using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Technique technique = new Technique(100);
            SemiTechnique semiTechnique = new SemiTechnique(30, 100);

            Boss.Upgrade(technique.AddVoltage100);

            technique.TurnOn(500);

            Boss.Upgrading += semiTechnique.AddVoltage100;
            semiTechnique.TurnOn(100, 350);

            semiTechnique.TurnOn(100, 350);

            String str = "Лабораторная,.,   ,,,номер:! 9;...?";
         
            StringOperation stringOperation = null;
            stringOperation += DeletePunctuationMark;
            stringOperation += FerstToApperCase;
            stringOperation += AddDote;
            stringOperation += AddAuthor;

            Action_ColorPrint(ref str, CorrectString);

            Console.ReadLine();
        }
    }
}
