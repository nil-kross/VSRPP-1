using System;
using System.IO;

namespace Study
{
    public class TypeWriter
        : ITypeWriter
    {
        private Stream _stream;
        private IDeclarationWriter _declarationWriter;
        private IDeclarationStreamFactory _declarationStreamFactory;
        private IDeclarationStreamWriter _declarationStreamWriter;

        public TypeWriter(
            IDeclarationWriter declarationWriter,
            IDeclarationStreamFactory declarationStreamFactory,
            IDeclarationStreamWriter declarationStreamWriter
        ) { 
            _declarationWriter = declarationWriter;
            _declarationStreamFactory = declarationStreamFactory;
            _declarationStreamWriter = declarationStreamWriter;
        }

        public void WriteDeclaration(Object instance)
        {
            String declarationString;
            Type type = instance.GetType();

            _declarationStreamFactory.ClassName = type.Name;
            _stream = _declarationStreamFactory.GetStream();
            declarationString = _declarationWriter.GetDeclaration(type);
            _declarationStreamWriter.Write(
                _stream, 
                declarationString
            );
        }
    }
}