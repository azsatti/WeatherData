namespace EnvironmentData.Test.PostSharp
{
    using System;
    using System.IO;
    using EnvironmentData.PostSharp;
    using NUnit.Framework;

    [TestFixture]
    public class LogExceptionAttributeTest
    {
        [NUnit.Framework.Test]
        public void TestLogException()
        {
            var outputStream = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    log4net.Config.XmlConfigurator.Configure();

                    try
                    {
                        new TestAttribute().TestMethod();
                        Assert.Fail();
                    }
                    catch (Exception e)
                    {
                        Assert.AreEqual(e.Message, "Bad things may happen");
                    }
                }
            }
            finally
            {
                Console.SetOut(outputStream);
            }
        }

        [NUnit.Framework.Test]
        public void TestLogExceptionWithInnerException()
        {
            var outputStream = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    log4net.Config.XmlConfigurator.Configure();

                    try
                    {
                        new TestAttribute().TestMethodWithInner();
                        Assert.Fail();
                    }
                    catch (Exception e)
                    {
                        Assert.AreEqual(e.Message, "Bad things may happen");
                    }
                }
            }
            finally
            {
                Console.SetOut(outputStream);
            }
        }

        private class TestAttribute
        {
            [LogException]
            public void TestMethod()
            {
                throw new Exception("Bad things may happen");
            }

            [LogException]
            public void TestMethodWithInner()
            {
                throw new Exception("Bad things may happen", new Exception("Very bad things"));
            }
        }
    }
}
