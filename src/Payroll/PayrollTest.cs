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
            var t = new AddHourlyEmployee(empId, "Kop", "Home", 0.5);
            t.Execute();

            var e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Kop", e.Name);

            var pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            var hourlyClassification = pc as HourlyClassification;
            Assert.AreEqual(0.5, hourlyClassification.HourlyRate, 0.001);
            var ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);

            var pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }
    }
}
