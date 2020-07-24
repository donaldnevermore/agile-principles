using AgileSoftwareDevelopment.Payroll.Domain;
using AgileSoftwareDevelopment.Payroll.Classifications;
using AgileSoftwareDevelopment.Payroll.Schedules;

namespace AgileSoftwareDevelopment.Payroll.Application
{
    public class AddCommissionedEmployee : AddEmployeeTransaction
    {
        private readonly double salary;
        private readonly double commissionRate;

        public AddCommissionedEmployee(int id, string name, string address, double salary, double commissionRate) :
            base(id, name, address)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }

        protected override PayrollClassification MakeClassification()
        {
            return new CommissionedClassification(salary, commissionRate);
        }

        protected override PayrollSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}
