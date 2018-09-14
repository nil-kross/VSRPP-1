using System;
using System.Reflection;
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

                // Namespace
                {
                    stringBuilder.Append(
                        String.Format(
                            "{0}namespace {1}\r\n{2}\r\n",
                            this.GetIndents(0),
                            type.Namespace,
                            '{'
                        )
                    );
                    // Declaration
                    {
                        String classDeclarationString = String.Format(
                            "{0} {1}",
                            type.IsPublic ? "public" : "private",
                            type.IsClass ? "class" : type.IsInterface ? "interface" : type.IsValueType ? "struct" : type.IsEnum ? "enum" : "other"
                        );

                        stringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                classDeclarationString
                            )
                        );
                        stringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                '{'
                            )
                        );
                        // Field
                        stringBuilder.Append(
                            String.Format(
                                "{0}{1} Fields",
                                this.GetIndents(2),
                                @"//"
                            )
                        );
                        foreach (FieldInfo field in type.GetFields()) 
                        {
                            stringBuilder.Append(
                                String.Format(
                                    "{0}{1} {2} {3};\r\n",
                                    this.GetIndents(2),
                                    field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected",
                                    field.Name,
                                    field.FieldType
                                )
                            );
                        }
                        stringBuilder.Append(String.Format("\r\n"));
                        // Methods
                        stringBuilder.Append(
                            String.Format(
                                "{0}{1} Methods\r\n",
                                this.GetIndents(2),
                                @"//"
                            )
                        );
                        foreach (MethodInfo method in type.GetMethods())
                        {
                            stringBuilder.Append(
                                String.Format(
                                    "{0}{1} {2};\r\n",
                                    this.GetIndents(2),
                                    method.Name,
                                    method.MemberType
                                )
                            );
                        }
                        stringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                '}'
                            )
                        );
                    }
                    stringBuilder.Append(
                        this.GetIndents(0) +
                        "}\r\n"
                    );
                }
                declarationString = stringBuilder.ToString();
            }

            return declarationString;
        }

        protected String GetIndents(Int16 indentsAmount)
        {
            var spacesInTabValue = 4;
            StringBuilder stringBuilder = new StringBuilder("");

            for (Int16 i = 0; i < indentsAmount * spacesInTabValue; i++)
            {
                stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
