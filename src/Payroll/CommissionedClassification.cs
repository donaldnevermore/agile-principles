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
    }
}
