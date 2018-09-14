using System;
using System.IO;
using System.Text;

namespace Study
{
    public class DeclarationStreamWriter
        : IDeclarationStreamWriter
    {
        public void Write(
            Stream stream,
            String declaration
        ) {
            StreamWriter streamWriter = new StreamWriter(stream, Encoding.Unicode);
            
            streamWriter.Write(declaration);
            streamWriter.Close();
        }
    }
}