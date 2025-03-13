using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeCommissionedTransaction : ChangeClassificationTransaction {
    private decimal _salary;
    private decimal _commissionRate;

    public ChangeCommissionedTransaction(int empId, decimal salary, decimal commisionRate) : base(empId) {
        this._salary = salary;
        this._commissionRate = commisionRate;
    }

    protected override PaymentClassification GetClassification() {
        return PayrollFactory.Scope.PayrollFactory.MakeCommissionedClassification(_salary, _commissionRate);
    }

    protected override PaymentSchedule GetSchedule() {
        return PayrollFactory.Scope.PayrollFactory.MakeBiweeklySchedule();
    }
}
