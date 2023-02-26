namespace AgileSoftwareDevelopment.SingletonAndMonostate;

public class Turnstile {
    private static bool isLocked = true;
    private static bool isAlarming = false;
    private static int itsCoins = 0;
    private static int itsRefunds = 0;

    protected static readonly Turnstile Locked = new LockedTurnstile();
    protected static readonly Turnstile Unlocked = new UnlockedTurnstile();
    protected static Turnstile itsState = Locked;

    public void Reset() {
        Lock(true);
        Alarm(false);
        itsCoins = 0;
        itsRefunds = 0;
        itsState = Locked;
    }

    public bool IsLocked => isLocked;
    public bool IsAlarming => isAlarming;
    public int Coins => itsCoins;
    public int Refunds => itsRefunds;

    public virtual void Coin() {
        itsState.Coin();
    }

    public virtual void Pass() {
        itsState.Pass();
    }

    protected void Lock(bool shouldLock) {
        isLocked = shouldLock;
    }

    protected void Alarm(bool shouldAlarm) {
        isAlarming = shouldAlarm;
    }

    /// <summary>
    /// Put a coin into the turnstile.
    /// </summary>
    public void Deposit() {
        itsCoins++;
    }

    public void Refund() {
        itsRefunds++;
    }

    internal class LockedTurnstile : Turnstile {
        public override void Coin() {
            itsState = Unlocked;
            Lock(false);
            Alarm(false);
            Deposit();
        }

        public override void Pass() {
            Alarm(true);
        }
    }

    internal class UnlockedTurnstile : Turnstile {
        public override void Coin() {
            Refund();
        }

        public override void Pass() {
            Lock(true);
            itsState = Locked;
        }
    }
}
