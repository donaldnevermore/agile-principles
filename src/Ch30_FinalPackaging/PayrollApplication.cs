using Ch30.TextParser;
using Ch30.TransactionApplication;

// PayrollApplication assembly
namespace Ch30.ConsoleHost;

class PayrollApplication : TransactionApplication.Application {
    public PayrollApplication(TextParserTransactionSource source) : base(source) {
    }

    static void Main(string[] args) {
        PayrollDatabase.Scope.DatabaseInstance = InMemPayrollDatabase.Database.Instance;
        TransactionFactory.Scope.TransactionFactory = new TransactionImplementation.PayrollTransactionFactory();
        PayrollFactory.Scope.PayrollFactory = new PayrollImplementation.Factory();

        var reader = new StreamReader(new FileStream("TestTransactions.txt", FileMode.Open, FileAccess.Read));
        var parser = new TextParserTransactionSource(reader);
        var app = new PayrollApplication(parser);
        app.Process();
        return;
    }
}
