using System;
using System.Text;

namespace Study
{
    public class DeclarationWriter
        : IDeclarationWriter
    {
        public String GetDeclaration(Object instance)
        {
            String declarationString = null;

            if (instance != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Int16 indentsLevel = 0;
                Type type = instance.GetType();

                {
                    stringBuilder.Append(
                        this.GetIndents(0) +
                        "namespace " + type.Namespace + "\r\n" +
                        "{\r\n"
                    );
                    {
                        //
                    }
                    stringBuilder.Append(
                        this.GetIndents(0) +
                        "}\r\n"
                    );
                }
                foreach (var a in type.GetFields())
                {
                    ;
                }
                declarationString = stringBuilder.ToString();
            }

            return declarationString;
        }

        protected String GetIndents(Int16 indentsAmount)
        {
            StringBuilder stringBuilder = new StringBuilder("");

            for (Int16 i = 0; i < indentsAmount; i++)
            {
                stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
