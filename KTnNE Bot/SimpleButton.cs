using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class SimpleButton : Module
    {
        public SimpleButton()
        {
            TextSynthesizer.Speak("button ok");
        }

        public override void Interpret(string text)
        {
            
        }
    }
}
