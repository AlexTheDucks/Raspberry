using System;
using System.Collections.Generic;
using System.Text;

namespace SW04_Explorer700
{
    public class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(Keys keys)
        {
            Keys = keys;
        }

        public Keys Keys { get; }
    }
}
