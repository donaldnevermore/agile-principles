using System;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class UnionAffiliation : Affiliation
    {
        public int MemberId { get; }
        public double Dues { get; }

        private Dictionary<DateTime, ServiceCharge> serviceCharges = new Dictionary<DateTime, ServiceCharge>();

        public UnionAffiliation()
        {
        }

        public UnionAffiliation(int memberId, double dues)
        {
            MemberId = memberId;
            Dues = dues;
        }

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return serviceCharges[date];
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            serviceCharges.Add(serviceCharge.Date, serviceCharge);
        }

        public override double CalculateDeductions(Paycheck paycheck)
        {
            return 0.0;
        }
    }
}
