using NUnit.Framework;

namespace AgileSoftwareDevelopment.PrimeGenerator {
    [TestFixture]
    public class PrimeGeneratorTest {
        [Test]
        public void TestPrimes() {
            var nullArray = PrimeGenerator.GeneratePrimeNumbers(0);
            Assert.AreEqual(0, nullArray.Length);

            var minArray = PrimeGenerator.GeneratePrimeNumbers(2);
            Assert.AreEqual(1, minArray.Length);
            Assert.AreEqual(2, minArray[0]);

            var threeArr = PrimeGenerator.GeneratePrimeNumbers(3);
            Assert.AreEqual(2, threeArr.Length);
            Assert.AreEqual(2, threeArr[0]);
            Assert.AreEqual(3, threeArr[1]);

            var centArr = PrimeGenerator.GeneratePrimeNumbers(100);
            Assert.AreEqual(25, centArr.Length);
            Assert.AreEqual(97, centArr[24]);
        }

        [Test]
        public void TestExhaustive() {
            for (var i = 2; i < 500; i++) {
                VerifyPrimeList(PrimeGenerator.GeneratePrimeNumbers(i));
            }
        }

        private static void VerifyPrimeList(int[] list) {
            for (var i = 0; i < list.Length; i++) {
                VerifyPrime(list[i]);
            }
        }

        private static void VerifyPrime(int n) {
            for (var factor = 2; factor < n; factor++) {
                Assert.IsTrue(n % factor != 0);
            }
        }
    }
}
