namespace AgileSoftwareDevelopment.Payroll
{
    public class SalariedClassification : PaymentClassification
    {
        public double Salary { get; }

        public SalariedClassification(double salary)
        {
            Salary = salary;
        }
    }
}
