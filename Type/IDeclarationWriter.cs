using System;

namespace Study
{
    public interface IDeclarationWriter
    {
        String GetDeclaration(Type type);
    }
}