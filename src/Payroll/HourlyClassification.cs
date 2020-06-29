namespace AgileSoftwareDevelopment.Payroll
{
    public class HourlyClassification : PaymentClassification
    {
        public double HourlyRate { get; }

        public HourlyClassification(double hourlyRate)
        {
            HourlyRate = hourlyRate;
        }
    }
}
