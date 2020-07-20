using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public abstract class PaymentSchedule
    {
        public abstract bool IsPayDate(DateTime payDate);
        public abstract DateTime GetPayPeriodStartDate(DateTime date);
    }
}
