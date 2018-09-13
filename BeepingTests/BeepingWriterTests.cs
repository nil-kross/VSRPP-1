using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.Beeping;
using Study.Beeping.Beeper;
using Study.Beeping.Writer;
using System;
using System.Collections.Generic;
using System.IO;

namespace BeepingTests
{
    [TestClass]
    public class BeepingWriterTests
    {
        [TestMethod]
        public void WriteBeep_WriteSomeBeep_PositionAreEqualTo4()
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new StubConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(
                stream,
                beeper,
                streamWriter
            );

            writer.WriteBeep(
                new Beep(
                    40,
                    200
                )
            );

            Assert.AreEqual(
                4,
                stream.Position
            );
        }

        [TestMethod]
        public void WriteBeeps_WriteBeeps_PositionAreEqual8()
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new StubConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(
                stream,
                beeper,
                streamWriter
            );
            IEnumerable<Beep> beeps = new List<Beep>
            {
                new Beep(
                    38,
                    13
                ),
                new Beep(
                    42,
                    69
                )
            };

            writer.WriteBeeps(beeps);

            Assert.AreEqual(
                8, 
                stream.Position
            );
        }

        [TestMethod]
        public void WriteBeep_WriteNullBeep_ThrowNullReferenceException()
        {
            Stream stream = new MemoryStream();
            IBeeper beeper = new StubConsoleBeeper();
            IBeepStreamWriter streamWriter = new BeepStreamWriter();
            IBeepingWriter writer = new BeepingWriter(
                stream,
                beeper,
                streamWriter
            );

            Assert.ThrowsException<NullReferenceException>(
                () => {
                    writer.WriteBeep(null);
                }
            );
        }
    }
}