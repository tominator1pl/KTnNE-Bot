using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class PasswordModule : Module
    {
        List<string> words = new List<string> {
            "about", "after", "again", "below", "could",
            "every", "first", "found", "great", "house",
            "large", "learn", "never", "other", "place",
            "plant", "point", "right", "small", "sound",
            "spell", "still", "study", "their", "there",
            "these", "thing", "think", "three", "water",
            "where", "which", "world", "would", "write"};
        string[] letters = new string[5];
        int letter = 0;
        public PasswordModule()
        {
            TextSynthesizer.Speak("password ok one");
            Recognizer.SetContext(new List<string> {"alfa", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet", "kilo", "lima", "mike", "november", "oscar", "papa", "quebec", "romeo", "sierra", "tango", "uniform", "victor", "whiskey", "x-ray", "yankee", "zulu"}, 6, 6);
        }

        public override void Interpret(string text)
        {
            string word = "";
            List<string> longText = text.Split(' ').ToList();
            foreach (string letter in longText)
            {
                string let = Converter.FromNATO(letter);
                word += let;
            }
            if(word.Length != 6)
            {
                TextSynthesizer.Speak("again");
                return;
            }
            letter++;
            if(letter >= 6)
            {
                TextSynthesizer.Speak("word not found");
                Interpreter.IdleBomb();
                return;
            }
            letters[letter - 1] = word;
            List<string> correctWords = new List<string>(words);
            foreach(string wor in words)
            {
                for(int i = 0; i < letters.Length; i++)
                {
                    if(letters[i] == null)
                    {
                        continue;
                    }
                    if (!letters[i].Contains(wor[i]))
                    {
                        correctWords.Remove(wor);
                    }
                }
            }
            if(correctWords.Count == 1)
            {
                TextSynthesizer.Speak(correctWords.First() + ", " + string.Join(", ", Converter.ToNATO(correctWords.First()).Split(' ')));
                Interpreter.IdleBomb();
            }
            else
            {
                TextSynthesizer.Speak("ok" + (letter + 1));
            }
        }
    }
}