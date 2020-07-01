namespace AgileSoftwareDevelopment.Payroll
{
    public class CommissionedClassification : PaymentClassification
    {
        public double Salary { get; }
        public double CommissionRate { get; }

        public CommissionedClassification(double salary, double commissionRate)
        {
            Salary = salary;
            CommissionRate = commissionRate;
        }
    }
}
