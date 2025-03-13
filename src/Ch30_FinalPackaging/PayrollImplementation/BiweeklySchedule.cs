using Ch30.CommonTypes;
using Ch30.PayrollDomain;

namespace Ch30.PayrollImplementation;

public class BiweeklySchedule : PaymentSchedule {
    readonly static Date ReferenceDate = new Date(3, 6, 2015); // a friday

    public bool IsPayDate(Date date) {
        if (date.DayOfWeek != DayOfWeek.Friday) {
            return false;
        }

        var weekSince = date.DaySince(ReferenceDate) / 7;
        if (weekSince % 2 == 0) {
            return true;
        }

        return false;
    }

    public Date GetPayPeriodStartDate(Date payPeriod) {
        return payPeriod.AddDays(-13);
    }
}
