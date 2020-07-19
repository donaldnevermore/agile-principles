using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class BiweeklySchedule : PaymentSchedule
    {
        public override bool IsPayDate(DateTime payDate)
        {
            return true;
        }
    }
}
