using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Affiliations {
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction {
        public ChangeUnaffiliatedTransaction(int empId, PayrollDatabase database)
            : base(empId, database)
        {}

        protected override Affiliation Affiliation => new NoAffiliation();

        protected override void RecordMembership(Employee e) {
            var affiliation = e.Affiliation;
            if (affiliation is UnionAffiliation unionAffiliation) {
                var memberId = unionAffiliation.MemberId;
                database.RemoveUnionMember(memberId);
            }
        }
    }
}
