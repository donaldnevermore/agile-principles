namespace AgileSoftwareDevelopment.Payroll
{
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
        public Affiliation Affiliation { get; set; }

        private readonly int empId;

        public Employee(int empId, string name, string address)
        {
            this.empId = empId;
            Name = name;
            Address = address;
        }
    }
}
