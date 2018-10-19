namespace Study
{
    public class FileTypeWriterFactory
        : ITypeWriterFactory
    {
        public ITypeWriter TypeWriter => GetTypeWriter();

        protected ITypeWriter GetTypeWriter()
        {
            return new TypeWriter(
                new DeclarationWriter(),
                new DeclarationFileStreamFactory(),
                new DeclarationStreamWriter()
            );
        }
    }
}