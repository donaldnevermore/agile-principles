using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Schedules;

public class BiweeklySchedule : PaymentSchedule {
    public bool IsPayDate(DateTime payDate) {
        return payDate.DayOfWeek == DayOfWeek.Friday &&
               payDate.Day % 2 == 0;
    }

    public DateTime GetPayPeriodStartDate(DateTime date) {
        // Avoid duplicate pay.
        return date.AddDays(-13);
    }

    public override string ToString() {
        return "bi-weekly";
    }
}
