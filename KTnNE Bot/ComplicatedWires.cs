using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class ComplicatedWires : Module
    {
        public ComplicatedWires()
        {
            TextSynthesizer.Speak("complicated wires ok color");
            Recognizer.SetContext(new List<string> { "light", "red", "blue", "star", "empty"}, 1, 4);
        }

        public override void Interpret(string text)
        {
            if(text == "empty")
            {
                Cut();
                return;
            }
            List<string> longText = text.Split(' ').ToList();
            bool red = longText.Contains("red");
            bool blue = longText.Contains("blue");
            bool star = longText.Contains("star");
            bool led = longText.Contains("light");
            if (red)
            {
                if (blue)
                {
                    if (star)
                    {
                        if (led)
                        {
                            DontCut();
                        }
                        else
                        {
                            Parallel();
                        }
                    }
                    else
                    {
                        if (led)
                        {
                            Even();
                        }
                        else
                        {
                            Even();
                        }
                    }
                }
                else
                {
                    if (star)
                    {
                        if (led)
                        {
                            Batteries();
                        }
                        else
                        {
                            Cut();
                        }
                    }
                    else
                    {
                        if (led)
                        {
                            Batteries();
                        }
                        else
                        {
                            Even();
                        }
                    }
                }
            }
            else
            {
                if (blue)
                {
                    if (star)
                    {
                        if (led)
                        {
                            Parallel();
                        }
                        else
                        {
                            DontCut();
                        }
                    }
                    else
                    {
                        if (led)
                        {
                            Parallel();
                        }
                        else
                        {
                            Even();
                        }
                    }
                }
                else
                {
                    if (star)
                    {
                        if (led)
                        {
                            Batteries();
                        }
                        else
                        {
                            Cut();
                        }
                    }
                    else
                    {
                        if (led)
                        {
                            DontCut();
                        }
                        else
                        {
                            TextSynthesizer.Speak("Again");
                        }
                    }
                }
            }

        }

        void Cut()
        {
            TextSynthesizer.Speak("Cut");
        }
        void DontCut()
        {
            TextSynthesizer.Speak("Don't");
        }
        void Even()
        {
            if (Converter.isSerialLastEven())
            {
                TextSynthesizer.Speak("Cut");
            }
            else
            {
                TextSynthesizer.Speak("Don't");
            }
        }
        void Parallel()
        {
            if (Interpreter.parraler)
            {
                TextSynthesizer.Speak("Cut");
            }
            else
            {
                TextSynthesizer.Speak("Don't");
            }
        }
        void Batteries()
        {
            if (Interpreter.batteries >= 2)
            {
                TextSynthesizer.Speak("Cut");
            }
            else
            {
                TextSynthesizer.Speak("Don't");
            }
        }
    }
}