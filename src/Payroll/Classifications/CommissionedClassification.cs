using System;
using System.Collections.Generic;
using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Classifications {
    public class CommissionedClassification : PayrollClassification {
        public double Salary { get; }
        public double CommissionRate { get; }

        private readonly Dictionary<DateTime, SalesReceipt> salesReceipts = new();

        public CommissionedClassification(double salary, double commissionRate) {
            Salary = salary;
            CommissionRate = commissionRate;
        }

        public void AddSalesReceipt(SalesReceipt salesReceipt) {
            salesReceipts.Add(salesReceipt.Date, salesReceipt);
        }

        public SalesReceipt GetSalesReceipt(DateTime date) {
            return salesReceipts[date];
        }

        public double CalculatePay(Paycheck paycheck) {
            var totalPay = 0.0;

            if (IsSalaryInPayPeriod(paycheck)) {
                totalPay += Salary;
            }

            foreach (var salesReceipt in salesReceipts.Values) {
                if (InInPayPeriod(salesReceipt, paycheck)) {
                    totalPay += salesReceipt.Amount * CommissionRate;
                }
            }

            return totalPay;
        }

        private static bool IsSalaryInPayPeriod(Paycheck paycheck) {
            var date = paycheck.PayDate;
            if (DateUtil.IsLastDayOfMonth(date)) {
                return true;
            }

            var lastDayOfPreviousMonth = date.AddDays(-date.Day);
            if (DateUtil.IsInPayPeriod(lastDayOfPreviousMonth, paycheck)) {
                return true;
            }

            return false;
        }

        private static bool InInPayPeriod(SalesReceipt salesReceipt, Paycheck paycheck) {
            return DateUtil.IsInPayPeriod(salesReceipt.Date, paycheck);
        }
    }
}
