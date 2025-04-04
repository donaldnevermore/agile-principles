﻿using Ch30.PayrollDomain;

namespace Ch30.TransactionImplementation;

public class ChangeDirectTransaction : ChangeMethodTransaction {
    private string _account;
    private string _bank;

    public ChangeDirectTransaction(int empId, string bank, string account) : base(empId) {
        _bank = bank;
        _account = account;
    }

    protected override PaymentMethod GetMethod() {
        return PayrollFactory.Scope.PayrollFactory.MakeDirectMethod(_bank, _account);
    }
}
