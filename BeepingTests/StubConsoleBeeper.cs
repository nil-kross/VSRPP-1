using Study.Beeping;
using Study.Beeping.Beeper;
using System;

namespace BeepingTests
{
    public class StubConsoleBeeper
        : IBeeper
    {
        public void Beep(Beep beep)
        {
            Console.WriteLine("Beep!");
        }
    }
}