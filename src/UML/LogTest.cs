using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgilePrinciples.UML;

[TestClass]
public class LogTest {
    private AsynchronousLogger logger;
    private int messagesLogged;

    [TestInitialize]
    public void SetUp() {
        messagesLogged = 0;
        logger = new AsynchronousLogger(Console.Out);
        Pause();
    }

    [TestCleanup]
    public void TearDown() {
        logger.Stop();
    }

    [TestMethod]
    public void OneMessage() {
        logger.LogMessage("one message");
        CheckMessagesFlowToLog(1);
    }

    [TestMethod]
    public void TwoConsecutiveMessages() {
        logger.LogMessage("another");
        logger.LogMessage("and another");
        CheckMessagesFlowToLog(2);
    }

    [TestMethod]
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
