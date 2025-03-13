using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation ;

public class AddHourlyEmployee : AddEmployeeTransaction{
    private decimal _hourlyRate;

    public AddHourlyEmployee(int empId,string name,string address,decimal hourlyRate) : base(empId,name,address){
        _hourlyRate = hourlyRate;
    }

    protected override PaymentSchedule GetSchedule() {
        return PayrollFactory.Scope.PayrollFactory.MakeWeeklySchedule();

    }

    protected override PaymentClassification GetClassification() {
        return PayrollFactory.Scope.PayrollFactory.MakeHourlyClassification(_hourlyRate);

    }
}
