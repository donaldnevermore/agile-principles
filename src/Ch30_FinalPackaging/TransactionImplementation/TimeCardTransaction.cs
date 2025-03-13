using Ch30.CommonTypes;
using Ch30.PayrollDomain;
using Ch30.TransactionApplication;

namespace Ch30.TransactionImplementation;

public class TimeCardTransaction : Transaction {
    private int _empId;
    private decimal _hours;
    private Date _forDate;

    public TimeCardTransaction(Date date, decimal hours, int empId) {
        _forDate = date;
        _hours = hours;
        _empId = empId;
    }

    public void Execute() {
        var employee = PayrollDatabase.Scope.DatabaseInstance.GetEmployee(_empId);
        if (employee == null) {
            throw new Exception("No such employee");
        }

        var classification = employee.GetClassification();

        classification.AddTimeCard(_forDate, _hours);
    }
}
