namespace AgileSoftwareDevelopment.Payroll.Domain {
    public interface Affiliation {
        double CalculateDeductions(Paycheck paycheck);
    }
}
