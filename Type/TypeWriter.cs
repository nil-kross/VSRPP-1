using System;
using System.IO;
using System.Text;

namespace Study
{
    public class TypeWriter
        : ITypeWriter
    {
        private Stream _stream;

        public TypeWriter(
            Stream stream
        ) { 
            _stream = stream;
        }

        public void WriteDeclaration(Object instance)
        {
            String declarationString = null;
            
            foreach (Char @char in declarationString)
            {
                Byte[] charBytes = BitConverter.GetBytes(@char);
                _stream.Write(
                    charBytes,
                    0,
                    charBytes.Length
                );
            }
        }
    }
}