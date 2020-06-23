using NUnit.Framework;

namespace LoggerTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int x = 1;
            int y = 2;
            Assert.AreEqual(x,y);
        }
        [Test]
        public void Test2()
        {
            int x = 1;
            int y = 1;
            Assert.AreEqual(x,y);
        }
        [TestCase(1,2)]
        [TestCase(2,2)]
        [TestCase(1,1)]
        [TestCase(3,2)]
        [TestCase(1,2)]
        [Test]
        public void Test3(int x, int y)
        {
            Assert.AreEqual(x,y);
        }
    }
}