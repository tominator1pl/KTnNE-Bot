using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class SimpleWires : Module
    {

        List<string> colors;
        public SimpleWires()
        {
            TextSynthesizer.Speak("wires ok sequence");
            Recognizer.SetContext(new List<string> { "blue", "red", "yellow", "white", "black"});
        }
        public override void Interpret(string text)
        {
            colors = text.Split(' ').ToList();
            foreach (string color in colors) // check colors
            {
                if (!(new List<string> { "blue", "red", "yellow", "white", "black" }.Any(color.Contains)))
                {
                    TextSynthesizer.Speak("again");
                    return;
                }
            }
            TextSynthesizer.Speak(string.Join(" ", colors.ToArray())+ " ok");
            switch (colors.Count)
            {
                case 3:
                    ThreeWires();
                    break;
                case 4:
                    FourWires();
                    break;
                case 5:
                    FiveWires();
                    break;
                case 6:
                    SixWires();
                    break;
                default:
                    TextSynthesizer.Speak("again");
                    return;
            }
        }

        private void ThreeWires()
        {
            if (!colors.Contains("red"))
            {
                TextSynthesizer.Speak("second wire");
            }else if(colors.Last() == "white")
            {
                TextSynthesizer.Speak("last wire");
            }else if(colors.Count(x => x.Contains("blue")) > 1) //if there is more than one blu wire
            {
                int num = (colors.LastIndexOf("blue") + 1); //last blue wire

                TextSynthesizer.Speak(num.ToOrdinalWords() + " wire");
            }
            else
            {
                TextSynthesizer.Speak("last wire");
            }
            Interpreter.IdleBomb();
        }

        private void FourWires()
        {
            if(colors.Count(x => x.Contains("red")) > 1 && (int.Parse(Interpreter.serialNumber[5].ToString()) % 2 == 1)) //more than one red and if last(5) digit of sn is odd
            {
                int num = (colors.LastIndexOf("red") + 1);
                TextSynthesizer.Speak(num.ToOrdinalWords() + " wire");
            }else if(colors.Last() == "yellow" && colors.Count(x => x.Contains("red")) == 0)
            {
                TextSynthesizer.Speak("first wire");
            }else if(colors.Count(x => x.Contains("blue")) == 1)
            {
                TextSynthesizer.Speak("first wire");
            }else if(colors.Count(x => x.Contains("yellow")) > 1)
            {
                TextSynthesizer.Speak("last wire");
            }
            else
            {
                TextSynthesizer.Speak("second wire");
            }
            Interpreter.IdleBomb();
        }

        private void FiveWires()
        {
            if(colors.Last() == "black" && (int.Parse(Interpreter.serialNumber[5].ToString()) % 2 == 1))
            {
                TextSynthesizer.Speak("fourth wire");
            }else if(colors.Count(x => x.Contains("red")) == 1 && colors.Count(x => x.Contains("yellow")) > 1)
            {
                TextSynthesizer.Speak("first wire");
            }else if(colors.Count(x => x.Contains("black")) == 0)
            {
                TextSynthesizer.Speak("second wire");
            }
            else
            {
                TextSynthesizer.Speak("first wire");
            }
            Interpreter.IdleBomb();
        }

        private void SixWires()
        {
            if(colors.Count(x => x.Contains("yellow")) == 0 && (int.Parse(Interpreter.serialNumber[5].ToString()) % 2 == 1))
            {
                TextSynthesizer.Speak("third wire");
            }else if(colors.Count(x => x.Contains("yellow")) == 1 && colors.Count(x => x.Contains("white")) > 1)
            {
                TextSynthesizer.Speak("fourth wire");
            }else if(colors.Count(x => x.Contains("red")) == 0)
            {
                TextSynthesizer.Speak("last wire");
            }
            else
            {
                TextSynthesizer.Speak("fourth wire");
            }
            Interpreter.IdleBomb();
        }   
    }
}
