using System;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.B();
            Program.A();
        }

        public static void A()
        {
            Object instance = new object();
            ITypeWriter typeWriter = new FileTypeWriterFactory().TypeWriter;

            typeWriter.WriteDeclaration(instance);
        }

        public static void B()
        {
            Object o = new Object();
            Type t = o.GetType();
            t = t;
        }
    }
}