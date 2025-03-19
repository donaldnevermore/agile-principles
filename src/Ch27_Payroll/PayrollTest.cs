using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgilePrinciples.Payroll.Domain;
using AgilePrinciples.Payroll.Affiliations;
using AgilePrinciples.Payroll.Application;
using AgilePrinciples.Payroll.Classifications;
using AgilePrinciples.Payroll.Methods;
using AgilePrinciples.Payroll.Schedules;

namespace AgilePrinciples.Payroll;

[TestClass]
public class PayrollTest {
    private InMemoryPayrollDatabase database;

    [TestInitialize]
    public void SetUp() {
        database = new InMemoryPayrollDatabase();
    }

    [TestMethod]
    public void TestAddSalariedEmployee() {
        const int empId = 1;
        var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00, database);
        t.Execute();

        var e = database.GetEmployee(empId);
        Assert.AreEqual("Bob", e.Name);

        var pc = e.Classification;
        Assert.IsTrue(pc is SalariedClassification);

        var sc = pc as SalariedClassification;
        Assert.AreEqual(1000.00, sc.Salary, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is MonthlySchedule);

        var pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }

    [TestMethod]
    public void TestAddHourlyEmployee() {
        const int empId = 2;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 0.5, database);
        t.Execute();

        var e = database.GetEmployee(empId);
        Assert.AreEqual("Bill", e.Name);

        var pc = e.Classification;
        Assert.IsTrue(pc is HourlyClassification);

        var hc = pc as HourlyClassification;
        Assert.AreEqual(0.5, hc.HourlyRate, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is WeeklySchedule);

        var pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }

    [TestMethod]
    public void TestAddCommissionedEmployee() {
        const int empId = 3;
        var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500.00, 3.2, database);
        t.Execute();

        var e = database.GetEmployee(empId);
        Assert.AreEqual("Bill", e.Name);

        var pc = e.Classification;
        Assert.IsTrue(pc is CommissionedClassification);

        var cc = pc as CommissionedClassification;
        Assert.AreEqual(2500.00, cc.BaseRate, 0.001);
        Assert.AreEqual(3.2, cc.CommissionRate, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is BiweeklySchedule);

        var pm = e.Method;
        Assert.IsTrue(pm is HoldMethod);
    }

    [TestMethod]
    public void TestDeleteEmployee() {
        const int empId = 4;
        var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2, database);
        t.Execute();

        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);

        var dt = new DeleteEmployeeTransaction(empId, database);
        dt.Execute();

        e = database.GetEmployee(empId);
        Assert.IsNull(e);
    }

    [TestMethod]
    public void TestTimeCardTransaction() {
        const int empId = 5;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        var tct = new TimeCardTransaction(new DateTime(2020, 7, 31), 8.0, empId, database);
        tct.Execute();

        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);

        var pc = e.Classification;
        Assert.IsTrue(pc is HourlyClassification);
        var hc = pc as HourlyClassification;

        var tc = hc.GetTimeCard(new DateTime(2020, 7, 31));
        Assert.IsNotNull(tc);
        Assert.AreEqual(8.0, tc.Hours, 0.001);
    }

    [TestMethod]
    public void TestSalesReceiptTransaction() {
        const int empId = 6;
        var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500.00, 3.2, database);
        t.Execute();
        var srt = new SalesReceiptTransaction(new DateTime(2020, 7, 31), 100.00, empId, database);
        srt.Execute();

        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);

        var pc = e.Classification;
        Assert.IsTrue(pc is CommissionedClassification);
        var cc = pc as CommissionedClassification;

        var sc = cc.GetSalesReceipt(new DateTime(2020, 7, 31));
        Assert.IsNotNull(sc);
        Assert.AreEqual(100.00, sc.SaleAmount, 0.001);
    }

    [TestMethod]
    public void TestAddServiceCharge() {
        const int empId = 7;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var af = new UnionAffiliation();
        e.Affiliation = af;
        const int memberId = 86;
        database.AddUnionMember(memberId, e);
        var sct = new ServiceChargeTransaction(memberId, new DateTime(2020, 8, 8), 12.95, database);
        sct.Execute();
        var sc = af.GetServiceCharge(new DateTime(2020, 8, 8));
        Assert.IsNotNull(sc);
        Assert.AreEqual(12.95, sc.Amount, 0.001);
    }

    [TestMethod]
    public void TestChangeNameTransaction() {
        const int empId = 8;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        var cnt = new ChangeNameTransaction(empId, "Bob", database);
        cnt.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        Assert.AreEqual("Bob", e.Name);
    }

    [TestMethod]
    public void TestChangeAddressTransaction() {
        const int empId = 9;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        var cat = new ChangeAddressTransaction(empId, "Work", database);
        cat.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        Assert.AreEqual("Work", e.Address);
    }

    [TestMethod]
    public void TestChangeHourlyTransaction() {
        const int empId = 10;
        var t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 3.2, database);
        t.Execute();
        var cht = new ChangeHourlyTransaction(empId, 27.52, database);
        cht.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pc = e.Classification;
        Assert.IsNotNull(pc);
        Assert.IsTrue(pc is HourlyClassification);
        var hc = pc as HourlyClassification;
        Assert.AreEqual(27.52, hc.HourlyRate, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is WeeklySchedule);
    }

    [TestMethod]
    public void TestChangeSalariedTransaction() {
        const int empId = 11;
        var t = new AddHourlyEmployee(empId, "Lance", "Home", 27.52, database);
        t.Execute();
        var cst = new ChangeSalariedTransaction(empId, 2500.00, database);
        cst.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pc = e.Classification;
        Assert.IsNotNull(pc);
        Assert.IsTrue(pc is SalariedClassification);
        var sc = pc as SalariedClassification;
        Assert.AreEqual(2500.00, sc.Salary, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is MonthlySchedule);
    }

    [TestMethod]
    public void TestChangeCommissionedTransaction() {
        const int empId = 12;
        var t = new AddHourlyEmployee(empId, "Lance", "Home", 27.52, database);
        t.Execute();
        var cct = new ChangeCommissionedTransaction(empId, 2500.00, 3.2, database);
        cct.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pc = e.Classification;
        Assert.IsNotNull(pc);
        Assert.IsTrue(pc is CommissionedClassification);
        var cc = pc as CommissionedClassification;
        Assert.AreEqual(2500.00, cc.BaseRate, 0.001);
        Assert.AreEqual(3.2, cc.CommissionRate, 0.001);
        var ps = e.Schedule;
        Assert.IsTrue(ps is BiweeklySchedule);
    }

    [TestMethod]
    public void TestChangeDirectTransaction() {
        const int empId = 13;
        var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00, database);
        t.Execute();
        var cdt = new ChangeDirectTransaction(empId, database);
        cdt.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pm = e.Method;
        Assert.IsNotNull(pm);
        Assert.IsTrue(pm is DirectDepositMethod);
    }

    [TestMethod]
    public void TestChangeMailTransaction() {
        const int empId = 14;
        var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00, database);
        t.Execute();
        var cmt = new ChangeMailTransaction(empId, database);
        cmt.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pm = e.Method;
        Assert.IsNotNull(pm);
        Assert.IsTrue(pm is MailMethod);
    }

    [TestMethod]
    public void TestChangeHoldTransaction() {
        const int empId = 15;
        var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00, database);
        t.Execute();
        var cmt = new ChangeMailTransaction(empId, database);
        cmt.Execute();
        var cht = new ChangeHoldTransaction(empId, database);
        cht.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var pm = e.Method;
        Assert.IsNotNull(pm);
        Assert.IsTrue(pm is HoldMethod);
    }

    [TestMethod]
    public void TestChangeUnionMember() {
        const int empId = 16;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        const int memberId = 7743;
        var cmt = new ChangeMemberTransaction(empId, memberId, 99.42, database);
        cmt.Execute();
        var e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        var affiliation = e.Affiliation;
        Assert.IsNotNull(affiliation);
        Assert.IsTrue(affiliation is UnionAffiliation);
        var uf = affiliation as UnionAffiliation;
        Assert.AreEqual(99.42, uf.Dues, 0.001);
        var member = database.GetUnionMember(memberId);
        Assert.IsNotNull(member);
        Assert.AreEqual(e, member);
    }

    [TestMethod]
    public void TestPaySingleSalariedEmployee() {
        const int empId = 17;
        var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00, database);
        t.Execute();
        var payDate = new DateTime(2020, 11, 30);
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        var pc = pt.GetPaycheck(empId);
        Assert.IsNotNull(pc);
        Assert.AreEqual(payDate, pc.PayDate);
        Assert.AreEqual(1000.00, pc.GrossPay, 0.001);
        Assert.AreEqual("Hold", pc.GetField("Disposition"));
        Assert.AreEqual(0.0, pc.Deductions, 0.001);
        Assert.AreEqual(1000.00, pc.NetPay, 0.001);
    }

    [TestMethod]
    public void TestPaySingleSalariedEmployeeOnWrongDate() {
        const int empId = 18;
        var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00, database);
        t.Execute();
        var payDate = new DateTime(2020, 11, 29);
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        var pc = pt.GetPaycheck(empId);
        Assert.IsNull(pc);
    }

    [TestMethod]
    public void TestPayingSingleHourlyEmployeeNoTimeCards() {
        const int empId = 19;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        var payDate = new DateTime(2020, 11, 6);
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 0.0);
    }

    private static void ValidatePaycheck(PaydayTransaction pt, int empId, DateTime payDate, double pay) {
        var pc = pt.GetPaycheck(empId);
        Assert.IsNotNull(pc);

        Assert.AreEqual(payDate, pc.PayDate);
        Assert.AreEqual(pay, pc.GrossPay, 0.001);
        Assert.AreEqual("Hold", pc.GetField("Disposition"));
        Assert.AreEqual(0.0, pc.Deductions, 0.001);
        Assert.AreEqual(pay, pc.NetPay, 0.001);
    }

    [TestMethod]
    public void TestPaySingleHourlyEmployeeOneTimeCard() {
        const int empId = 20;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();

        // Friday
        var payDate = new DateTime(2020, 11, 6);
        var tc = new TimeCardTransaction(payDate, 2.0, empId, database);
        tc.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 30.5);
    }

    [TestMethod]
    public void TestPaySingleHourlyEmployeeOvertimeOneTimeCard() {
        const int empId = 21;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        // Friday
        var payDate = new DateTime(2020, 11, 6);

        var tc = new TimeCardTransaction(payDate, 9.0, empId, database);
        tc.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, (8 + 1.5) * 15.25);
    }

    [TestMethod]
    public void TestPaySingleHourlyEmployeeOnWrongDate() {
        const int empId = 22;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        // Thursday
        var payDate = new DateTime(2020, 11, 5);

        var tc = new TimeCardTransaction(payDate, 9.0, empId, database);
        tc.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();

        var pc = pt.GetPaycheck(empId);
        Assert.IsNull(pc);
    }

    [TestMethod]
    public void TestPaySingleHourlyEmployeeTwoTimeCards() {
        const int empId = 23;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        // Friday
        var payDate = new DateTime(2020, 11, 6);

        var tc = new TimeCardTransaction(payDate, 2.0, empId, database);
        tc.Execute();
        var tc2 = new TimeCardTransaction(payDate.AddDays(-1), 5.0, empId, database);
        tc2.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 7 * 15.25);
    }

    [TestMethod]
    public void TestPaySingleHourlyEmployeeWithTimeCardsSpanningTwoPayPeriods() {
        const int empId = 24;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        // Friday
        var payDate = new DateTime(2020, 11, 6);
        var dateInPreviousPayPeriod = new DateTime(2020, 10, 30);

        var tc = new TimeCardTransaction(payDate, 2.0, empId, database);
        tc.Execute();
        var tc2 = new TimeCardTransaction(dateInPreviousPayPeriod, 5.0, empId, database);
        tc2.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 2 * 15.25);
    }

    [TestMethod]
    public void TestSalariedUnionMemberDues() {
        const int empId = 25;
        var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00, database);
        t.Execute();
        const int memberId = 7734;
        var cmt = new ChangeMemberTransaction(empId, memberId, 9.42, database);
        cmt.Execute();
        var payDate = new DateTime(2020, 7, 31);
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();

        var pc = pt.GetPaycheck(empId);
        Assert.IsNotNull(pc);
        Assert.AreEqual(payDate, pc.PayDate);
        Assert.AreEqual(1000.0, pc.GrossPay, 0.001);
        Assert.AreEqual("Hold", pc.GetField("Disposition"));
        Assert.AreEqual(5 * 9.42, pc.Deductions, 0.001);
        Assert.AreEqual(1000.0 - 5 * 9.42, pc.NetPay, 0.001);
    }

    [TestMethod]
    public void TestHourlyUnionMemberServiceCharge() {
        const int empId = 26;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.24, database);
        t.Execute();
        const int memberId = 7735;
        var cmt = new ChangeMemberTransaction(empId, memberId, 9.42, database);
        cmt.Execute();
        var payDate = new DateTime(2020, 11, 6);
        var sct = new ServiceChargeTransaction(memberId, payDate, 19.42, database);
        sct.Execute();
        var tct = new TimeCardTransaction(payDate, 8.0, empId, database);
        tct.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();

        var pc = pt.GetPaycheck(empId);
        Assert.IsNotNull(pc);
        Assert.AreEqual(payDate, pc.PayPeriodEndDate);
        Assert.AreEqual(8 * 15.24, pc.GrossPay, 0.001);
        Assert.AreEqual("Hold", pc.GetField("Disposition"));
        Assert.AreEqual(9.42 + 19.42, pc.Deductions, 0.001);
        Assert.AreEqual(8 * 15.24 - (9.42 + 19.42), pc.NetPay, 0.001);
    }

    [TestMethod]
    public void TestServiceChargesSpanningMultiplePayPeriods() {
        const int empId = 27;
        var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.24, database);
        t.Execute();

        const int memberId = 7736;
        var cmt = new ChangeMemberTransaction(empId, memberId, 9.42, database);
        cmt.Execute();

        var payDate = new DateTime(2020, 11, 6);
        var earlyDate = new DateTime(2020, 10, 30);
        var lateDate = new DateTime(2020, 11, 13);

        var sct = new ServiceChargeTransaction(memberId, payDate, 19.42, database);
        sct.Execute();
        var sctEarly = new ServiceChargeTransaction(memberId, earlyDate, 100.00, database);
        sctEarly.Execute();
        var sctLate = new ServiceChargeTransaction(memberId, lateDate, 200.00, database);
        sctLate.Execute();
        var tct = new TimeCardTransaction(payDate, 8.0, empId, database);
        tct.Execute();
        var pt = new PaydayTransaction(payDate, database);
        pt.Execute();

        var pc = pt.GetPaycheck(empId);
        Assert.IsNotNull(pc);
        Assert.AreEqual(payDate, pc.PayPeriodEndDate);
        Assert.AreEqual(8 * 15.24, pc.GrossPay, 0.001);
        Assert.AreEqual("Hold", pc.GetField("Disposition"));
        Assert.AreEqual(9.42 + 19.42, pc.Deductions, 0.001);
        Assert.AreEqual(8 * 15.24 - (9.42 + 19.42), pc.NetPay, 0.001);
    }

    [TestMethod]
    public void TestPayCommissionedEmployeeNoSalesReceipts() {
        const int empId = 28;
        AddCommissionedEmployee t = new AddCommissionedEmployee(
            empId, "Bill", "Home", 1500, 10, database);
        t.Execute();
        DateTime payDate = new DateTime(2001, 11, 16); // Payday
        PaydayTransaction pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 1500.0);
    }

    [TestMethod]
    public void TestPayCommissionedEmployeeOneSalesReceipt() {
        const int empId = 29;
        AddCommissionedEmployee t = new AddCommissionedEmployee(
            empId, "Bill", "Home", 1500, 10, database);
        t.Execute();
        DateTime payDate = new DateTime(2001, 11, 16); // Payday

        SalesReceiptTransaction sr =
            new SalesReceiptTransaction(payDate, 5000.00, empId, database);
        sr.Execute();
        PaydayTransaction pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 2000.00);
    }

    [TestMethod]
    public void TestPayCommissionedEmployeeTwoSalesReceipts() {
        const int empId = 30;
        AddCommissionedEmployee t = new AddCommissionedEmployee(
            empId, "Bill", "Home", 1500, 10, database);
        t.Execute();
        DateTime payDate = new DateTime(2001, 11, 16); // Payday

        SalesReceiptTransaction sr =
            new SalesReceiptTransaction(payDate, 5000.00, empId, database);
        sr.Execute();
        SalesReceiptTransaction sr2 = new SalesReceiptTransaction(
            payDate.AddDays(-1), 3500.00, empId, database);
        sr2.Execute();
        PaydayTransaction pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 2350.00);
    }

    [TestMethod]
    public void TestPayCommissionedEmployeeOnWrongDate() {
        const int empId = 31;
        AddCommissionedEmployee t = new AddCommissionedEmployee(
            empId, "Bill", "Home", 1500, 10, database);
        t.Execute();
        DateTime payDate = new DateTime(2001, 11, 9); // wrong friday

        SalesReceiptTransaction sr =
            new SalesReceiptTransaction(payDate, 5000.00, empId, database);
        sr.Execute();
        PaydayTransaction pt = new PaydayTransaction(payDate, database);
        pt.Execute();

        Paycheck pc = pt.GetPaycheck(empId);
        Assert.IsNull(pc);
    }

    [TestMethod]
    public void
        TestPaySingleCommissionedEmployeeWithReceiptsSpanningTwoPayPeriods() {
        int empId = 32;
        AddCommissionedEmployee t = new AddCommissionedEmployee(
            empId, "Bill", "Home", 1500, 10, database);
        t.Execute();
        DateTime payDate = new DateTime(2001, 11, 16); // Payday

        SalesReceiptTransaction sr =
            new SalesReceiptTransaction(payDate, 5000.00, empId, database);
        sr.Execute();
        SalesReceiptTransaction sr2 = new SalesReceiptTransaction(
            payDate.AddDays(-15), 3500.00, empId, database);
        sr2.Execute();
        PaydayTransaction pt = new PaydayTransaction(payDate, database);
        pt.Execute();
        ValidatePaycheck(pt, empId, payDate, 2000.00);
    }

    [TestMethod]
    public void ChangeUnaffiliatedMember() {
        int empId = 33;
        AddHourlyEmployee t =
            new AddHourlyEmployee(empId, "Bill", "Home", 15.25, database);
        t.Execute();
        int memberId = 7744;
        new ChangeMemberTransaction(empId, memberId, 99.42, database).Execute();
        ChangeUnaffiliatedTransaction cut =
            new ChangeUnaffiliatedTransaction(empId, database);
        cut.Execute();
        Employee e = database.GetEmployee(empId);
        Assert.IsNotNull(e);
        Affiliation affiliation = e.Affiliation;
        Assert.IsNotNull(affiliation);
        Assert.IsTrue(affiliation is NoAffiliation);
        Employee member = database.GetUnionMember(memberId);
        Assert.IsNull(member);
    }
}
