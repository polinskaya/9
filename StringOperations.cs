using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    delegate void StringOperation(ref string str);
    partial class Program
    {
        static void CorrectString(string str)
        {
            StringOperation stringOperation=null;
            stringOperation += DeletePunctuationMark;
            stringOperation += FerstToApperCase;
            stringOperation += AddDote;
            stringOperation += AddAuthor;
           
            stringOperation(ref str); 

            Console.WriteLine(str);
        }

        static void Action_ColorPrint(ref string str,Action<string> correctAndPrint)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            correctAndPrint(str);
            Console.ResetColor();
        }

        static void DeleteSpase(ref string str)
        {
           string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
           str = String.Join(" ", words);
        }
        static void DeletePunctuationMark(ref string str)
        {
            DeleteSpase(ref str);
            str = String.Join("",str.Split('.', ',', '!', '?', ';', ':'));
        }

        static void FerstToApperCase(ref string str)
        {
            str=str.Replace(str[0], Convert.ToString(str[0]).ToUpper()[0]);
        }

        static void AddDote(ref string str)
        {
            str +=".";
        }
        static void AddAuthor(ref string str)
        {
            str += " Yulia";
        }
    }
}
