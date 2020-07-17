namespace AgileSoftwareDevelopment.Payroll
{
    public abstract class AddEmployeeTransaction : Transaction
    {
        private readonly int empId;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction(int empId, string name, string address)
        {
            this.empId = empId;
            this.name = name;
            this.address = address;
        }

        protected abstract PaymentClassification MakeClassification();
        protected abstract PaymentSchedule MakeSchedule();

        public void Execute()
        {
            var pc = MakeClassification();
            var ps = MakeSchedule();
            var pm = new HoldMethod();
            var na = new NoAffiliation();

            var e = new Employee(empId, name, address)
                {Classification = pc, Schedule = ps, Method = pm, Affiliation = na};
            PayrollDatabase.AddEmployee(empId, e);
        }
    }
}
