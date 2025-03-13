using System.Collections;

namespace AgilePrinciples.UML;

public interface Logger {
    void LogMessage(string msg);
}

public class AsynchronousLogger : Logger {
    private readonly ArrayList messages = ArrayList.Synchronized(new ArrayList());
    private readonly Thread t;
    private bool running;
    private int logged;
    private readonly TextWriter logStream;

    public AsynchronousLogger(TextWriter stream) {
        logStream = stream;
        running = true;
        t = new Thread(new ThreadStart(MainLoggerLoop)) {
            Priority = ThreadPriority.Lowest
        };
        t.Start();
    }

    private void MainLoggerLoop() {
        while (running) {
            LogQueuedMessages();
            SleepTillMoreMessagesQueued();
            Thread.Sleep(10);
        }
    }

    private void LogQueuedMessages() {
        while (MessagesInQueue() > 0) {
            LogOneMessage();
        }
    }

    private void LogOneMessage() {
        var msg = (string)messages[0];
        messages.RemoveAt(0);
        logStream.WriteLine(msg);
        logged++;
    }

    private void SleepTillMoreMessagesQueued() {
        lock (messages) {
            Monitor.Wait(messages);
        }
    }

    public void LogMessage(string msg) {
        messages.Add(msg);
        WakeLoggerThread();
    }

    public int MessagesInQueue() => messages.Count;
    public int MessagesLogged() => logged;

    public void Stop() {
        running = false;
        WakeLoggerThread();
        t.Join();
    }

    private void WakeLoggerThread() {
        lock (messages) {
            Monitor.PulseAll(messages);
        }
    }
}
