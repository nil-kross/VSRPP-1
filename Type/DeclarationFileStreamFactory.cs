using System;
using System.IO;

namespace Study
{
    public class DeclarationFileStreamFactory
        : IDeclarationStreamFactory
    {
        private String _classNameString;

        public String ClassName 
        {
            get {
                return _classNameString;
            }
            set {
                _classNameString = value;
            }
        }

        public Stream GetStream()
        {
            Stream stream = null;
            
            if (_classNameString != null)
            {
                String fileNameString = String.Format(
                    "{0}.cs",
                    _classNameString
                );

                    if (File.Exists(fileNameString))
                    {
                        File.Delete(fileNameString);
                    }
                    stream = new FileStream(
                        fileNameString,
                        FileMode.CreateNew
                    );
            }

            return stream;
        }
    }
}