using AgilePrinciples.Payroll.Classifications;
using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Application {
    public class AddCommissionedEmployee : AddEmployeeTransaction {
        private readonly double salary;
        private readonly double commissionRate;

        public AddCommissionedEmployee(int id, string name, string address, double salary, double commissionRate) :
            base(id, name, address) {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        protected override PayrollClassification MakeClassification() {
            return new CommissionedClassification(salary, commissionRate);
        }

        protected override PayrollSchedule MakeSchedule() {
            return new BiweeklySchedule();
        }
    }
}
