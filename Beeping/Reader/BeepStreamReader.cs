using System;
using System.IO;

namespace Study.Beeping.Reader
{
    public class BeepStreamReader
        : IBeepStreamReader
    {
        class BytesBlock
        {
            
        }

        public Beep ReadBeep(Stream stream)
        {
            Beep beep = null;
            Byte bytesAmount = 16 / 8;
            Int32 frequencyBlockCode = 1;
            Int32 durationBlockCode = 1;
            Byte[] frequencyBytes = new Byte[bytesAmount];
            Byte[] durationBytes = new Byte[bytesAmount];

            frequencyBlockCode = stream.Read(
                frequencyBytes,
                0,
                bytesAmount
            );
            durationBlockCode = stream.Read(
                durationBytes,
                0,
                bytesAmount
            );

            if (
                frequencyBlockCode != 0 &&
                durationBlockCode != 0
            ) {
                beep = new Beep(
                    BitConverter.ToUInt16(frequencyBytes, 0),
                    BitConverter.ToUInt16(durationBytes, 0)
                );
            }

            return beep;
        }
    }
}