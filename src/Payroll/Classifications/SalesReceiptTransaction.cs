using System;
using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications {
    public class SalesReceiptTransaction : Transaction {
        private readonly DateTime date;
        private readonly double amount;
        private readonly int empId;

        public SalesReceiptTransaction(DateTime date, double amount, int empId) {
            this.date = date;
            this.amount = amount;
            this.empId = empId;
        }

        public void Execute() {
            var e = PayrollDatabase.GetEmployee(empId);

            if (e is null) {
                throw new InvalidOperationException("No such employee");
            }


            if (e.Classification is CommissionedClassification cc) {
                cc.AddSalesReceipt(new SalesReceipt(date, amount));
            }
            else {
                throw new InvalidOperationException("Tried to add sales receipt to non-commissioned employee");
            }
        }
    }
}
