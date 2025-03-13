using Ch30.PayrollDatabase;
using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction {
    public ChangeUnaffiliatedTransaction(int empId) : base(empId) {
    }

    protected override Affiliation GetAffiliation() {
        return PayrollFactory.Scope.PayrollFactory.MakeNoAffiliation();
    }

    protected override void RecordMembership(Employee e) {
        var memberId = e.Affiliation.GetMemberId();

        if (memberId == null) {
            return;
        }

        PayrollDatabase.Scope.DatabaseInstance.RemoveUnionMember(memberId.Value);
    }
}
