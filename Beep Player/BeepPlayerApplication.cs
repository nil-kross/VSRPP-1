using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study
{
    public class ConsoleBeepPlayerDialog
        : IBeepPlayerDialog
    {
        public Task Task => new Task(() => { this.DoLogic(); });

        protected void DoLogic()
        {
            var optionValue = 0;
            var isDone = false;
            IBeepPlayer player = new BeepPlayer();
            IEnumerable<BeepSong> beepSongsEnumerable = BeepSongsStorage.BeepSongs;

            while (!isDone)
            {
                var optionsAmount = 0;
                ConsoleKeyInfo keyInfo;
                Func<Int32, String, String> optionFormatterDelegate = (Int32 i, String optionString) =>
                {
                    var kek = String.Format(
                        "\t {0} {1}.",
                        i == optionValue ? ">" : " ",
                        optionString
                    );

                    return kek;
                };
                ICollection<String> optionsStringCollection = new List<String>();
                Action updateOptionStringDelegate = () =>
                {
                    var i = 0;
                    optionsStringCollection.Add(optionFormatterDelegate(0, "Exit"));

                    foreach (var song in beepSongsEnumerable)
                    {
                        optionsStringCollection.Add(
                            optionFormatterDelegate(
                                ++i,
                                String.Format(
                                    "<<{0}>>",
                                    song.Name
                                )
                            )
                        );
                    }
                    optionsAmount = optionsStringCollection.Count();
                };

                updateOptionStringDelegate();
                Console.Clear();
                Console.WriteLine(
                    "\n\r" +
                    "\t\tSelect song to play:\n\r" +
                    "\n\r"
                );
                foreach (var optionString in optionsStringCollection)
                {
                    Console.WriteLine(optionString);
                }
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        optionValue--;
                        if (optionValue < 0)
                        {
                            optionValue = optionsAmount - 1;
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        optionValue++;
                        if (optionValue >= optionsAmount)
                        {
                            optionValue = 0;
                        }
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Enter ||
                    keyInfo.Key == ConsoleKey.Spacebar
                )
                {
                    if (optionValue == 0)
                    {
                        isDone = true;
                    }
                    else
                    {
                        BeepSong song = beepSongsEnumerable.ToArray()[optionValue - 1];

                        Console.Clear();
                        Console.WriteLine(String.Format("Now playing <<{0}>>..", song.Name));
                        player.Play(song);
                    }
                }
            }
        }
    }
}