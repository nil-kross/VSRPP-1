using System.IO;

namespace Study.Beeping.Writer
{
    public interface IBeepStreamWriter
    {
        void WriteBeep(
            Stream stream,
            Beep beep
        );
    }
}