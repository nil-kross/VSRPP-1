using System;
using System.Collections.Generic;
using System.Text;

namespace Study
{
    public interface IDeclarationWriter
    {
        String GetDeclaration(Object instance);
    }
}
