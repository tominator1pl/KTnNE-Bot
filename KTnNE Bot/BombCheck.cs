using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class BombCheck : Module
    {
        bool serialnumber = false;
        public BombCheck()
        {
            Recognizer.SetContext(new List<string> { "snd", "clr", "car", "ind","frq","sig","nsa","msa","trn","bob","frk","on","off","batteries","zero", "one","two","more", "finish", "number" },1,2);
            TextSynthesizer.Speak("bomb setup ok");
        }
        public override void Interpret(string text)
        {
            if (serialnumber)
            {
                SerialNumber(text);
                return;
            }
            if(new List<string> { "snd", "clr", "car", "ind", "frq", "sig", "nsa", "msa", "trn", "bob", "frk" }.Any(text.Contains) && new List<string> { "on", "off", "of" }.Any(text.Contains))
            {
                if (text.Split(' ')[1] == "off" || text.Split(' ')[1] == "of")
                {
                    Interpreter.labels[text.Split(' ')[0]] = false;
                    TextSynthesizer.Speak(text.Split(' ')[0] + " off");
                }
                else if(text.Split(' ')[1] == "on")
                {
                    Interpreter.labels[text.Split(' ')[0]] = true;
                    TextSynthesizer.Speak(text.Split(' ')[0] + " on");
                }
                else
                {
                    TextSynthesizer.Speak("again");
                }

            }else
            if (text.Contains("batteries "))
            {
                switch(text.Split(' ')[1])
                {
                    case "zero":
                        Interpreter.batteries = 0;
                        break;
                    case "one":
                        Interpreter.batteries = 1;
                        break;
                    case "two":
                        Interpreter.batteries = 2;
                        break;
                    case "to":
                        Interpreter.batteries = 2;
                        break;
                    case "more":
                        Interpreter.batteries = 3;
                        break;
                    default:
                        TextSynthesizer.Speak("again");
                        break;
                }
                TextSynthesizer.Speak("batteries "+ Interpreter.batteries);
            }else if(text.Contains("number"))
            {
                TextSynthesizer.Speak("serial number ok");
                Recognizer.SetContext(new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "alfa", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet", "kilo", "lima", "mike", "november", "oscar", "papa", "quebec", "romeo", "sierra", "tango", "uniform", "victor", "whiskey", "x-ray", "yankee", "zulu" }, 6, 6);
                serialnumber = true;
            }
            else
            if (text.Contains("finish"))
            {
                Interpreter.IdleBomb();
                TextSynthesizer.Speak("finished");
            }
            else
            {
                TextSynthesizer.Speak("again");
            }
        }

        private void SerialNumber(string text)
        {
            text = Converter.fixSerial(text);
            string serial = "";
            List<string> longSerial = text.Split(' ').ToList();
            foreach(string letter in longSerial)
            {
                try
                {
                    int i = Converter.ToInt(letter);
                    serial += i;
                }catch(Exception ex)
                {
                    string let = Converter.FromNATO(letter);
                    serial += let;
                }
            }
            if(serial.Length != 6)
            {
                TextSynthesizer.Speak("again");
                return;
            }
            TextSynthesizer.Speak(Converter.ToNATO(serial));
            Interpreter.serialNumber = serial;
            Recognizer.SetContext(new List<string> { "snd", "clr", "car", "ind", "frq", "sig", "nsa", "msa", "trn", "bob", "frk", "on", "off", "batteries", "zero", "one", "two", "more", "finish", "number" }, 1, 2);
            serialnumber = false;
        }
    }
}
