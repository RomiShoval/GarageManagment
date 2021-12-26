using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class FormatException : Exception
    {
        public FormatException(string i_Message) : base(i_Message) { }

        public FormatException(int i_Start, int i_End) : base($"Input must be in range between {i_Start} to {i_End}") { }
    }
}
