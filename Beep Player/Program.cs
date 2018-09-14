using BeepingTests;
using Study.Beeping;
using Study.Beeping.Beeper;
using Study.Beeping.Reader;
using Study.Beeping.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Study
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBeepPlayer player = new BeepPlayer();
        }
    }
}