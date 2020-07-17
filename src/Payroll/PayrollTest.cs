using System;
using NUnit.Framework;

namespace AgileSoftwareDevelopment.Payroll
{
    public class PayrollTest
    {
        [Test]
        public void TestAddSalariedEmployee()
        {
            const int empId = 1;
            var t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
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

        [Test]
        public void TestAddHourlyEmployee()
        {
            const int empId = 2;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 0.5);
            t.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
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

        [Test]
        public void TestAddCommissionedEmployee()
        {
            const int empId = 3;
            var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500.00, 3.2);
            t.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bill", e.Name);

            var pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            var cc = pc as CommissionedClassification;
            Assert.AreEqual(2500.00, cc.Salary, 0.001);
            Assert.AreEqual(3.2, cc.CommissionRate, 0.001);
            var ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);

            var pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestDeleteEmployee()
        {
            const int empId = 4;
            var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500, 3.2);
            t.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            var dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }

        [Test]
        public void TestTimeCardTransaction()
        {
            const int empId = 5;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            var tct = new TimeCardTransaction(new DateTime(2020, 7, 31), 8.0, empId);
            tct.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            var pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);
            var hc = pc as HourlyClassification;

            var tc = hc.GetTimeCard(new DateTime(2020, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours, 0.001);
        }

        [Test]
        public void TestSalesReceiptTransaction()
        {
            const int empId = 6;
            var t = new AddCommissionedEmployee(empId, "Bill", "Home", 2500.00, 3.2);
            t.Execute();
            var srt = new SalesReceiptTransaction(new DateTime(2020, 7, 31), 100.00, empId);
            srt.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            var pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);
            var cc = pc as CommissionedClassification;

            var sc = cc.GetSalesReceipt(new DateTime(2020, 7, 31));
            Assert.IsNotNull(sc);
            Assert.AreEqual(100.00, sc.Amount, 0.001);
        }

        [Test]
        public void TestAddServiceCharge()
        {
            const int empId = 7;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var af = new UnionAffiliation();
            e.Affiliation = af;
            const int memberId = 86;
            PayrollDatabase.AddUnionMember(memberId, e);
            var sct = new ServiceChargeTransaction(memberId, new DateTime(2020, 8, 8), 12.95);
            sct.Execute();
            var sc = af.GetServiceCharge(new DateTime(2020, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, 0.001);
        }

        [Test]
        public void TestChangeNameTransaction()
        {
            const int empId = 8;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            var cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [Test]
        public void TestChangeAddressTransaction()
        {
            const int empId = 9;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            var cat = new ChangeAddressTransaction(empId, "Work");
            cat.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Work", e.Address);
        }

        [Test]
        public void TestChangeHourlyTransaction()
        {
            const int empId = 10;
            var t = new AddCommissionedEmployee(empId, "Lance", "Home", 2500, 3.2);
            t.Execute();
            var cht = new ChangeHourlyTransaction(empId, 27.52);
            cht.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is HourlyClassification);
            var hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, 0.001);
            var ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void TestChangeSalariedTransaction()
        {
            const int empId = 11;
            var t = new AddHourlyEmployee(empId, "Lance", "Home", 27.52);
            t.Execute();
            var cst = new ChangeSalariedTransaction(empId, 2500.00);
            cst.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is SalariedClassification);
            var sc = pc as SalariedClassification;
            Assert.AreEqual(2500.00, sc.Salary, 0.001);
            var ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [Test]
        public void TestChangeCommissionedTransaction()
        {
            const int empId = 12;
            var t = new AddHourlyEmployee(empId, "Lance", "Home", 27.52);
            t.Execute();
            var cct = new ChangeCommissionedTransaction(empId, 2500.00, 3.2);
            cct.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pc = e.Classification;
            Assert.IsNotNull(pc);
            Assert.IsTrue(pc is CommissionedClassification);
            var cc = pc as CommissionedClassification;
            Assert.AreEqual(2500.00, cc.Salary, 0.001);
            Assert.AreEqual(3.2, cc.CommissionRate, 0.001);
            var ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [Test]
        public void TestChangeDirectTransaction()
        {
            const int empId = 13;
            var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00);
            t.Execute();
            var cdt = new ChangeDirectTransaction(empId, "Bank", "Account");
            cdt.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pm = e.Method;
            Assert.IsNotNull(pm);
            Assert.IsTrue(pm is DirectMethod);
            var dm = pm as DirectMethod;
            Assert.AreEqual("Bank", dm.Bank);
            Assert.AreEqual("Account", dm.Account);
        }

        [Test]
        public void TestChangeMailTransaction()
        {
            const int empId = 14;
            var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00);
            t.Execute();
            var cmt = new ChangeMailTransaction(empId, "Work");
            cmt.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pm = e.Method;
            Assert.IsNotNull(pm);
            Assert.IsTrue(pm is MailMethod);
            var mm = pm as MailMethod;
            Assert.AreEqual("Work", mm.Address);
        }

        [Test]
        public void TestChangeHoldTransaction()
        {
            const int empId = 15;
            var t = new AddSalariedEmployee(empId, "Bill", "Home", 2500.00);
            t.Execute();
            var cmt = new ChangeMailTransaction(empId, "Work");
            cmt.Execute();
            var cht = new ChangeHoldTransaction(empId);
            cht.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var pm = e.Method;
            Assert.IsNotNull(pm);
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestChangeUnionMember()
        {
            const int empId = 16;
            var t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            const int memberId = 7743;
            var cmt = new ChangeMemberTransaction(empId, memberId, 99.42);
            cmt.Execute();
            var e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            var affiliation = e.Affiliation;
            Assert.IsNotNull(affiliation);
            Assert.IsTrue(affiliation is UnionAffiliation);
            var uf = affiliation as UnionAffiliation;
            Assert.AreEqual(99.42, uf.Dues, 0.001);
            var member = PayrollDatabase.GetUnionMember(memberId);
            Assert.IsNotNull(member);
            Assert.AreEqual(e, member);
        }
    }
}
