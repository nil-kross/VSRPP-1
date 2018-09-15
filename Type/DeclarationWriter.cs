using System;
using System.Reflection;
using System.Text;

namespace Study
{
    public class DeclarationWriter
        : IDeclarationWriter
    {
        public String GetDeclaration(Type type)
        {
            String declarationString = null;

            if (type != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                Int16 indentsLevel = 0;

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
                            bool isFirst = true;
                            StringBuilder parametersStringBuilder = new StringBuilder("");

                            foreach (ParameterInfo parameter in method.GetParameters())
                            {
                                parametersStringBuilder.Append(
                                    String.Format(
                                        "{2}{0} {1}",
                                        parameter.ParameterType.Name,
                                        parameter.Name,
                                        isFirst ? "" : ", "
                                    )
                                );
                                isFirst = false;
                            }
                            foreach (CustomAttributeData attribute in method.CustomAttributes)
                            {
                                stringBuilder.Append(
                                    String.Format(
                                        "{1}[{0}]\r\n",
                                        attribute.AttributeType.Name.Replace("Attribute", ""),
                                        this.GetIndents(2)
                                    )
                                );
                            }
                            stringBuilder.Append(
                                String.Format(
                                    "{0}{3} {5}{4}{6} {1}{2}({7});\r\n",
                                    this.GetIndents(2),
                                    method.Name,
                                    "",
                                    method.IsPublic ? "public" : method.IsPrivate ? "private" : "protected",
                                    method.IsVirtual ? "virtual" + ' ' : "",
                                    method.IsStatic ? "static" + ' ' : "",
                                    method.ReturnType.Name,
                                    parametersStringBuilder.ToString()
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
