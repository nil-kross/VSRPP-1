using System;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            Object @object = new object();
            ITypeWriter typeWriter = new TypeWriter(
                new DeclarationWriter(),
                new DeclarationFileStreamFactory(@object.GetType().Name), 
                new DeclarationStreamWriter()                
            );

            typeWriter.WriteDeclaration(@object);
        }
    }
}