using System;
using AgileSoftwareDevelopment.Payroll.Affiliations;

namespace AgileSoftwareDevelopment.Payroll {
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
            if (e == null) {
                throw new InvalidOperationException("No such union member.");
            }

            UnionAffiliation ua = null;
            if (e.Affiliation is UnionAffiliation) {
                ua = e.Affiliation as UnionAffiliation;
            }

            if (ua == null) {
                throw new InvalidOperationException(
                    "Tries to add service charge to union member without a union affiliation.");
            }

            ua.AddServiceCharge(new ServiceCharge(time, charge));
        }
    }
}
