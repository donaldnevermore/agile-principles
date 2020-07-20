using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return true;
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-14);
        }
    }
}
