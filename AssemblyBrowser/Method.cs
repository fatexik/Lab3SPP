using System.Reflection;

namespace AssemblyBrowser
{
    public class Method
    {
        public string name;
        public string signature;

        public Method(MethodInfo mi)
        {
            signature = Attributes.GetModifiers(mi.GetType()) + mi;
        }
    }
}