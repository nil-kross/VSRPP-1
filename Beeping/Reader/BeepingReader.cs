using Study.Beeping.Beeper;
using System.Collections.Generic;
using System.IO;

namespace Study.Beeping.Reader
{
    public class BeepingReader
        : IBeepingReader
    {
        private IBeeper _beeper;
        private IBeepStreamReader _beepReader;
        private Stream _stream;

        public BeepingReader(
            Stream stream,
            IBeeper beeper,
            IBeepStreamReader beepReader
        ) {
            _beeper = beeper;
            _beepReader = beepReader;
            _stream = stream;

            _stream.Position = 0;
        }

        public Beep ReadBeep()
        {
            Beep beep = _beepReader.ReadBeep(_stream);

            _beeper.Beep(beep);

            return beep;
        }

        public IEnumerable<Beep> ReadBeeps()
        {
            List<Beep> beeps = new List<Beep>();
            Beep beep = null;

            do
            {
                beep = _beepReader.ReadBeep(_stream);
                if (beep != null)
                {
                    beeps.Add(beep);
                    _beeper.Beep(beep);
                }
            }
            while (beep != null);

            return beeps;
        } 
    }
}