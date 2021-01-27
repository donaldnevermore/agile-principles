using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Affiliations {
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction {
        public ChangeAffiliationTransaction(int empId) : base(empId) {
        }

        protected override void Change(Employee e) {
            RecordMembership(e);
            e.Affiliation = Affiliation;
        }

        protected abstract Affiliation Affiliation { get; }
        protected abstract void RecordMembership(Employee e);
    }
}
