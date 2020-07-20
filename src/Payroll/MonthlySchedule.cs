using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class MonthlySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return IsLastDayOfMonth(payDate);
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-date.Day);
        }

        private bool IsLastDayOfMonth(DateTime date)
        {
            var m1 = date.Month;
            var m2 = date.AddDays(1).Month;
            return m1 != m2;
        }
    }
}
