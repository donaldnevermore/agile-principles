using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Application;

public class PaydayTransaction : Transaction {
    private readonly DateTime payDate;
    private readonly Dictionary<int, Paycheck> paychecks = new();

    public PaydayTransaction(DateTime payDate, PayrollDatabase database)
        : base(database) {
        this.payDate = payDate;
    }

    public override void Execute() {
        var empIds = database.GetAllEmployeeIds();
        foreach (int empId in empIds) {
            var employee = database.GetEmployee(empId);
            if (employee.IsPayDate(payDate)) {
                var startDate = employee.GetPayPeriodStartDate(payDate);
                var pc = new Paycheck(startDate, payDate);

                paychecks[empId] = pc;
                employee.Payday(pc);
            }
        }
    }

    public Paycheck GetPaycheck(int empId) {
        if (paychecks.ContainsKey(empId)) {
            return paychecks[empId];
        }

        return null;
    }
}
