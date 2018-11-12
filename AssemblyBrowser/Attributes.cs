using System;

namespace AssemblyBrowser
{
    public class Attributes
    {
        public static string GetAtributes(Type ti)
        {
            string result = "";

            return result + GetModifiers(ti) + GetAtr(ti) + GetClass(ti);
        }
        
        public static string GetModifiers(Type type)
        {
            if (type.IsNestedPublic || type.IsPublic)
            {
                return "public";
            }

            if (type.IsNestedPrivate)
            {
                return "private";
            }

            if (type.IsNestedFamily)
            {
                return "protected";
            }

            if (type.IsNestedAssembly)
            {
                return "internal";
            }

            if (type.IsNestedFamANDAssem)
            {
                return "protected private";
            }

            if (type.IsNotPublic)
            {
                return "private";
            }
            else
            {
                return "public";
            }
        }
        
        private static string GetClass(Type ti)
        {
            if (ti.IsInterface)
                return "interface";
            if (ti.IsValueType)
                return "struct";
            if (ti.IsEnum)
                return "enum";

            if (ti.BaseType == typeof(MulticastDelegate))
                return "delegate";

            if (ti.IsClass)
                return "class";

            return "";
       }
        
        private static string GetAtr(Type ti)
        {
            if (ti.IsAbstract && ti.IsSealed)
                return "static";
            if (ti.IsSealed)
                return "sealed";
            if (ti.IsAbstract)
                return "abstract";

            return "";
        }
    }   
}