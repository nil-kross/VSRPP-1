using System.Collections.Generic;

namespace Study.Beeping.Reader
{
    public interface IBeepingReader
    {
        Beep ReadBeep();

        IEnumerable<Beep> ReadBeeps();
    }
}