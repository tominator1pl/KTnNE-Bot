using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class MorseModule : Module
    {
        List<string> letters;
        Dictionary<string, string> words = new Dictionary<string, string> { {"shell", "3505"}, { "halls", "3515" }, { "slick", "3522" }, { "trick", "3532" }, { "boxes", "3535" }, { "leaks", "3542" }, { "strobe", "3545" }, { "bistro", "3552" }, { "flick", "3555" }, { "bombs", "3565" }, { "break", "3572" }, { "brick", "3575" }, { "steak", "3582" }, { "sting", "3592" }, { "vector", "3595" }, { "beats", "3600" } };
        public MorseModule()
        {
            TextSynthesizer.Speak("morse ok");
            Recognizer.SetContext(new List<string> { "short", "long", "reset" }, 1, 4);
            letters = new List<string>();
        }

        public override void Interpret(string text)
        {
            if(text == "reset")
            {
                letters = new List<string>();
                TextSynthesizer.Speak("reset");
                return;
            }
            string letter = FromMorse(text);
            if(letter == "er")
            {
                TextSynthesizer.Speak("again");
                return;
            }
            letters.Add(letter);
            TextSynthesizer.Speak(text);
            if(letters.Count == 5 || letters.Count == 6)
            {
                foreach(KeyValuePair<string, string> word in words)
                {
                    List<string> wor = word.Key.Select(c => c.ToString()).ToList();
                    if (areAnagram(letters,wor))
                    {
                        TextSynthesizer.Speak(Converter.ToNATO(word.Value));
                        Interpreter.IdleBomb();
                        return;
                    }
                }
            }
            if(letters.Count > 6)
            { 
                TextSynthesizer.Speak("too many letters");
            }
        }

        string FromMorse(string morse)
        {
            switch (morse)
            {
                case "short long":
                    return "a";
                case "long short short short":
                    return "b";
                case "long short long short":
                    return "c";
                case "long short short":
                    return "d";
                case "short":
                    return "e";
                case "short short long short":
                    return "f";
                case "long long short":
                    return "g";
                case "short short short short":
                    return "h";
                case "short short":
                    return "i";
                case "short long long long":
                    return "j";
                case "long short long":
                    return "k";
                case "short long short short":
                    return "l";
                case "long long":
                    return "m";
                case "long short":
                    return "n";
                case "long long long":
                    return "o";
                case "short long long short":
                    return "p";
                case "long long short long":
                    return "q";
                case "short long short":
                    return "r";
                case "short short short":
                    return "s";
                case "long":
                    return "t";
                case "short short long":
                    return "u";
                case "short short short long":
                    return "v";
                case "short long long":
                    return "w";
                case "long short short long":
                    return "x";
                case "long short long long":
                    return "y";
                case "long long short short":
                    return "z";
                default:
                    return "er";

            }
        }

        bool areAnagram(List<string> str1, List<string> str2)
        {
            // Get lenghts of both strings 
            int n1 = str1.Count;
            int n2 = str2.Count;

            // If length of both strings is not 
            // same, then they cannot be anagram 
            if (n1 != n2)
            {
                return false;
            }

            // Sort both strings 
            str1.Sort();
            str2.Sort();

            // Compare sorted strings 
            for (int i = 0; i < n1; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}