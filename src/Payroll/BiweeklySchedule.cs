using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class BiweeklySchedule : PaymentSchedule
    {
        private DateTime? previousPayDate = null;

        public override bool IsPayDate(DateTime payDate)
        {
            if (payDate.DayOfWeek != DayOfWeek.Friday)
            {
                return false;
            }

            // First pay or every other week
            if (previousPayDate == null || (payDate - previousPayDate == TimeSpan.FromDays(14)))
            {
                previousPayDate = payDate;
                return true;
            }

            return false;
        }

        public override DateTime GetPayPeriodStartDate(DateTime date)
        {
            // Avoid duplicate pay.
            return date.AddDays(-13);
        }
    }
}
