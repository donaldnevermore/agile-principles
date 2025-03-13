using Ch30.CommonTypes;
using Ch30.PayrollDatabase;
using Ch30.PayrollDomain;
using Ch30.TransactionApplication;

namespace Ch30.TransactionImplementation;

public class ServiceChargeTransaction : Transaction {
    private decimal _charge;
    private Date _forDate;
    private int _memberId;

    public ServiceChargeTransaction(int memberId, Date forDate, decimal charge) {
        _memberId = memberId;
        _forDate = forDate;
        _charge = charge;
    }

    public void Execute() {
        Employee e = PayrollDatabase.Scope.DatabaseInstance.GetUnionMember(_memberId);

        e.Affiliation.AddServiceCharge(_forDate, _charge);
    }
}
