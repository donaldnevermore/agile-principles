using NUnit.Framework;

namespace AgileSoftwareDevelopment.PrimeGenerator
{
    [TestFixture]
    public class PrimeGeneratorTest
    {
        [Test]
        public void TestPrimes()
        {
            int[] nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
            Assert.AreEqual(nullArray.Length, 0);

            int[] minArray = PrimeGenerator.GeneratePrimeNumbers(2);
            Assert.AreEqual(minArray.Length, 1);
            Assert.AreEqual(minArray[0], 2);

            int[] threeArr = PrimeGenerator.GeneratePrimeNumbers(3);
            Assert.AreEqual(threeArr.Length, 2);
            Assert.AreEqual(threeArr[0], 2);
            Assert.AreEqual(threeArr[1], 3);

            int[] centArr = PrimeGenerator.GeneratePrimeNumbers(100);
            Assert.AreEqual(centArr.Length, 25);
            Assert.AreEqual(centArr[24], 97);
        }

        [Test]
        public void TestExhaustive()
        {
            for (int i = 2; i < 500; i++)
            {
                VerifyPrimeList(PrimeGenerator.GeneratePrimeNumbers(i));
            }
        }

        private void VerifyPrimeList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                VerifyPrime(list[i]);
            }
        }

        private void VerifyPrime(int n)
        {
            for (int factor = 2; factor < n; factor++)
            {
                Assert.IsTrue(n % factor != 0);
            }
        }
    }
}
