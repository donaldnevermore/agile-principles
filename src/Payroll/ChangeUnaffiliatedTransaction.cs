namespace AgileSoftwareDevelopment.Payroll
{
    public class ChangeUnaffiliatedTransaction : ChangeAffiliationTransaction
    {
        public ChangeUnaffiliatedTransaction(int empId) : base(empId)
        {
        }

        protected override Affiliation Affiliation => new NoAffiliation();

        protected override void RecordMembership(Employee e)
        {
            var affiliation = e.Affiliation;
            if (affiliation is UnionAffiliation unionAffiliation)
            {
                var memberId = unionAffiliation.MemberId;
                PayrollDatabase.RemoveUnionMember(memberId);
            }
        }
    }
}
