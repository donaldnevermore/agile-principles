using System;
using System.Collections.Generic;
using AgileSoftwareDevelopment.Payroll.Domain;

namespace AgileSoftwareDevelopment.Payroll.Affiliations {
    public class UnionAffiliation : Affiliation {
        public int MemberId { get; }
        public double Dues { get; }

        private readonly Dictionary<DateTime, ServiceCharge> serviceCharges = new();

        public UnionAffiliation() {
        }

        public UnionAffiliation(int memberId, double dues) {
            MemberId = memberId;
            Dues = dues;
        }

        public ServiceCharge GetServiceCharge(DateTime date) {
            return serviceCharges[date];
        }

        public void AddServiceCharge(ServiceCharge serviceCharge) {
            serviceCharges.Add(serviceCharge.Date, serviceCharge);
        }

        public double CalculateDeductions(Paycheck paycheck) {
            var fridays = NumberOfFridaysInPayPeriod(paycheck.PayPeriodStartDate, paycheck.PayPeriodEndDate);
            var totalDues = Dues * fridays;

            foreach (var serviceCharge in serviceCharges.Values) {
                if (DateUtil.IsInPayPeriod(serviceCharge.Date, paycheck)) {
                    totalDues += serviceCharge.Amount;
                }
            }

            return totalDues;
        }

        private static int NumberOfFridaysInPayPeriod(DateTime payPeriodStart, DateTime payPeriodEnd) {
            var fridays = 0;
            for (var day = payPeriodStart; day <= payPeriodEnd; day = day.AddDays(1)) {
                if (day.DayOfWeek == DayOfWeek.Friday) {
                    fridays++;
                }
            }

            return fridays;
        }
    }
}
