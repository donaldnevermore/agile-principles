using System;
using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Affiliations {
    public class ServiceChargeTransaction : Transaction {
        private readonly int memberId;
        private readonly DateTime time;
        private readonly double charge;

        public ServiceChargeTransaction(int id, DateTime time, double charge) {
            this.memberId = id;
            this.time = time;
            this.charge = charge;
        }

        public void Execute() {
            var e = PayrollDatabase.GetUnionMember(memberId);
            if (e is null) {
                throw new InvalidOperationException("No such union member.");
            }

            UnionAffiliation ua = null;
            if (e.Affiliation is UnionAffiliation) {
                ua = e.Affiliation as UnionAffiliation;
            }

            if (ua is null) {
                throw new InvalidOperationException(
                    "Tries to add service charge to union member without a union affiliation.");
            }

            ua.AddServiceCharge(new ServiceCharge(time, charge));
        }
    }
}
