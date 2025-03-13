namespace AgilePrinciples.ISP;

public interface Door {
    void Lock();
    void Unlock();
    bool IsDoorOpen();
}

public interface TimedDoor : Door {
    void DoorTimeOut(int timeOutId);
}

public interface TimerClient {
    void TimeOut(int timeOutId);
}

public class Timer {
    public void Register(int timeOut, int timeOutId, TimerClient client) { }
}

public class DoorTimerAdapter : TimerClient {
    private readonly TimedDoor timedDoor;

    public DoorTimerAdapter(TimedDoor theDoor) {
        timedDoor = theDoor;
    }

    public virtual void TimeOut(int timeOutId) {
        timedDoor.DoorTimeOut(timeOutId);
    }
}

/// <summary>
/// A better implementation.
/// </summary>
public interface BetterTimedDoor : Door, TimerClient {
}
