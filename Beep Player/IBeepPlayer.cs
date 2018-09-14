using Study.Beeping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Study
{
    public interface IBeepPlayer
    {
        void Play(IEnumerable<Beep> beeps);

        Task PlayAsync(IEnumerable<Beep> beeps);
    }
}