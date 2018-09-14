using Study.Beeping;
using Study.Beeping.Beeper;
using Study.Beeping.Writer;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Study
{
    public class BeepPlayer
        : IBeepPlayer
    {
        public void Play(IEnumerable<Beep> beeps)
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new ConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(stream, beeper, streamWriter);

            writer.WriteBeeps(beeps);
            stream.Dispose();
        }

        public async Task PlayAsync(IEnumerable<Beep> beeps)
        {
            this.Play(beeps);
        }
    }
}
