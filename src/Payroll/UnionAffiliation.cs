using System;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class UnionAffiliation
    {
        private Dictionary<DateTime, ServiceCharge> serviceCharges = new Dictionary<DateTime, ServiceCharge>();

        public ServiceCharge GetServiceCharge(DateTime date)
        {
            return serviceCharges[date];
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            serviceCharges.Add(serviceCharge.Date, serviceCharge);
        }
    }
}
