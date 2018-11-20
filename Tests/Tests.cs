using System;
using System.Linq;
using AssemblyBrowser;
using NUnit.Framework;
using TestDll;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private AssemblyResult result;
        private Type testClassType;
        private string dllPath = "C:\\Users\\vital\\RiderProjects\\SPP_LAB3\\TestDll\\bin\\Debug\\TestDll.dll";
        [OneTimeSetUp]
        public void Initialize()
        {
            AssemblyReader asmInfoProcessor = new AssemblyReader();
            result = asmInfoProcessor.read(dllPath);
            testClassType = typeof(Class1);
        }
        [Test]
        public void TestNamespacesIsNotNull()
        {
            Assert.IsNotNull(result.NameSpaces);
        }
        [Test]
        public void TestNamespacesCount()
        {
            Assert.IsTrue(result.NameSpaces.Count > 0);
        }

        [Test]
        public void TestNamespaceName()
        {
            Assert.AreEqual(result.NameSpaces[0].name, "TestDll");
        }
        
        [Test]
        public void TestNamespacesTypesCount()
        {
            foreach (NameSpaces ns in result.NameSpaces)
            {
                Assert.IsTrue(ns.DataTypes.Count > 0);
            }
        }
        
        [Test]
        public void TestTypeFieldsCount()
        {
            int actualCount = result.NameSpaces[0].DataTypes[0].fields.Count;
            int expectedCount = testClassType.GetFields().Length;
            Assert.AreEqual(actualCount, expectedCount);
        }
        
        [Test]
        public void TestTypeMethodsCount()
        {
            int actualCount = result.NameSpaces[0].DataTypes[0].Methods.Count;
            int expectedCount = testClassType.GetMethods().Where(item => !item.IsSpecialName).Count();
            Assert.AreEqual(actualCount, expectedCount);
        }
        
        [Test]
        public void TestTypePropertiesCount()
        {
            int actualCount = result.NameSpaces[0].DataTypes[0].Properties.Count;
            int expectedCount = testClassType.GetProperties().Length;

            Assert.AreEqual(actualCount, expectedCount);
        }
    }
}