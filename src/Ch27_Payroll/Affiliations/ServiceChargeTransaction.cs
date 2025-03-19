using System;
using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Affiliations {
    public class ServiceChargeTransaction : Transaction {
        private readonly int memberId;
        private readonly DateTime time;
        private readonly double charge;

        public ServiceChargeTransaction(int id, DateTime time, double charge, PayrollDatabase database):base(database) {
            this.memberId = id;
            this.time = time;
            this.charge = charge;
        }

        public override void Execute() {
            var e = database.GetUnionMember(memberId);
            if (e is null) {
                throw new InvalidOperationException("No such union member.");
            }

            if (e.Affiliation is UnionAffiliation ua) {
                ua.AddServiceCharge(new ServiceCharge(time, charge));
            }else {
                throw new InvalidOperationException(
                    "Tries to add service charge to union member without a union affiliation.");
            }


        }
    }
}
