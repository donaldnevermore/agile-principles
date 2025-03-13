using System;

namespace AgilePrinciples.Payroll.Classifications {
    public class SalesReceipt {
        public DateTime Date { get; }
        public double Amount { get; }

        public SalesReceipt(DateTime date, double amount) {
            Date = date;
            Amount = amount;
        }
    }
}
