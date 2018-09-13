using Study.Beeping.Beeper;
using System.Collections.Generic;
using System.IO;

namespace Study.Beeping.Writer
{
    public class BeepingWriter
        : IBeepingWriter
    {
        private IBeeper _beeper;
        private IBeepStreamWriter _beepWriter;
        private Stream _stream;

        public BeepingWriter(
            Stream stream,
            IBeeper beeper,
            IBeepStreamWriter beepWriter
        ) {
            _stream = stream;
            _beeper = beeper;
            _beepWriter = beepWriter;
        }

        public void WriteBeep(Beep @object)
        {
            _beepWriter.WriteBeep(
                _stream, 
                @object
            );
            _beeper.Beep(@object);
        }

        public void WriteBeeps(IEnumerable<Beep> beeps)
        {
            foreach (Beep beep in beeps)
            {
                _beepWriter.WriteBeep(
                    _stream,
                    beep
                );
                _beeper.Beep(beep);
            }
        }
    }
}