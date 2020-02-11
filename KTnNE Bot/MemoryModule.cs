using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class MemoryModule : Module
    {
        int stage;
        bool readPos;
        Dictionary<int, string> positions; // number,pos
        public MemoryModule()
        {
            TextSynthesizer.Speak("memory ok display");
            Recognizer.SetContext(new List<string> { "one", "two", "three", "four" }, 1, 2);
            stage = 1;
            readPos = false;
            positions = new Dictionary<int, string>();
        }

        public override void Interpret(string text)
        {
            if (readPos)
            {
                string pos = "";
                List<string> longText = text.Split(' ').ToList();
                if(longText.Count != 2)
                {
                    TextSynthesizer.Speak("again");
                    return;
                }
                foreach (string letter in longText)
                {
                    pos += Converter.ToInt(letter).ToString();
                }
                positions.Add(stage - 1, pos);
                readPos = false;
                TextSynthesizer.Speak("ok " + text+ " display");
                return;
            }
            switch (stage)
            {
                case 1:
                    switch (text)
                    {
                        case "one":
                            TextSynthesizer.Speak("position two");
                            break;
                        case "two":
                            TextSynthesizer.Speak("position two");
                            break;
                        case "three":
                            TextSynthesizer.Speak("position three");
                            break;
                        case "four":
                            TextSynthesizer.Speak("position four");
                            break;
                        default:
                            TextSynthesizer.Speak("again");
                            return;
                    }
                    stage = 2;
                    readPos = true;
                    break;
                case 2:
                    switch (text)
                    {
                        case "one":
                            TextSynthesizer.Speak("number four");
                            break;
                        case "two":
                            TextSynthesizer.Speak("position " + positions[1][1]);
                            break;
                        case "three":
                            TextSynthesizer.Speak("position one");
                            break;
                        case "four":
                            TextSynthesizer.Speak("position " + positions[1][1]);
                            break;
                        default:
                            TextSynthesizer.Speak("again");
                            return;
                    }
                    stage = 3;
                    readPos = true;
                    break;
                case 3:
                    switch (text)
                    {
                        case "one":
                            TextSynthesizer.Speak("number " + positions[2][0]);
                            break;
                        case "two":
                            TextSynthesizer.Speak("number " + positions[1][0]);
                            break;
                        case "three":
                            TextSynthesizer.Speak("position three");
                            break;
                        case "four":
                            TextSynthesizer.Speak("number four");
                            break;
                        default:
                            TextSynthesizer.Speak("again");
                            return;
                    }
                    stage = 4;
                    readPos = true;
                    break;
                case 4:
                    switch (text)
                    {
                        case "one":
                            TextSynthesizer.Speak("position " + positions[1][1]);
                            break;
                        case "two":
                            TextSynthesizer.Speak("position one");
                            break;
                        case "three":
                            TextSynthesizer.Speak("position " + positions[2][1]);
                            break;
                        case "four":
                            TextSynthesizer.Speak("position " + positions[2][1]);
                            break;
                        default:
                            TextSynthesizer.Speak("again");
                            return;
                    }
                    stage = 5;
                    readPos = true;
                    break;
                case 5:
                    switch (text)
                    {
                        case "one":
                            TextSynthesizer.Speak("number " + positions[1][0]);
                            break;
                        case "two":
                            TextSynthesizer.Speak("number " + positions[2][0]);
                            break;
                        case "three":
                            TextSynthesizer.Speak("number " + positions[4][0]);
                            break;
                        case "four":
                            TextSynthesizer.Speak("number " + positions[3][0]);
                            break;
                        default:
                            TextSynthesizer.Speak("again");
                            return;
                    }
                    Interpreter.IdleBomb();
                    break;
            }
        }
    }
}