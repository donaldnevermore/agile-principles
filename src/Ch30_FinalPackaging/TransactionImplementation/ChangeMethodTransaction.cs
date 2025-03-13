using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction {
    public ChangeMethodTransaction(int empId) : base(empId) {
    }

    protected override void Change(Employee e) {
        e.Method = GetMethod();
    }

    protected abstract PaymentMethod GetMethod();
}
