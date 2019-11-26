using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class Interpreter
    {
        public static Modes mode = Modes.start;
        Module currentModule;
        public static Dictionary<string, bool> labels;
        public static int batteries = 0;

        public enum Modes {
            start = 0,
            bomb = 1,
            module = 2

        };

        public Interpreter()
        {
            labels = new Dictionary<string, bool>();
            GoogleSpeech.SetContext(new List<string>{"simple button","simple wires","bomb check", "new bomb"});
        }

        public static void IdleBomb()
        {
            mode = Modes.start;
            GoogleSpeech.SetContext(new List<string> { "simple button", "simple wires", "bomb check", "new bomb" });
        }

        internal void Interpret(string response)
        {
            switch (mode)
            {
                case Modes.start:
                    switch (response.ToLower())
                    {
                        case "simple button":
                            mode = Modes.module;
                            currentModule = new SimpleButton();
                            break;
                        case "simple wires":
                            TextSynthesizer.Speak("wires ok");
                            break;
                        case "bomb check":
                            mode = Modes.module;
                            currentModule = new BombCheck();
                            break;
                        case "new bomb":
                            mode = Modes.start;
                            labels = new Dictionary<string, bool>();
                            batteries = 0;
                            TextSynthesizer.Speak("new bomb");
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
