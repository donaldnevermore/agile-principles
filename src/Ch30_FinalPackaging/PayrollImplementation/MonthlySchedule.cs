using Ch30.CommonTypes;
using Ch30.PayrollDomain;

namespace Ch30.PayrollImplementation;

public class MonthlySchedule : PaymentSchedule {
    public bool IsPayDate(Date date) {
        return IsLastDayOfMonth(date);
    }

    private bool IsLastDayOfMonth(Date date) {
        return date.AddDays(1).Month != date.Month;
    }

    public Date GetPayPeriodStartDate(Date payPeriod) {
        return payPeriod.AddMonth(-1).AddDays(1);
    }
}
