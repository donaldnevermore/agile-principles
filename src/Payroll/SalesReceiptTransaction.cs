using System;
using AgileSoftwareDevelopment.Payroll.Classifications;

namespace AgileSoftwareDevelopment.Payroll {
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

            if (e == null) {
                throw new InvalidOperationException("No such employee");
            }

            var cc = e.Classification as CommissionedClassification;

            if (cc == null) {
                throw new InvalidOperationException("Tried to add sales receipt to non-commissioned employee");
            }

            cc.AddSalesReceipt(new SalesReceipt(date, amount));
        }
    }
}
