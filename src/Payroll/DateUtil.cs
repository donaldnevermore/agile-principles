using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class DateUtil
    {
        public static bool IsInPayPeriod(DateTime theDate, Paycheck paycheck)
        {
            var payPeriodEndDate = paycheck.PayPeriodEndDate;
            var payPeriodStartDate = paycheck.PayPeriodStartDate;
            return theDate >= payPeriodStartDate && theDate <= payPeriodEndDate;
        }
    }
}
