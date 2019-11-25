using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class Interpreter
    {
        Modes mode = Modes.start;
        Module currentModule;

        public enum Modes {
            start = 0,
            bomb = 1,
            module = 2

        };

        public Interpreter()
        {
            GoogleSpeech.SetContext(new List<string>{"simple button","simple wires"});
        }

        internal void Interpret(string response)
        {
            switch (mode)
            {
                case Modes.start:
                    switch (response)
                    {
                        case "simple button":
                            currentModule = new SimpleButton();
                            break;
                        case "simple wires":
                            TextSynthesizer.Speak("wires ok");
                            break;
                        default:
                            TextSynthesizer.Speak("Again");
                            break;
                    }
                    break;
                case Modes.module:
                    currentModule.Interpret(response);
                    break;
            }

        }
    }
}
