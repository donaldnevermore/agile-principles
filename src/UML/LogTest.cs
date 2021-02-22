using System;
using System.Threading;
using NUnit.Framework;

namespace AgileSoftwareDevelopment.UML {
    [TestFixture]
    public class LogTest {
        private AsynchronousLogger logger;
        private int messagesLogged;

        [SetUp]
        protected void SetUp() {
            messagesLogged = 0;
            logger = new AsynchronousLogger(Console.Out);
            Pause();
        }

        [TearDown]
        protected void TearDown() {
            logger.Stop();
        }

        [Test]
        public void OneMessage() {
            logger.LogMessage("one message");
            CheckMessagesFlowToLog(1);
        }

        [Test]
        public void TwoConsecutiveMessages() {
            logger.LogMessage("another");
            logger.LogMessage("and another");
            CheckMessagesFlowToLog(2);
        }

        [Test]
        public void ManyMessages() {
            for (var i = 0; i < 10; i++) {
                logger.LogMessage($"message:{i}");
                CheckMessagesFlowToLog(1);
            }
        }

        private void CheckMessagesFlowToLog(int queued) {
            CheckQueuedAndLogged(queued, messagesLogged);
            Pause();
            messagesLogged += queued;
            CheckQueuedAndLogged(0, messagesLogged);
        }

        private void CheckQueuedAndLogged(int queued, int logged) {
            Assert.AreEqual(queued, logger.MessagesInQueue(), "queued");
            Assert.AreEqual(logged, logger.MessagesLogged(), "logged");
        }

        private static void Pause() {
            Thread.Sleep(50);
        }
    }
}
