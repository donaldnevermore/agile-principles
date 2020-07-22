using NUnit.Framework;

namespace AgileSoftwareDevelopment.Bowling
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void TestTwoThrowsNoMark()
        {
            game.Add(5);
            game.Add(4);
            Assert.AreEqual(game.Score, 9);
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            game.Add(5);
            game.Add(4);
            game.Add(7);
            game.Add(2);
            Assert.AreEqual(game.Score, 18);
            Assert.AreEqual(game.ScoreForFrame(1), 9);
            Assert.AreEqual(game.ScoreForFrame(2), 18);
        }

        [Test]
        public void TestSimpleSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            Assert.AreEqual(game.ScoreForFrame(1), 13);
        }

        [Test]
        public void TestSimpleFrameAfterSpare()
        {
            game.Add(3);
            game.Add(7);
            game.Add(3);
            game.Add(2);
            Assert.AreEqual(13, game.ScoreForFrame(1));
            Assert.AreEqual(18, game.ScoreForFrame(2));
            Assert.AreEqual(18, game.Score);
        }

        [Test]
        public void TestSimpleStrike()
        {
            game.Add(10);
            game.Add(3);
            game.Add(6);
            Assert.AreEqual(19, game.ScoreForFrame(1));
            Assert.AreEqual(28, game.Score);
        }

        [Test]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Add(10);
            }

            Assert.AreEqual(300, game.Score);
        }

        [Test]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Add(0);
                game.Add(0);
            }

            game.Add(2);
            game.Add(8); // 10th frame spare
            game.Add(10); // Strike in last position of array.
            Assert.AreEqual(20, game.Score);
        }

        [Test]
        public void TestSampleGame()
        {
            game.Add(1);
            game.Add(4);
            game.Add(4);
            game.Add(5);
            game.Add(6);
            game.Add(4);
            game.Add(5);
            game.Add(5);
            game.Add(10);
            game.Add(0);
            game.Add(1);
            game.Add(7);
            game.Add(3);
            game.Add(6);
            game.Add(4);
            game.Add(10);
            game.Add(2);
            game.Add(8);
            game.Add(6);
            Assert.AreEqual(133, game.Score);
        }

        [Test]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
            {
                game.Add(10);
            }

            game.Add(9);
            Assert.AreEqual(299, game.Score);
        }

        [Test]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Add(10);
            }

            game.Add(9);
            game.Add(1);
            game.Add(1);
            Assert.AreEqual(270, game.Score);
        }
    }
}
