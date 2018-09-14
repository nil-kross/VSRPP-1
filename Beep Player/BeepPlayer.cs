using Study.Beeping.Beeper;
using Study.Beeping.Writer;
using System.IO;
using System.Threading.Tasks;

namespace Study
{
    public class BeepPlayer
        : IBeepPlayer
    {
        public void Play(BeepSong beepSong)
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new ConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(stream, beeper, streamWriter);

            writer.WriteBeeps(beepSong.Beeps);
            stream.Dispose();
        }

        public async Task PlayAsync(BeepSong beepSong)
        {
            this.Play(beepSong);
        }
    }
}
