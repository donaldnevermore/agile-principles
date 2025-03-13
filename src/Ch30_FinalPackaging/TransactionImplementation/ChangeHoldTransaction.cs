using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeHoldTransaction : ChangeMethodTransaction {
    public ChangeHoldTransaction(int empId) : base(empId) {
    }

    protected override PaymentMethod GetMethod() {
        return PayrollFactory.Scope.PayrollFactory.MakeHoldMethod();
    }
}
