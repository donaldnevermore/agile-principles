using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Application;

public class DeleteEmployeeTransaction : Transaction
{
    private readonly int id;

    public DeleteEmployeeTransaction(int id, PayrollDatabase database)
        : base (database)
    {
        this.id = id;
    }

    public override void Execute()
    {
        database.DeleteEmployee(id);
    }
}
