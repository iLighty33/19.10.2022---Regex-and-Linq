using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace _19._10._2022___Regex_and_Linq
{
    public class myRegexExpression
    {
        static public  MatchCollection myRegex(
         string input,
         string pattern,
         string replacement = "заменено")
        {
            // \d{4}[./]\d{1,2}[./]\d{1,2} - YYYY.MM.DD
            // \d{1, 2}[./]\d{1,2}[./]\d{4} - DD.MM.YYYY
            //pattern001 =@"\d{4}[./]\d{1,2}[./]\d{1,2}";
            //pattern001 =@"\d{1, 2}[./]\d{1,2}[./]\d{4}";
            Regex regex = new Regex(pattern);
            //Regex regex002 = new Regex(pattern002);
            MatchCollection matches = regex.Matches(input);
            //MatchCollection matches = regex002.Matches(input);
            Regex.Replace(input, pattern, replacement);
            return matches;
        }
        static public void PrintMatches(MatchCollection matches)
        {
            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }

    internal class Program
    {
        // input - Ввод
        

     
        static void Main(string[] args)
        {
            // Read my Text

            var myDoc = Environment.SpecialFolder.MyDocuments;
            string path = myDoc + @"\Перекрасов Роман\19.10.2022 - Regex and Linq\19.10.2022 - Regex and Linq\myFile.txt";
            string path2 = myDoc + @"\Перекрасов Роман\19.10.2022 - Regex and Linq\19.10.2022 - Regex and Linq\myRegex.txt";


                string myFile = args[0];
                string myRegex = args[1];


            StreamReader myReader = new StreamReader(myFile);

            string myFile001 = "";
            while (!myReader.EndOfStream)
            {
                myFile001 = myReader.ReadLine();

                Console.WriteLine(myFile001);
            }
            myReader.Close();



            StreamReader myReader2 = new StreamReader(myRegex);

            string myRegex001 = "";
            while (!myReader2.EndOfStream)
            {
                myRegex001 = myReader2.ReadLine();

                Console.WriteLine(myRegex001);
            }
            myReader2.Close();

            myRegexExpression myRegex1 = new myRegexExpression();
            myRegex1.PrintMatches(myRegexExpression.myRegex(myFile001, myRegex001));

            // Read my Pattern

            Console.WriteLine(path);
            Console.ReadKey();

            string text, pattern001, pattern002 = "";
            try
            {
                text = args[0];
                pattern001 = args[1];
                try
                {
                    pattern002 = args[2];
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите 2ой шаблон поиска (RegEx): ");
                    pattern002 = Console.ReadLine();
                }    
            }
            catch (Exception)
            {
                Console.WriteLine("Введите текст: ");
                text = Console.ReadLine();
                Console.WriteLine("Введите шаблон поиска (RegEx): ");
                pattern001 = Console.ReadLine();

            }
            myRegexExpression.PrintMatches(myRegexExpression.myRegex(text, pattern001));
            if (pattern002 != "")
            {
                myRegexExpression.PrintMatches(myRegexExpression.myRegex(text, pattern002));
            }
            Console.ReadKey();
        }
    }
}
