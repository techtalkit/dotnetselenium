namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup method is executed");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1 method is executed");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2 method is executed");
        }
        [TearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("TearDown method is executed");
        }

    }
}