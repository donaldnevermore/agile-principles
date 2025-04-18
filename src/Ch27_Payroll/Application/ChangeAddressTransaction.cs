﻿using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll.Application;

public class ChangeAddressTransaction : ChangeEmployeeTransaction {
    private readonly string newAddress;

    public ChangeAddressTransaction(int id, string newAddress, PayrollDatabase database) : base(id, database) {
        this.newAddress = newAddress;
    }

    protected override void Change(Employee e) {
        e.Address = newAddress;
    }
}
