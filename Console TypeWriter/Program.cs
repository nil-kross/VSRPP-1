using System;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            Object instance = new object();
            ITypeWriter typeWriter = new FileTypeWriterFactory().TypeWriter;

            typeWriter.WriteDeclaration(instance);
        }
    }
}