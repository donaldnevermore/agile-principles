using Ch30.CommonTypes;
using Ch30.PayrollDomain;

namespace Ch30.PayrollImplementation;

public class WeeklySchedule : PaymentSchedule {
    public bool IsPayDate(Date date) {
        if (date.DayOfWeek == DayOfWeek.Friday) {
            return true;
        }

        return false;
    }

    public Date GetPayPeriodStartDate(Date payPeriod) {
        return payPeriod.AddDays(-6);
    }
}
