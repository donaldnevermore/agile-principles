namespace AgilePrinciples.Payroll.Domain {
    public interface Affiliation {
        double CalculateDeductions(Paycheck paycheck);
    }
}
