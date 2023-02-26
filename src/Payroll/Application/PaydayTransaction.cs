using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Application;

public class PaydayTransaction : Transaction {
    private readonly DateTime payDate;
    private readonly Dictionary<int, Paycheck> paychecks = new();

    public PaydayTransaction(DateTime payDate) {
        this.payDate = payDate;
    }

    public void Execute() {
        var empIds = PayrollDatabase.GetAllEmployeeIds();
        foreach (var empId in empIds) {
            var employee = PayrollDatabase.GetEmployee(empId);
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
