using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class WeeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return payDate.DayOfWeek == DayOfWeek.Friday;
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            return date.AddDays(-5);
        }
    }
}
