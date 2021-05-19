using DemoLib;
using NUnit.Framework;

namespace DemoTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAll()
        {
            var c = new Class1();
            Assert.That(c.Ping("TEST"), Is.EqualTo("TEST"));
        }

#if NET35
        [Test]
        public void Test35()
        {
            Assert.Pass();
        }
#endif

#if NETFRAMEWORK
        [Test]
        public void TestFramework()
        {
            Assert.Pass();
        }
#endif

#if !NETFRAMEWORK
        [Test]
        public void TestCore()
        {
            Assert.Pass();
        }
#endif
    }
}