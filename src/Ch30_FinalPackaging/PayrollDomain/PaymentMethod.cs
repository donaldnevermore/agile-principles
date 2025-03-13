namespace Ch30.PayrollDomain;

public interface PaymentMethod {
    void Pay(Paycheck paycheck);
}
