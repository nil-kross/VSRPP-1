using System;
using System.IO;

namespace Study
{
    public class DeclarationFileStreamFactory
        : IDeclarationStreamFactory
    {
        private String _fileNameString;

        public DeclarationFileStreamFactory(String className)
        {
            _fileNameString = className + ".cs";
        }

        public Stream GetStream()
        {
            Stream stream;

            if (File.Exists(_fileNameString))
            {
                File.Delete(_fileNameString);
            }
            stream = new FileStream(
                _fileNameString,
                FileMode.CreateNew
            );

            return stream;
        }
    }
}