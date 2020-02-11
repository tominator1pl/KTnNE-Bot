using System.Collections.Generic;
using System.Linq;

namespace KTnNE_Bot
{
    class WhoFirst : Module
    {
        bool stageFirst;
        public WhoFirst()
        {
            TextSynthesizer.Speak("who's first ok display");
            Recognizer.SetContext(new List<string> {"empty", "alfa", "bravo", "charlie", "delta", "echo", "foxtrot", "golf", "hotel", "india", "juliet", "kilo", "lima", "mike", "november", "oscar", "papa", "quebec", "romeo", "sierra", "tango", "uniform", "victor", "whiskey", "x-ray", "yankee", "zulu", "question" }, 1, 7);
            stageFirst = true;
        }

        public override void Interpret(string text)
        {
            if (text == "empty")
            {
                TextSynthesizer.Speak("left three");
                stageFirst = false;
                return;
            }
            string word = "";
            List<string> longText = text.Split(' ').ToList();
            foreach (string letter in longText)
            {
                string let = Converter.FromNATO(letter);
                word += let;
            }
            if (stageFirst) {
                
                
                switch (word)
                {
                    case "yes":
                        TextSynthesizer.Speak("left two");
                        break;
                    case "first":
                        TextSynthesizer.Speak("right one");
                        break;
                    case "display":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "okay":
                        TextSynthesizer.Speak("right one");
                        break;
                    case "says":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "nothing":
                        TextSynthesizer.Speak("left two");
                        break;
                    case "blank":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "no":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "led":
                        TextSynthesizer.Speak("left two");
                        break;
                    case "lead":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "read":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "red":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "reed":
                        TextSynthesizer.Speak("left three");
                        break;
                    case "leed":
                        TextSynthesizer.Speak("left three");
                        break;
                    case "holdon":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "you":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "youare":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "your":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "youre":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "ur":
                        TextSynthesizer.Speak("left one");
                        break;
                    case "there":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "theyre":
                        TextSynthesizer.Speak("left three");
                        break;
                    case "their":
                        TextSynthesizer.Speak("right two");
                        break;
                    case "theyare":
                        TextSynthesizer.Speak("left two");
                        break;
                    case "see":
                        TextSynthesizer.Speak("right three");
                        break;
                    case "c":
                        TextSynthesizer.Speak("right one");
                        break;
                    case "cee":
                        TextSynthesizer.Speak("right three");
                        break;
                    default:
                        TextSynthesizer.Speak("again");
                        return;
                }
                stageFirst = false;
            }
            else
            {
                switch (word)
                {
                    case "ready":
                        TextSynthesizer.Speak("YES, OKAY, WHAT, MIDDLE, LEFT, PRESS, RIGHT, BLANK, READY, NO, FIRST, UHHH, NOTHING, WAIT");
                        break;
                    case "first":
                        TextSynthesizer.Speak("LEFT, OKAY, YES, MIDDLE, NO, RIGHT, NOTHING, UHHH, WAIT, READY, BLANK, WHAT, PRESS, FIRST");
                        break;
                    case "no":
                        TextSynthesizer.Speak("BLANK, UHHH, WAIT, FIRST, WHAT, READY, RIGHT, YES, NOTHING, LEFT, PRESS, OKAY, NO, MIDDLE");
                        break;
                    case "blank":
                        TextSynthesizer.Speak("WAIT, RIGHT, OKAY, MIDDLE, BLANK, PRESS, READY, NOTHING, NO, WHAT, LEFT, UHHH, YES, FIRST");
                        break;
                    case "nothing":
                        TextSynthesizer.Speak("UHHH, RIGHT, OKAY, MIDDLE, YES, BLANK, NO, PRESS, LEFT, WHAT, WAIT, FIRST, NOTHING, READY");
                        break;
                    case "yes":
                        TextSynthesizer.Speak("OKAY, RIGHT, UHHH, MIDDLE, FIRST, WHAT, PRESS, READY, NOTHING, YES, LEFT, BLANK, NO, WAIT");
                        break;
                    case "what":
                        TextSynthesizer.Speak("UHHH, WHAT, LEFT, NOTHING, READY, BLANK, MIDDLE, NO, OKAY, FIRST, WAIT, YES, PRESS, RIGHT");
                        break;
                    case "uhhh":
                        TextSynthesizer.Speak("READY, NOTHING, LEFT, WHAT, OKAY, YES, RIGHT, NO, PRESS, BLANK, UHHH, MIDDLE, WAIT, FIRST");
                        break;
                    case "left":
                        TextSynthesizer.Speak("RIGHT, LEFT, FIRST, NO, MIDDLE, YES, BLANK, WHAT, UHHH, WAIT, PRESS, READY, OKAY, NOTHING");
                        break;
                    case "right":
                        TextSynthesizer.Speak("YES, NOTHING, READY, PRESS, NO, WAIT, WHAT, RIGHT, MIDDLE, LEFT, UHHH, BLANK, OKAY, FIRST");
                        break;
                    case "middle":
                        TextSynthesizer.Speak("BLANK, READY, OKAY, WHAT, NOTHING, PRESS, NO, WAIT, LEFT, MIDDLE, RIGHT, FIRST, UHHH, YES");
                        break;
                    case "okay":
                        TextSynthesizer.Speak("MIDDLE, NO, FIRST, YES, UHHH, NOTHING, WAIT, OKAY, LEFT, READY, BLANK, PRESS, WHAT, RIGHT");
                        break;
                    case "wait":
                        TextSynthesizer.Speak("UHHH, NO, BLANK, OKAY, YES, LEFT, FIRST, PRESS, WHAT, WAIT, NOTHING, READY, RIGHT, MIDDLE");
                        break;
                    case "press":
                        TextSynthesizer.Speak("RIGHT, MIDDLE, YES, READY, PRESS, OKAY, NOTHING, UHHH, BLANK, LEFT, FIRST, WHAT, NO, WAIT");
                        break;
                    case "you":
                        TextSynthesizer.Speak("SURE, YOU alpha RE, YOU romeo, YOU romeo echo, NEXT, UH hotel UH, uniform romeo, HOLD, WHAT question, YOU, UH UH, LIKE, DONE, uniform");
                        break;
                    case "youare":
                        TextSynthesizer.Speak("YOU romeo, NEXT, LIKE, UH hotel UH, WHAT question, DONE, UH UH, HOLD, YOU, uniform, YOU romeo echo, SURE, uniform romeo, YOU alpha RE");
                        break;
                    case "your":
                        TextSynthesizer.Speak("UH UH, YOU alpha RE, UH hotel UH, YOU romeo, NEXT, uniform romeo, SURE, uniform, YOU romeo echo, YOU, WHAT question, HOLD, LIKE, DONE");
                        break;
                    case "youre":
                        TextSynthesizer.Speak("YOU, YOU romeo echo, uniform romeo, NEXT, UH UH, YOU alpha RE, uniform, YOU romeo, WHAT question, UH hotel UH, SURE, DONE, LIKE, HOLD");
                        break;
                    case "ur":
                        TextSynthesizer.Speak("DONE, uniform, uniform romeo, UH hotel UH, WHAT question, SURE, YOU romeo, HOLD, YOU romeo echo, LIKE, NEXT, UH UH, YOU alpha RE, YOU");
                        break;
                    case "u":
                        TextSynthesizer.Speak("UH hotel UH, SURE, NEXT, WHAT question, YOU romeo echo, uniform romeo, UH UH, DONE, uniform, YOU, LIKE, HOLD, YOU alpha RE, YOU romeo");
                        break;
                    case "uhhuh":
                        TextSynthesizer.Speak("UH hotel UH, YOU romeo, YOU alpha RE, YOU, DONE, HOLD, UH UH, NEXT, SURE, LIKE, YOU romeo echo, uniform romeo, uniform, WHAT question");
                        break;
                    case "uhuh":
                        TextSynthesizer.Speak("uniform romeo, uniform, YOU alpha RE, YOU romeo echo, NEXT, UH UH, DONE, YOU, UH hotel UH, LIKE, YOU romeo, SURE, HOLD, WHAT question");
                        break;
                    case "whatq":
                        TextSynthesizer.Speak("YOU, HOLD, YOU romeo echo, YOU romeo, uniform, DONE, UH UH, LIKE, YOU alpha RE, UH hotel UH, uniform romeo, NEXT, WHAT question, SURE");
                        break;
                    case "done":
                        TextSynthesizer.Speak("SURE, UH hotel UH, NEXT, WHAT question, YOU romeo, uniform romeo, YOU romeo echo, HOLD, LIKE, YOU, uniform, YOU alpha RE, UH UH, DONE");
                        break;
                    case "next":
                        TextSynthesizer.Speak("WHAT question, UH hotel UH, UH UH, YOU romeo, HOLD, SURE, NEXT, LIKE, DONE, YOU alpha RE, uniform romeo, YOU romeo echo, uniform, YOU");
                        break;
                    case "hold":
                        TextSynthesizer.Speak("YOU alpha RE, uniform, DONE, UH UH, YOU, uniform romeo, SURE, WHAT question, YOU romeo echo, NEXT, HOLD, UH hotel UH, YOU romeo, LIKE");
                        break;
                    case "sure":
                        TextSynthesizer.Speak("YOU alpha RE, DONE, LIKE, YOU romeo echo, YOU, HOLD, UH hotel UH, uniform romeo, SURE, uniform, WHAT question, NEXT, YOU romeo, UH UH");
                        break;
                    case "like":
                        TextSynthesizer.Speak("YOU romeo echo, NEXT, uniform, uniform romeo, HOLD, DONE, UH UH, WHAT question, UH hotel UH, YOU, LIKE, SURE, YOU alpha RE, YOU romeo");
                        break;
                    default:
                        TextSynthesizer.Speak("again");
                        return;
                }
                Interpreter.IdleBomb();
            }
        }
    }
}