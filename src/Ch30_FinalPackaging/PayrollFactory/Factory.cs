namespace Ch30.PayrollFactory;

public interface Factory {
    Ch30.PayrollDomain.PaymentSchedule MakeBiweeklySchedule();
    Ch30.PayrollDomain.PaymentClassification MakeCommissionedClassification(decimal salary, decimal commissionRate);
    Ch30.PayrollDomain.PaymentMethod MakeDirectMethod(string bank, string account);
    Ch30.PayrollDomain.PaymentMethod MakeHoldMethod();
    Ch30.PayrollDomain.PaymentClassification MakeHourlyClassification(decimal hourlyRate);
    Ch30.PayrollDomain.PaymentMethod MakeMailMethod(string address);
    Ch30.PayrollDomain.PaymentSchedule MakeMonthlySchedule();
    Ch30.PayrollDomain.Affiliation MakeNoAffiliation();
    Ch30.PayrollDomain.PaymentClassification MakeSalariedClassification(decimal itsSalary);
    Ch30.PayrollDomain.Affiliation MakeUnionAffiliation(int memberId, decimal weeklyDues);
    Ch30.PayrollDomain.PaymentSchedule MakeWeeklySchedule();
}
