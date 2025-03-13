using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeHourlyTransaction : ChangeClassificationTransaction {
    private decimal _hourlyRate;

    public ChangeHourlyTransaction(int empId, decimal hourlyRate) : base(empId) {
        _hourlyRate = hourlyRate;
    }

    protected override PaymentClassification GetClassification() {
        return PayrollFactory.Scope.PayrollFactory.MakeHourlyClassification(_hourlyRate);
    }

    protected override PaymentSchedule GetSchedule() {
        return PayrollFactory.Scope.PayrollFactory.MakeWeeklySchedule();
    }
}
