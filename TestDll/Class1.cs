using System;
using System.Collections.Generic;

namespace TestDll
{
    public class Class1
    {
        public bool TestBool;
        public string TestString;
        public Class2<Class3<String>> testParam;
        
        private bool test1()
        {
            return false;
        }

        public string test2()
        {
            return TestString;
        }
    }
}