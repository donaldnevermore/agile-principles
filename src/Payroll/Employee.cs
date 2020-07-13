﻿namespace AgileSoftwareDevelopment.Payroll
{
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public HoldMethod Method { get; set; }
        public UnionAffiliation Affiliation { get; set; }

        private readonly int empId;

        public Employee(int empId, string name, string address)
        {
            this.empId = empId;
            Name = name;
            Address = address;
        }
    }
}
