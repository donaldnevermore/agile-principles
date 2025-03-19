using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll;

public abstract class ChangeEmployeeTransaction : Transaction {
    private readonly int empId;

    public ChangeEmployeeTransaction(int empId, PayrollDatabase database)
        : base(database) {
        this.empId = empId;
    }

    public override void Execute() {
        Employee e = database.GetEmployee(empId);
        if (e is null) {
            throw new ApplicationException(
                "No such employee.");
        }

        Change(e);
    }

    protected abstract void Change(Employee e);
}
