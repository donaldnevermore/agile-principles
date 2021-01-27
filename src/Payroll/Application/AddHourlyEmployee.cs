using AgileSoftwareDevelopment.Payroll.Classifications;
using AgileSoftwareDevelopment.Payroll.Domain;
using AgileSoftwareDevelopment.Payroll.Schedules;

namespace AgileSoftwareDevelopment.Payroll.Application {
    public class AddHourlyEmployee : AddEmployeeTransaction {
        private readonly double hourlyRate;

        public AddHourlyEmployee(int id, string name, string address, double hourlyRate) : base(id, name, address) {
            this.hourlyRate = hourlyRate;
        }

        protected override PayrollClassification MakeClassification() {
            return new HourlyClassification(hourlyRate);
        }

        protected override PayrollSchedule MakeSchedule() {
            return new WeeklySchedule();
        }
    }
}
