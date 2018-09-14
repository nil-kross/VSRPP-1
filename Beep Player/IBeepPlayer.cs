using Study.Beeping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study
{
    public interface IBeepPlayer
    {
        void Play(BeepSong beepSong);

        Task PlayAsync(BeepSong beepSong);
    }
}