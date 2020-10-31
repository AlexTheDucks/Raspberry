using System;
using System.Collections.Generic;
using System.Text;

namespace SchaereSteiPapier
{
    class AIOponent
    {
        Random rand = new Random();
        public Auswahl yourTurn()
        {
           return (Auswahl)rand.Next(3);
        }
    }
}
