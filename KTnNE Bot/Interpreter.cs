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
        public static int strikes = 0;

        public enum Modes {
            start = 0,
            bomb = 1,
            module = 2

        };

        public Interpreter()
        {
            labels = new Dictionary<string, bool>();
            Recognizer.SetContext(new List<string>{"simple button","simple wires","bomb setup", "new bomb", "keypad", "simon says", "first" },1,1);
        }

        public static void IdleBomb()
        {
            mode = Modes.start;
            Recognizer.SetContext(new List<string> { "simple button", "simple wires", "bomb setup", "new bomb", "keypad", "simon says", "first" }, 1, 1);
        }

        internal void Interpret(string response)
        {
            response = response.ToLower();
            if (response == "stop")
            {
                TextSynthesizer.Stop();
                return;
            }
            if(response == "strike")
            {
                strikes++;
                if(strikes >= 3)
                {
                    strikes = 0;
                    TextSynthesizer.Speak("strikes reset");
                }
                TextSynthesizer.Speak(strikes + " strikes");
                return;
            }
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
                        case "simon says":
                            mode = Modes.module;
                            currentModule = new SimonSays();
                            break;
                        case "bomb setup":
                            mode = Modes.module;
                            currentModule = new BombCheck();
                            break;
                        case "first":
                            mode = Modes.module;
                            currentModule = new WhoFirst();
                            break;
                        case "new bomb":
                            mode = Modes.start;
                            labels = new Dictionary<string, bool>();
                            batteries = 0;
                            strikes = 0;
                            serialNumber = "";
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
