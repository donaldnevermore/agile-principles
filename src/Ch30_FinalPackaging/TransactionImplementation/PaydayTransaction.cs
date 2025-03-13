using Ch30.CommonTypes;
using Ch30.PayrollDatabase;
using Ch30.PayrollDomain;
using Ch30.TransactionApplication;

namespace Ch30.TransactionImplementation;

public class PaydayTransaction : Transaction {
    private Date _forPayDate;
    Dictionary<int, Paycheck> _paychecks = new Dictionary<int, Paycheck>();

    public PaydayTransaction(Date payDate) {
        _forPayDate = payDate;
    }

    public void Execute() {
        var empIds = PayrollDatabase.Scope.DatabaseInstance.GetAllEmployeeIds();

        foreach (var empId in empIds) {
            var employee = PayrollDatabase.Scope.DatabaseInstance.GetEmployee(empId);
            if (employee == null) {
                continue;
            }

            if (!employee.IsPayDate(_forPayDate)) {
                continue;
            }

            var paycheck = new Paycheck(employee.GetPayPeriodStartDate(_forPayDate), _forPayDate);
            _paychecks[empId] = paycheck;
            employee.Payday(paycheck);
        }
    }

    public Paycheck GetPaycheck(int empId) {
        if (!_paychecks.ContainsKey(empId)) {
            return null;
        }

        return _paychecks[empId];
    }
}
