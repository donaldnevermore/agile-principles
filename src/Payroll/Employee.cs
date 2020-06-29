namespace AgileSoftwareDevelopment.Payroll
{
    public class Employee
    {
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public HoldMethod Method { get; set; }

        private readonly int empId;
        public string Name { get; }
        private readonly string address;

        public Employee(int empId, string name, string address)
        {
            this.empId = empId;
            Name = name;
            this.address = address;
        }
    }
}
