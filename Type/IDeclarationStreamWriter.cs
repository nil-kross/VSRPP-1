using System;
using System.IO;

namespace Study
{
    public interface IDeclarationStreamWriter
    {
        void Write(
            Stream stream,
            String declaration
        );
    }
}