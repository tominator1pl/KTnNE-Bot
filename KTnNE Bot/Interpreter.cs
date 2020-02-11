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
        public static string serialNumber;

        public enum Modes {
            start = 0,
            bomb = 1,
            module = 2

        };

        public Interpreter()
        {
            labels = new Dictionary<string, bool>();
            Recognizer.SetContext(new List<string>{"simple button","simple wires","bomb setup", "new bomb", "keypad"});
        }

        public static void IdleBomb()
        {
            mode = Modes.start;
            Recognizer.SetContext(new List<string> { "simple button", "simple wires", "bomb setup", "new bomb", "keypad"});
        }

        internal void Interpret(string response)
        {
            response = response.ToLower();
            switch (mode)
            {
                case Modes.start:
                    switch (response)
                    {
                        case "simple button":
                            mode = Modes.module;
                            currentModule = new SimpleButton();
                            break;
                        case "simple wires":
                            mode = Modes.module;
                            currentModule = new SimpleWires();
                            break;
                        case "keypad":
                            mode = Modes.module;
                            currentModule = new Keypad();
                            break;
                        case "bomb setup":
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
