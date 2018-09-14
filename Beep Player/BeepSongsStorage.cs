using Study.Beeping;
using System.Collections.Generic;

namespace Study
{
    public static class BeepSongsStorage
    {
        private static IEnumerable<BeepSong> _beepSongsEnumerable;

        public static IEnumerable<BeepSong> BeepSongs => _beepSongsEnumerable;

        static BeepSongsStorage()
        {
            ICollection<BeepSong> beepSongs = new List<BeepSong>(); 

            { 
                var _ = new Beep(40, 50);
                var a = new Beep(300, 500);
                var b = new Beep(250, 500);
                var c = new Beep(350, 250);
                var imperialMarchSong = new BeepSong(
                    "Imperial March",
                    new List<Beep>
                    {
                        a,
                        _,
                        a,
                        _,
                        a,
                        _,
                        b,
                        _,
                        c,
                        a,
                        _,
                        b,
                        _,
                        c,
                        a,
                        _
                    }
                );

                beepSongs.Add(imperialMarchSong);
            }
            {
                var sovietAnthemSong = new BeepSong(
                    "Soviet Anthem",
                    new List<Beep>
                    {
                        new Beep(391, 200),
                        new Beep(523, 400),
                        new Beep(391, 300),
                        new Beep(440, 100),
                        new Beep(493, 400),
                        new Beep(329, 200),
                        new Beep(329, 200),
                        new Beep(440, 400),
                        new Beep(391, 300),
                        new Beep(349, 100),
                        new Beep(391, 400),
                        new Beep(261, 200),
                        new Beep(261, 200),
                        new Beep(293, 400),
                        new Beep(293, 300),
                        new Beep(329, 100),
                        new Beep(349, 400),
                        new Beep(349, 300),
                        new Beep(391, 100),
                        new Beep(440, 400),
                        new Beep(493, 200),
                        new Beep(523, 200),
                        new Beep(587, 600),
                        new Beep(391, 200),
                        new Beep(659, 400),
                        new Beep(587, 300),
                        new Beep(523, 100),
                        new Beep(587, 400),
                        new Beep(493, 200),
                        new Beep(391, 200),
                        new Beep(523, 400),
                        new Beep(493, 300),
                        new Beep(440, 100),
                        new Beep(493, 300),
                        new Beep(329, 200),
                        new Beep(329, 200),
                        new Beep(440, 400),
                        new Beep(391, 300),
                        new Beep(349, 100),
                        new Beep(391, 400),
                        new Beep(261, 300),
                        new Beep(261, 100),
                        new Beep(523, 400),
                        new Beep(493, 300),
                        new Beep(440, 100),
                        new Beep(391, 800),
                        new Beep(659, 800),
                        new Beep(587, 200),
                        new Beep(523, 200),
                        new Beep(493, 200),
                        new Beep(523, 200),
                        new Beep(587, 600),
                        new Beep(391, 200),
                        new Beep(391, 800),
                        new Beep(523, 800),
                        new Beep(493, 200),
                        new Beep(440, 200),
                        new Beep(391, 200),
                        new Beep(440, 200),
                        new Beep(493, 600),
                        new Beep(329, 200),
                        new Beep(329, 400),
                        new Beep(523, 400),
                        new Beep(440, 300),
                        new Beep(493, 100),
                        new Beep(523, 400),
                        new Beep(440, 300),
                        new Beep(493, 100),
                        new Beep(523, 400),
                        new Beep(440, 200),
                        new Beep(523, 200),
                        new Beep(698, 600),
                        new Beep(40, 200),
                        new Beep(698, 800),
                        new Beep(659, 200),
                        new Beep(587, 200),
                        new Beep(523, 200),
                        new Beep(587, 200),
                        new Beep(659, 600),
                        new Beep(523, 200),
                        new Beep(523, 800),
                        new Beep(587, 800),
                        new Beep(523, 200),
                        new Beep(493, 200),
                        new Beep(440, 200),
                        new Beep(493, 200),
                        new Beep(523, 600),
                        new Beep(440, 200),
                        new Beep(440, 800),
                        new Beep(523, 400),
                        new Beep(493, 300),
                        new Beep(440, 100),
                        new Beep(391, 400),
                        new Beep(261, 300),
                        new Beep(261, 100),
                        new Beep(523, 400),
                        new Beep(493, 440),
                        new Beep(391, 400),
                        new Beep(40, 200),
                        new Beep(391, 200),
                        new Beep(523, 400),
                        new Beep(391, 300),
                        new Beep(440, 100),
                        new Beep(493, 400),
                        new Beep(329, 200),
                        new Beep(329, 200),
                        new Beep(440, 400),
                        new Beep(391, 300),
                        new Beep(349, 100),
                        new Beep(391, 300),
                        new Beep(261, 200),
                        new Beep(261, 200),
                        new Beep(293, 400),
                        new Beep(293, 300),
                        new Beep(329, 100),
                        new Beep(349, 400),
                        new Beep(349, 300),
                        new Beep(391, 100),
                        new Beep(440, 400),
                        new Beep(493, 200),
                        new Beep(523, 200),
                        new Beep(587, 600),
                        new Beep(391, 200),
                        new Beep(659, 400),
                        new Beep(587, 300),
                        new Beep(523, 100)
                    }
                );

                beepSongs.Add(sovietAnthemSong);
            }
            _beepSongsEnumerable = beepSongs;
        }
    }
}