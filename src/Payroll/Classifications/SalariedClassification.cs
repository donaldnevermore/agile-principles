﻿using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Classifications {
    public class SalariedClassification : PayrollClassification {
        public double Salary { get; }

        public SalariedClassification(double salary) {
            Salary = salary;
        }

        public double CalculatePay(Paycheck paycheck) {
            return Salary;
        }
    }
}
