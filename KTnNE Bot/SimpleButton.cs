using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class SimpleButton : Module
    {
        bool colorlabel;
        bool colorb;
        string color;
        string label;

        public SimpleButton()
        {
            TextSynthesizer.Speak("button ok color");
            Recognizer.SetContext(new List<string> { "blue", "red", "yellow", "white", "abort", "hold", "detonate", "press" });
            colorlabel = true;
            colorb = true;
        }

        public override void Interpret(string text)
        {
            if(colorlabel)
            {
                if (colorb)
                {
                    if (new List<string> { "blue", "red", "yellow", "white" }.Any(text.Contains))
                    {
                        color = text;
                        colorb = false;
                        TextSynthesizer.Speak("ok label");
                    }
                    else
                    {
                        TextSynthesizer.Speak("again");
                    }
                }
                else
                {
                    if (new List<string> { "abort", "hold", "detonate", "press" }.Any(text.Contains))
                    {
                        
                        label = text;
                        TextSynthesizer.Speak(color + " " + label + " ok");
                        colorb = true;
                        ButtonLogic();
                    }
                    else
                    {
                        TextSynthesizer.Speak("again");
                    }
                }

            }
            else
            {
                if(new List<string> { "blue", "red", "yellow", "white" }.Any(text.Contains))
                {
                    switch (text)
                    {
                        case "blue":
                            TextSynthesizer.Speak("4 in any position");
                            break;
                        case "white":
                            TextSynthesizer.Speak("1 in any position");
                            break;
                        case "yellow":
                            TextSynthesizer.Speak("5 in any position");
                            break;
                        case "red":
                            TextSynthesizer.Speak("1 in any position");
                            break;
                    }
                    Interpreter.IdleBomb();
                }
                else
                {
                    TextSynthesizer.Speak("again");
                }
            }
        }

        void ButtonLogic()
        {
            if (color == "blue" && label == "abort")
            {
                HoldButton();
            }
            else if (Interpreter.batteries > 1 && label == "detonate")
            {
                PressButton();
            }
            else if (color == "white" && Interpreter.labels.ContainsKey("car") && Interpreter.labels["car"])
            {
                HoldButton();
            }
            else if (Interpreter.batteries > 2 && Interpreter.labels.ContainsKey("frk") && Interpreter.labels["frk"])
            {
                PressButton();
            }else if(color == "yellow")
            {
                HoldButton();
            }else if(color == "red" && label == "hold")
            {
                PressButton();
            }
            else
            {
                HoldButton();
            }
        }

        void HoldButton()
        {
            TextSynthesizer.Speak("hold button");
            colorlabel = false;
        }

        void PressButton()
        {
            TextSynthesizer.Speak("press button");
            colorlabel = true;
            Interpreter.IdleBomb();
        }
    }
}
