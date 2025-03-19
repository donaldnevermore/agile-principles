using AgilePrinciples.Payroll.Classifications;
using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll.Application;

public class AddCommissionedEmployee : AddEmployeeTransaction {
    private readonly double commissionRate;
    private readonly double baseRate;

    public AddCommissionedEmployee(int id, string name, string address, double baseRate, double commissionRate,
        PayrollDatabase database)
        : base(id, name, address, database) {
        this.baseRate = baseRate;
        this.commissionRate = commissionRate;
    }

    protected override PaymentClassification MakeClassification() {
        return new CommissionedClassification(baseRate, commissionRate);
    }

    protected override PaymentSchedule MakeSchedule() {
        return new BiweeklySchedule();
    }
}
