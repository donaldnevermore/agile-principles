﻿namespace AgilePrinciples.Payroll.Domain;

public class NoAffiliation : Affiliation {
    public double CalculateDeductions(Paycheck paycheck) {
        return 0;
    }
}
