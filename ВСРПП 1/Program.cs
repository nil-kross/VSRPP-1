using Study.Streams.Beeping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace ВСРПП_1
{
    class Program
    {
        private static bool _isDevelop = true;

        static void Main(string[] args)
        {
            if (_isDevelop)
            {
                Program.Develop();
            } else {
                Program.Production();
            }
            Console.WriteLine("Program is finished! Press any key to exit ...");
            Console.ReadLine();
        }

        public static void Develop()
        {
            String fileNameString = "in.txt";
            {
                FileIOPermission f = new FileIOPermission(PermissionState.None);

                f.AllFiles = FileIOPermissionAccess.Write;
                f.Demand();
            }
            {
                if (File.Exists(fileNameString))
                {
                    File.Delete(fileNameString);
                }
            }
            Stream stream = new FileStream(fileNameString, FileMode.CreateNew, FileAccess.ReadWrite);
            if (true)
            {
                IBeepingWriter writer = new BeepingWriter(stream);

                for (int i = 1; i < 10; i++)
                {
                    writer.WriteBeep(new Beep((ushort)(3144 - 3100 / i), 100));
                }
            }
            if (true)
            {
                IBeepingReader reader = new BeepingReader(stream);
                var beeps = reader.ReadBeeps();
            }
        }

        public static void Production()
        {
            ;
        }

        public static UInt16 GetSelectionFromDialog(
            String text,
            IEnumerable<String> optionsEnumerable
        ) { 
            bool isDialogFinished = false;
            UInt16 optionValue = 0;
            UInt16 optionsAmountValue = (UInt16)optionsEnumerable.Count();

            while (!isDialogFinished)
            {
                Console.WriteLine(text + "/n/r");
                for (int i = 0; i < optionsAmountValue; i++)
                {
                    Console.WriteLine();
                }
            }

            return optionValue;
        }
    }
}