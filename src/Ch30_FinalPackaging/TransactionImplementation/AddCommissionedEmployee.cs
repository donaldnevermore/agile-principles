using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class AddCommissionedEmployee : AddEmployeeTransaction {
    private decimal _salary;
    private decimal _commissionRate;

    public AddCommissionedEmployee(int empId, string name, string address, decimal salary, decimal commissionRate) :
        base(empId, name, address) {
        _salary = salary;
        _commissionRate = commissionRate;
    }

    protected override PaymentSchedule GetSchedule() {
        return PayrollFactory.Scope.PayrollFactory.MakeBiweeklySchedule();
    }

    protected override PaymentClassification GetClassification() {
        return PayrollFactory.Scope.PayrollFactory.MakeCommissionedClassification(_salary, _commissionRate);
    }
}
