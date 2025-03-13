using System.Diagnostics;

namespace Ch30.TransactionApplication;

// Should be in Application assembly, and we're missing the AbstractTransactions assembly.
public class Application {
    readonly TransactionSource _source;

    public Application(TransactionSource transactionSource) {
        _source = transactionSource;
    }

    [DebuggerStepThrough]
    public void Process() {
        while (true) {
            Transaction transaction;
            try {
                transaction = _source.Next();
            } catch (Exception e) {
                Console.Error.WriteLine("Failed processing line:\n{0}", e);
                continue;
            }

            if (transaction == null) {
                return;
            }

            transaction.Execute();
        }
    }
}
