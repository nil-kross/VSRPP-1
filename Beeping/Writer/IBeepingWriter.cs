using System.Collections.Generic;

namespace Study.Beeping.Writer
{
    public interface IBeepingWriter
    {
        void WriteBeep(Beep @object);

        void WriteBeeps(IEnumerable<Beep> beeps);
    }
}