using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class BombCheck : Module
    {
        public BombCheck()
        {
            GoogleSpeech.SetContext(new List<string> { "snd", "clr", "car", "ind","frq","sig","nsa","msa","trn","bob","frk","on","off","batteries","zero", "one","two","more", "finish" });
            TextSynthesizer.Speak("bomb check ok");
        }
        public override void Interpret(string text)
        {
            text = text.ToLower();
            if(new List<string> { "snd", "clr", "car", "ind", "frq", "sig", "nsa", "msa", "trn", "bob", "frk" }.Any(text.Contains))
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
    }
}
