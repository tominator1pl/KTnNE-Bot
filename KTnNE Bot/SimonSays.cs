using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class SimonSays : Module
    {
        bool serialvowel;
        public SimonSays()
        {
            TextSynthesizer.Speak("simon says ok sequence");
            Recognizer.SetContext(new List<string> { "blue", "red", "yellow", "green"}, 1, 10);
            SerialVowel();
        }

        public override void Interpret(string text)
        {
            if(!(new List<string> { "blue", "red", "yellow", "green" }.Any(text.Contains))){
                TextSynthesizer.Speak("Again");
                return;
            }
            List<string> sequence = text.Split(' ').ToList();
            string finished = "";
            foreach(string color in sequence)
            {
                if (serialvowel)
                {
                    switch (Interpreter.strikes)
                    {
                        case 0:
                            switch (color)
                            {
                                case "red":
                                    finished += "blue";
                                    break;
                                case "blue":
                                    finished += "red";
                                    break;
                                case "green":
                                    finished += "yellow";
                                    break;
                                case "yellow":
                                    finished += "green";
                                    break;
                            }
                            break;
                        case 1:
                            switch (color)
                            {
                                case "red":
                                    finished += "yellow";
                                    break;
                                case "blue":
                                    finished += "green";
                                    break;
                                case "green":
                                    finished += "blue";
                                    break;
                                case "yellow":
                                    finished += "red";
                                    break;
                            }
                            break;
                        case 2:
                            switch (color)
                            {
                                case "red":
                                    finished += "green";
                                    break;
                                case "blue":
                                    finished += "red";
                                    break;
                                case "green":
                                    finished += "yellow";
                                    break;
                                case "yellow":
                                    finished += "blue";
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    switch (Interpreter.strikes)
                    {
                        case 0:
                            switch (color)
                            {
                                case "red":
                                    finished += "blue";
                                    break;
                                case "blue":
                                    finished += "yellow";
                                    break;
                                case "green":
                                    finished += "green";
                                    break;
                                case "yellow":
                                    finished += "red";
                                    break;
                            }
                            break;
                        case 1:
                            switch (color)
                            {
                                case "red":
                                    finished += "red";
                                    break;
                                case "blue":
                                    finished += "blue";
                                    break;
                                case "green":
                                    finished += "yellow";
                                    break;
                                case "yellow":
                                    finished += "green";
                                    break;
                            }
                            break;
                        case 2:
                            switch (color)
                            {
                                case "red":
                                    finished += "yellow";
                                    break;
                                case "blue":
                                    finished += "green";
                                    break;
                                case "green":
                                    finished += "blue";
                                    break;
                                case "yellow":
                                    finished += "red";
                                    break;
                            }
                            break;
                    }
                }
                finished += " ";
            }
            TextSynthesizer.Speak(finished);
            Interpreter.IdleBomb();
        }

        void SerialVowel()
        {
            if (new List<string> { "a", "e", "i", "o", "u" }.Any(Interpreter.serialNumber.Contains))
            {
                serialvowel = true;
            }
            else
            {
                serialvowel = false;
            }
        }
    }
}