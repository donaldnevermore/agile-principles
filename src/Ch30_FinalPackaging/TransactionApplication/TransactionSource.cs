namespace Ch30.TransactionApplication;

public interface TransactionSource {
    Transaction Next();
}
