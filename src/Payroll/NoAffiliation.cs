namespace AgileSoftwareDevelopment.Payroll
{
    public class NoAffiliation : Affiliation
    {
        public override double CalculateDeductions(Paycheck paycheck)
        {
            return 0.0;
        }
    }
}
