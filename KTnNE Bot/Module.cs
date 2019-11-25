using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    abstract class Module
    {
        public abstract void Interpret(string text);
    }
}
