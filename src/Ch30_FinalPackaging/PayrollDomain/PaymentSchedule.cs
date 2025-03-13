using Ch30.CommonTypes;

namespace Ch30.PayrollDomain;

public interface PaymentSchedule {
    bool IsPayDate(Date date);

    Date GetPayPeriodStartDate(Date payPeriod);
}
