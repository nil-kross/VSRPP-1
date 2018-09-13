using System.IO;

namespace Study.Beeping.Reader
{
    public interface IBeepStreamReader
    {
        Beep ReadBeep(Stream stream);
    }
}