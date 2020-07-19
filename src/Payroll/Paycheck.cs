using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class Paycheck
    {
        public double GrossPay { get; set; }
        public double Deductions { get; set; }
        public double NetPay { get; set; }
        public DateTime PayDate { get; }

        public Paycheck(DateTime payDate)
        {
            PayDate = payDate;
        }

        public string GetField(string field)
        {
            return "Hold";
        }
    }
}
