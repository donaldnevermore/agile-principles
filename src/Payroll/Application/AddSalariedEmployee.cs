using AgilePrinciples.Payroll.Classifications;
using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Application {
    public class AddSalariedEmployee : AddEmployeeTransaction {
        private readonly double salary;

        public AddSalariedEmployee(int id, string name, string address, double salary) : base(id, name, address) {
            this.salary = salary;
        }

        protected override PayrollClassification MakeClassification() {
            return new SalariedClassification(salary);
        }

        protected override PayrollSchedule MakeSchedule() {
            return new MonthlySchedule();
        }
    }
}
