using System;
using System.IO;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            String fileName = "kek.txt";
            Stream stream = new FileStream(fileName, FileMode.CreateNew);
            ITypeWriter typeWriter = new TypeWriter(stream);
            typeWriter.WriteDeclaration(new object());
        }
    }
}
