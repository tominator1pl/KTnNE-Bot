using System;
using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    internal class Keypad : Module
    {
        private Dictionary<int, List<string>> columns;
        public Keypad()
        {
            columns = new Dictionary<int, List<string>>();
            TextSynthesizer.Speak("keypad ok sequence"); //sequence check keypad chars.png
            GoogleSpeech.SetContext(new List<string> { "quebec", "alfa", "alpha", "lamp", "potter", "aliens", "hotel","delta","echo","six","papa","wave","empty","full","question","copyright","whiskey","bravo","x-ray","romeo","face","three","free","charlie","puzzle","letter","candlebra","november","omega" });

            columns[0] = new List<string> { "quebec", "alfa", "lamp", "potter", "aliens", "hotel", "delta" };
            columns[1] = new List<string> { "echo", "quebec", "delta", "wave", "empty", "hotel", "question" };
            columns[2] = new List<string> { "copyright", "whiskey", "wave", "x-ray", "romeo", "lamp", "empty" };
            columns[3] = new List<string> { "six", "papa", "bravo", "aliens", "x-ray", "question", "face" };
            columns[4] = new List<string> { "candlebra", "face", "bravo", "charlie", "papa", "three", "full" };
            columns[5] = new List<string> { "six", "echo", "puzzle", "letter", "candlebra", "november", "omega" };
            columns[6] = new List<string> { "quebec", "alpha", "lambda", "potter", "alien", "hotel", "delta" }; //variants speech
            columns[7] = new List<string> { "candlebra", "face", "bravo", "charlie", "papa", "free", "full" };
        }
        public override void Interpret(string text)
        {
            text = Converter.fixSerial(text);
            List<string> sequence = text.Split(' ').ToList();
            if(sequence.Count != 4)
            {
                TextSynthesizer.Speak("again");
                return;
            }
            for(int i = 0; i < columns.Count; i++)
            {
                if (columns[i].ContainsAllItems(sequence)){
                    ColumnFound(sequence, columns[i]);
                    return;
                }
            }
            TextSynthesizer.Speak("again");
        }

        public void ColumnFound(List<string> sequence, List<string> column)
        {
            SortedDictionary<int, string> ordered = new SortedDictionary<int, string>();
            foreach(string seq in sequence)
            {
                int curPos = column.IndexOf(seq);
                ordered[curPos] = seq;
            }
            string finished = "";
            foreach(KeyValuePair<int,string> letter in ordered)
            {
                finished += letter.Value + " ";
            }
            TextSynthesizer.Speak(finished);
            Interpreter.IdleBomb();
        }
    }
}