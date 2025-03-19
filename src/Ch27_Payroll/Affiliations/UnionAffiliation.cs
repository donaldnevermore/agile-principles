using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Affiliations;

public class UnionAffiliation : Affiliation {
    public int MemberId { get; }
    public double Dues { get; }

    private readonly Dictionary<DateTime, ServiceCharge> charges = new();

    public UnionAffiliation(int memberId, double dues) {
        MemberId = memberId;
        Dues = dues;
    }

    public UnionAffiliation()
        : this(-1, 0.0) {
    }

    public ServiceCharge GetServiceCharge(DateTime date) {
        return charges[date];
    }

    public void AddServiceCharge(ServiceCharge sc) {
        charges.Add(sc.Time, sc);
    }

    public double CalculateDeductions(Paycheck paycheck) {
        var fridays = NumberOfFridaysInPayPeriod(paycheck.PayPeriodStartDate, paycheck.PayPeriodEndDate);
        var totalDues = Dues * fridays;

        foreach (var serviceCharge in charges.Values) {
            if (DateUtil.IsInPayPeriod(serviceCharge.Time, paycheck.PayPeriodStartDate,
                    paycheck.PayPeriodEndDate)) {
                totalDues += serviceCharge.Amount;
            }
        }

        return totalDues;
    }

    private static int NumberOfFridaysInPayPeriod(DateTime payPeriodStart, DateTime payPeriodEnd) {
        var fridays = 0;
        for (var day = payPeriodStart; day <= payPeriodEnd; day = day.AddDays(1)) {
            if (day.DayOfWeek == DayOfWeek.Friday) {
                fridays++;
            }
        }

        return fridays;
    }
}
