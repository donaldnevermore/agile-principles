namespace AgilePrinciples.Payroll.Domain;

public abstract class PaymentClassification {
    public abstract double CalculatePay(Paycheck paycheck);
}
