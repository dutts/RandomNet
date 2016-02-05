using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RandomNet.Tests
{
    [TestFixture]
    public class ParameterTests
    {
        private List<Exception> _exceptionsThrown;

        [SetUp]
        public void SetUp()
        {
            _exceptionsThrown = new List<Exception>();    
        }

        private void ExecuteInTryCatch(Action func)
        {
            try
            {
                func();
            }
            catch (Exception e)
            {
                _exceptionsThrown.Add(e);
            }
        }

        [Test]
        public void IntegerMinAndMaxTheSame()
        {
            var result = IntegerGenerator.GenerateAsync(10, 10, 10).Result.ToList();
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(10, result.First());    
        }

        [Test]
        public void IntegerMinLargerThandMax()
        {
            ExecuteInTryCatch(() => IntegerGenerator.GenerateAsync(10, 100, 1).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void IntegerNumberRequestedTooLargeTest()
        {
            ExecuteInTryCatch(() => IntegerGenerator.GenerateAsync((int)Math.Pow(10,3)+1, 1, 10).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void IntegerNumberRequestedTooSmallTest()
        {
            ExecuteInTryCatch(() => IntegerGenerator.GenerateAsync((int)-Math.Pow(10, 3) - 1, 1, 10).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void IntegerMaxValueTooLargeTest()
        {
            ExecuteInTryCatch(() => IntegerGenerator.GenerateAsync(10, 1, (int)Math.Pow(10, 8) + 1).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void IntegerMinValueTooSmallTest()
        {
            ExecuteInTryCatch(() => IntegerGenerator.GenerateAsync(10, (int)-Math.Pow(10, 8) - 1, 10000).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void SequenceMinAndMaxTheSame()
        {
            var result = SequenceGenerator.GenerateAsync(10, 10).Result.ToList();
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(10, result.First());
        }

        [Test]
        public void SequenceMinLargerThandMax()
        {
            ExecuteInTryCatch(() => SequenceGenerator.GenerateAsync(100, 1).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void SequenceRangeTooLargeTest()
        {
            ExecuteInTryCatch(() => SequenceGenerator.GenerateAsync(1, 10001).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void SequenceMaxValueTooLargeTest()
        {
            ExecuteInTryCatch(() => SequenceGenerator.GenerateAsync(1, (int)Math.Pow(10,8) + 1).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }

        [Test]
        public void SequenceMinValueTooSmallTest()
        {
            ExecuteInTryCatch(() => SequenceGenerator.GenerateAsync((int)-Math.Pow(10,8) - 1, 10000).Wait());

            Assert.AreEqual(1, _exceptionsThrown.Count);
            Assert.True(_exceptionsThrown.First().ContainsInnerExceptionOfType(typeof(ArgumentException)));
        }
    }
}
