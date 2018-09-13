using System;
using System.IO;

namespace Study.Beeping.Writer
{
    public class BeepStreamWriter
        : IBeepStreamWriter
    {
        public void WriteBeep(
            Stream stream, 
            Beep beep
        ) {
            Byte bytesAmount = 16 / 8;
            byte[] frequencyBytes = BitConverter.GetBytes(beep.Frequency);
            byte[] durationBytes = BitConverter.GetBytes(beep.Duration);

            stream.Write(
                frequencyBytes, 
                0,
                bytesAmount
            );
            stream.Write(
                durationBytes, 
                0,
                bytesAmount
            );
        }
    }
}