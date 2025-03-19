using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications;

public class TimeCardTransaction : Transaction {
    private readonly DateTime date;
    private readonly double hours;
    private readonly int empId;

    public TimeCardTransaction(DateTime date, double hours, int empId, PayrollDatabase database)
        : base(database) {
        this.date = date;
        this.hours = hours;
        this.empId = empId;
    }

    public override void Execute() {
        var e = database.GetEmployee(empId);
        if (e is null) {
            throw new ApplicationException("No such employee");
        }

        if (e.Classification is HourlyClassification hc) {
            hc.AddTimeCard(new TimeCard(date, hours));
        } else {
            throw new ApplicationException("Tried to add time card to non-hourly employee");
        }
    }
}
