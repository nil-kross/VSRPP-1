using BeepingTests;
using Study.Beeping;
using Study.Beeping.Beeper;
using Study.Beeping.Reader;
using Study.Beeping.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Beep_Player
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program.C();
        }

        public static void A()
        {
            String fileName = "some.txt";
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            IEnumerable<Beep> beeps = new List<Beep>();
            {
                Beep _ = new Beep(26666, 500);
                Beep a = new Beep(533, 300);

                beeps = new List<Beep>
                {
                    a,_,a,_,a,_,a,_,a,a,a,
                };
            }
            Stream stream = new FileStream(fileName, FileMode.CreateNew);
            IBeeper beeper = new ConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(stream, beeper, streamWriter);

            writer.WriteBeeps(beeps);
        }

        public static void B()
        {
            int amount = 1000;
            for (int i = 0; i < amount; i++)
            {
                int freq = (32767 - 37) / amount * i + 37;
                Console.Clear();
                Console.Write(freq);
                Console.Beep(freq, 100);
            }
        }

        public static void C()
        {
            IEnumerable<Beep> beeps = new List<Beep>()
            {
                new Beep(
                    42,
                    133
                ),
                new Beep(
                    666,
                    133
                )
            };
            Stream stream = new MemoryStream();
            IBeeper beeper = new StubConsoleBeeper();
            {
                IBeepStreamWriter streamWriter = new BeepStreamWriter();
                IBeepingWriter writer = new BeepingWriter(
                    stream,
                    beeper,
                    streamWriter
                );

                writer.WriteBeeps(beeps);
            }
            IBeepStreamReader streamReader = new BeepStreamReader();
            IBeepingReader reader = new BeepingReader(
                stream,
                beeper,
                streamReader
            );

            IEnumerable<Beep> readedBeeps = reader.ReadBeeps();

            bool kek =
                beeps.SequenceEqual(readedBeeps);
        }
    }
}