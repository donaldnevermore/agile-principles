using Ch30.PayrollDatabase;
using Ch30.PayrollDomain;
using Ch30.TransactionApplication;

namespace Ch30.TransactionImplementation;

public abstract class ChangeEmployeeTransaction : Transaction {
    private int _empId;

    protected abstract void Change(Employee e);

    public ChangeEmployeeTransaction(int empId) {
        _empId = empId;
    }

    public void Execute() {
        var employee = PayrollDatabase.Scope.DatabaseInstance.GetEmployee(_empId);
        if (employee != null) {
            Change(employee);
        }
    }
}
