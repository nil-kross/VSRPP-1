using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.Beeping;
using Study.Beeping.Beeper;
using Study.Beeping.Reader;
using Study.Beeping.Writer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeepingTests
{
    [TestClass]
    public class BeepingReaderTests
    {
        [TestMethod]
        public void ReadBeep_ReadEmptyStream_ReadedBeepIsNull()
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new StubConsoleBeeper();
            IBeepStreamReader streamReader = new BeepStreamReader();
            IBeepingReader reader = new BeepingReader(
                stream,
                beeper,
                streamReader
            );

            var beep = reader.ReadBeep();

            Assert.IsNull(beep);
        }

        [TestMethod]
        public void ReadBeep_ReadNormalBeep_WritedBeepAreEqualReadedBeep()
        {
            String fileName = "test.txt";
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            Beep beep = new Beep(
                40,
                133
            );
            Stream stream = new FileStream(
                fileName, 
                FileMode.CreateNew
            );
            {
                IBeepStreamWriter streamWriter = new BeepStreamWriter();

                streamWriter.WriteBeep(
                    stream,
                    beep
                );
            }
            IBeeper beeper = new StubConsoleBeeper();
            IBeepStreamReader streamReader = new BeepStreamReader();
            IBeepingReader reader = new BeepingReader(
                stream,
                beeper,
                streamReader
            );

            Beep readedBeep = reader.ReadBeep();

            Assert.AreEqual<Beep>(
                beep,
                readedBeep
            );
        }

        [TestMethod]
        public void ReadBeeps_ReadSomeBeeps_BeepsAreEqual()
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

            
            Assert.IsTrue(
                beeps.SequenceEqual(readedBeeps)
            );
        }
    }
}