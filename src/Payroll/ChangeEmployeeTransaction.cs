using System;
using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll {
    public abstract class ChangeEmployeeTransaction : Transaction {
        private readonly int empId;

        public ChangeEmployeeTransaction(int empId) {
            this.empId = empId;
        }

        public void Execute() {
            var e = PayrollDatabase.GetEmployee(empId);
            if (e is null) {
                throw new InvalidOperationException("No such employee.");
            }

            Change(e);
        }

        protected abstract void Change(Employee e);
    }
}
