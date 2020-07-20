using System;

namespace AgileSoftwareDevelopment.Payroll
{
    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentClassification Classification { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public PaymentMethod Method { get; set; }
        public Affiliation Affiliation { get; set; } = new NoAffiliation();

        private readonly int empId;

        public Employee(int empId, string name, string address)
        {
            this.empId = empId;
            Name = name;
            Address = address;
        }

        public void Payday(Paycheck paycheck)
        {
            var grossPay = Classification.CalculatePay(paycheck);
            var deductions = Affiliation.CalculateDeductions(paycheck);
            var netPay = grossPay - deductions;
            paycheck.GrossPay = grossPay;
            paycheck.Deductions = deductions;
            paycheck.NetPay = netPay;
            Method.Pay(paycheck);
        }

        public bool IsPayDate(DateTime payDate)
        {
            return Schedule.IsPayDate(payDate);
        }

        public DateTime GetPayPeriodStartDate(DateTime date)
        {
            return Schedule.GetPayPeriodStartDate(date);
        }
    }
}
