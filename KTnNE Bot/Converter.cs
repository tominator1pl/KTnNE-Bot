using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class Converter
    {
        static Dictionary<string, int> numbertable = new Dictionary<string, int> { {"zero",0 }, { "one", 1 }, { "two", 2 }, { "to", 2 }, { "three", 3 }, { "free", 3 }, { "four", 4 }, { "for", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }};
        static Dictionary<int, string> wordtable = new Dictionary<int, string> { { 0,"zero" }, { 1,"one" }, { 2,"two" }, { 3,"three" }, { 4,"four" }, { 5,"five" }, { 6,"six" }, { 7,"seven" }, { 8,"eight" }, { 9,"nine" } };
        static Dictionary<char, string> NATOTable = new Dictionary<char, string> { { 'a', "alpha" }, { 'b', "bravo" }, { 'c', "charlie" }, { 'd', "delta" }, { 'e', "echo" }, { 'f', "foxtrot" }, { 'g', "golf" }, { 'h', "hotel" }, { 'i', "india" }, { 'j', "juliet" }, { 'k', "kilo" }, { 'l', "lima" }, { 'm', "mike" }, { 'n', "november" }, { 'o', "oscar" }, { 'p', "papa" }, { 'q', "quebec" }, { 'r', "romeo" }, { 's', "sierra" }, { 't', "tango" }, { 'u', "uniform" }, { 'v', "victor" }, { 'w', "whiskey" }, { 'x', "x-ray" }, { 'y', "yankee" }, { 'z', "zulu" }, { '0', "zero" }, { '1', "one" }, { '2', "two" }, { '3', "three" }, { '4', "four" }, { '5', "five" }, { '6', "six" }, { '7', "seven" }, { '8', "eight" }, { '9', "nine" }, };
        public static int ToInt(string numberString)
        {
            int number = numbertable[numberString];
            return number;
        }

        public static string FromNATO(string nato)
        {
            return nato.Substring(0, 1);
        }

        public static string ToNATO(string str)
        {
            string finished = "";
            foreach(char letter in str)
            {
                finished += NATOTable[letter] + " ";
            }
            finished = finished.Remove(finished.Length - 1);
            return finished;
        }

        public static string fixSerial(string longSerial)
        {
            bool previousNumber = false;
            string fixedSerial = ""; 
            foreach(char letter in longSerial)
            {
                try
                {
                    if (wordtable.ContainsKey(int.Parse(letter.ToString())))
                    {
                        if (previousNumber) fixedSerial += " ";
                        fixedSerial += wordtable[int.Parse(letter.ToString())];
                        previousNumber = true;
                    }
                }catch(Exception ex)
                {
                    previousNumber = false;
                    fixedSerial += letter;
                }
            }
            return fixedSerial;
        }
    }
}
