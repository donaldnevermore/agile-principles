using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Affiliations {
    public class NoAffiliation : Affiliation {
        public double CalculateDeductions(Paycheck paycheck) {
            return 0.0;
        }
    }
}
