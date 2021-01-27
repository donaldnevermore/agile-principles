using System;

namespace AgileSoftwareDevelopment.Payroll {
    public class Paycheck {
        public double GrossPay { get; set; }
        public double Deductions { get; set; }
        public double NetPay { get; set; }
        public DateTime PayDate { get; }
        public DateTime PayPeriodStartDate { get; }
        public DateTime PayPeriodEndDate { get; }

        public Paycheck(DateTime startDate, DateTime payDate) {
            PayPeriodStartDate = startDate;
            PayPeriodEndDate = payDate;
            PayDate = payDate;
        }

        public string GetField(string field) {
            // TODO:
            return "Hold";
        }
    }
}
