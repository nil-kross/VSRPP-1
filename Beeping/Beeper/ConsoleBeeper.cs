using System;

namespace Study.Beeping.Beeper
{
    public class ConsoleBeeper
        : IBeeper
    {
        public void Beep(Beep beep)
        {
            Console.Beep(
                beep.Frequency,
                beep.Duration
            );
        }
    }
}