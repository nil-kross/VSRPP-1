using System;
using System.Collections.Generic;
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
                ISet<String> namespacesStringsSet = new HashSet<String>();
                StringBuilder namespacesStringBuilder = new StringBuilder();
                StringBuilder contentStringBuilder = new StringBuilder();
                Action<String> addNamespaceAction = (String namespaceString) =>
                {
                    if (type.Namespace != namespaceString)
                    {
                        namespacesStringsSet.Add(namespaceString);
                    }
                };
                Func<Type, String> getTypeNameFunc = (Type someType) =>
                {
                    addNamespaceAction(someType.Namespace);

                    return someType.Name;
                };
                Int16 indentsLevel = 0;

                // Namespace
                {
                    contentStringBuilder.Append(
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
                            "{0} {1} {2}",
                            type.IsPublic ? "public" : "private",
                            type.IsClass ? "class" : type.IsInterface ? "interface" : type.IsValueType ? "struct" : type.IsEnum ? "enum" : "other",
                            type.Name
                        );

                        contentStringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                classDeclarationString
                            )
                        );
                        contentStringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                '{'
                            )
                        );
                        // Field
                        contentStringBuilder.Append(
                            String.Format(
                                "{0}{1} Fields",
                                this.GetIndents(2),
                                @"//"
                            )
                        );
                        foreach (FieldInfo field in type.GetFields()) 
                        {
                            contentStringBuilder.Append(
                                String.Format(
                                    "{0}{1} {2} {3};\r\n",
                                    this.GetIndents(2),
                                    field.IsPublic ? "public" : field.IsPrivate ? "private" : "protected",
                                    field.Name,
                                    getTypeNameFunc(field.FieldType)
                                )
                            );
                        }
                        contentStringBuilder.Append(String.Format("\r\n"));
                        // Methods
                        contentStringBuilder.Append(
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
                                        getTypeNameFunc(parameter.ParameterType),
                                        parameter.Name,
                                        isFirst ? "" : ", "
                                    )
                                );
                                isFirst = false;
                            }
                            foreach (CustomAttributeData attribute in method.CustomAttributes)
                            {
                                contentStringBuilder.Append(
                                    String.Format(
                                        "{1}[{0}]\r\n",
                                        getTypeNameFunc(attribute.AttributeType).Replace("Attribute", ""),
                                        this.GetIndents(2)
                                    )
                                );
                            }
                            contentStringBuilder.Append(
                                String.Format(
                                    "{0}{3} {5}{4}{6} {1}{2}({7});\r\n",
                                    this.GetIndents(2),
                                    method.Name,
                                    "",
                                    method.IsPublic ? "public" : method.IsPrivate ? "private" : "protected",
                                    method.IsVirtual ? "virtual" + ' ' : "",
                                    method.IsStatic ? "static" + ' ' : "",
                                    getTypeNameFunc(method.ReturnType),
                                    parametersStringBuilder.ToString()
                                )
                            );
                        }
                        contentStringBuilder.Append(
                            String.Format(
                                "{0}{1}\r\n",
                                this.GetIndents(1),
                                '}'
                            )
                        );
                    }
                    contentStringBuilder.Append(
                        this.GetIndents(0) +
                        "}\r\n"
                    );
                }
                // Building namespaces
                {
                    if (namespacesStringsSet.Count > 0)
                    {
                        foreach (String namespaceString in namespacesStringsSet)
                        {
                            namespacesStringBuilder.Append(
                                String.Format(
                                    "using {0};{1}",
                                    namespaceString,
                                    Environment.NewLine
                                )
                            );
                        }
                        namespacesStringBuilder.Append(Environment.NewLine);
                    }
                }
                declarationString = namespacesStringBuilder.ToString() + 
                                    contentStringBuilder.ToString();
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
