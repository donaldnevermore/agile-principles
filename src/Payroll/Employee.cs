namespace AgileSoftwareDevelopment.Payroll
{
    public class Employee
    {
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public HoldMethod Method { get; set; }
        public string Name { get; }
        public UnionAffiliation Affiliation { get; set; }

        private readonly int empId;
        private readonly string address;

        public Employee(int empId, string name, string address)
        {
            this.empId = empId;
            Name = name;
            this.address = address;
        }
    }
}
