namespace AgilePrinciples.ISP;

public interface Transaction {
    void Execute();
}

public interface DepositUI {
    void RequestDepositAmount();
}

public class DepositTransaction : Transaction {
    private readonly DepositUI depositUI;

    public DepositTransaction(DepositUI ui) {
        depositUI = ui;
    }

    public virtual void Execute() {
        depositUI.RequestDepositAmount();
    }
}

public interface WithdrawalUI {
    void RequestWithdrawalAmount();
}

public class WithdrawalTransaction : Transaction {
    private readonly WithdrawalUI withdrawalUI;

    public WithdrawalTransaction(WithdrawalUI ui) {
        withdrawalUI = ui;
    }

    public virtual void Execute() {
        withdrawalUI.RequestWithdrawalAmount();
    }
}

public interface TransferUI {
    void RequestTransferAmount();
}

public class TransferTransaction : Transaction {
    private readonly TransferUI transferUI;

    public TransferTransaction(TransferUI ui) {
        transferUI = ui;
    }

    public virtual void Execute() {
        transferUI.RequestTransferAmount();
    }
}

public interface UI : DepositUI, WithdrawalUI, TransferUI { }

/// <summary>
/// OK
/// </summary>
public class GUI {
    private readonly UI gui;

    public void Func() {
        var dt = new DepositTransaction(gui);
    }
}

/// <summary>
/// Bad
/// </summary>
public class UIGlobals {
    public static WithdrawalUI withdrawal;
    public static DepositUI deposit;
    public static TransferUI transfer;

    static UIGlobals() {
        var lui = new AtmUI();
        deposit = lui;
        withdrawal = lui;
        transfer = lui;
    }

    public void Client(Service s) {
        if (s is NewService) {
            var ns = s as NewService;
        }
    }
}

public class AtmUI : UI {
    public void RequestDepositAmount() { }
    public void RequestWithdrawalAmount() { }
    public void RequestTransferAmount() { }

}

public interface Service { }
public interface NewService : Service { }
