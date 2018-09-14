using System;
using System.IO;

namespace Study
{
    public interface IDeclarationStreamFactory
    {
        String ClassName { get; set; }

        Stream GetStream();
    }
}