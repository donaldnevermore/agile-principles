using System;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class CommissionedClassification : PaymentClassification
    {
        public double Salary { get; }
        public double CommissionRate { get; }

        private Dictionary<DateTime, SalesReceipt> salesReceipts = new Dictionary<DateTime, SalesReceipt>();

        public CommissionedClassification(double salary, double commissionRate)
        {
            Salary = salary;
            CommissionRate = commissionRate;
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt)
        {
            salesReceipts.Add(salesReceipt.Date, salesReceipt);
        }

        public SalesReceipt GetSalesReceipt(DateTime date)
        {
            return salesReceipts[date];
        }

        public override double CalculatePay(Paycheck paycheck)
        {
            var totalPay = 0.0;

            if (IsSalaryInPayPeriod(paycheck))
            {
                totalPay += Salary;
            }

            foreach (var salesReceipt in salesReceipts.Values)
            {
                if (InInPayPeriod(salesReceipt, paycheck))
                {
                    totalPay += salesReceipt.Amount * CommissionRate;
                }
            }

            return totalPay;
        }

        private bool IsSalaryInPayPeriod(Paycheck paycheck)
        {
            var date = paycheck.PayDate;
            if (DateUtil.IsLastDayOfMonth(date))
            {
                return true;
            }

            var lastDayOfPreviousMonth = date.AddDays(-date.Day);
            if (DateUtil.IsInPayPeriod(lastDayOfPreviousMonth, paycheck))
            {
                return true;
            }

            return false;
        }

        private bool InInPayPeriod(SalesReceipt salesReceipt, Paycheck paycheck)
        {
            return DateUtil.IsInPayPeriod(salesReceipt.Date, paycheck);
        }
    }
}
