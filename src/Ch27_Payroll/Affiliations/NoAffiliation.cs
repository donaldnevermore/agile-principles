using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Affiliations;

public class NoAffiliation : Affiliation {
    public double CalculateDeductions(Paycheck paycheck) {
        return 0;
    }
}
