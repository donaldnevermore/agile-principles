namespace AgilePrinciples.Payroll.Domain;

public interface PaymentSchedule {
    bool IsPayDate(DateTime payDate);
    DateTime GetPayPeriodStartDate(DateTime date);
}
