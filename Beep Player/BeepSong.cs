using Study.Beeping;
using System;
using System.Collections.Generic;

namespace Study
{
    public struct BeepSong
    {
        private String _nameString;
        private IEnumerable<Beep> _beepsEnumerable;

        public String Name => _nameString;
        public IEnumerable<Beep> Beeps => _beepsEnumerable;

        public BeepSong(
            String name,
            IEnumerable<Beep> beeps
        ) {
            _nameString = name;
            _beepsEnumerable = beeps;
        }
    }
}