using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class MonthlySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return DateUtil.IsLastDayOfMonth(payDate);
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-date.Day + 1);
        }
    }
}
