namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private readonly int memberId;
        private readonly double dues;

        public ChangeMemberTransaction(int empId, int memberId, double dues) : base(empId)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

        protected override Affiliation Affiliation => new UnionAffiliation(memberId, dues);

        protected override void RecordMembership(Employee e)
        {
            PayrollDatabase.AddUnionMember(memberId, e);
        }
    }
}
