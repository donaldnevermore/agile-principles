using Ch30.PayrollDomain;
using Ch30.TransactionApplication;

namespace Ch30.TransactionImplementation;

public class DeleteEmployeeTransaction : Transaction {
    private int _employeeId;

    public DeleteEmployeeTransaction(int empId) {
        this._employeeId = empId;
    }

    public void Execute() {
        PayrollDatabase.Scope.DatabaseInstance.DeleteEmployee(_employeeId);
    }
}
