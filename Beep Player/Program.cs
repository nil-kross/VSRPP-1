using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBeepPlayerDialog playerDialog = new ConsoleBeepPlayerDialog();

            playerDialog.Task.RunSynchronously();
        }
    }
}