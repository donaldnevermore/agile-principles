namespace AgilePrinciples.Payroll.Domain;

public interface PaymentMethod {
    void Pay(Paycheck paycheck);
}
