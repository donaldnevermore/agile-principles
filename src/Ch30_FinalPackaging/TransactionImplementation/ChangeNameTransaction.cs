using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeNameTransaction : ChangeEmployeeTransaction {
    private string _newName;

    public ChangeNameTransaction(int empId, string newName) : base(empId) {
        _newName = newName;
    }

    protected override void Change(Employee employee) {
        employee.Name = _newName;
    }
}
