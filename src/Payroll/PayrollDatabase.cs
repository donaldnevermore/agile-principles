using System.Collections;

namespace AgileSoftwareDevelopment.Payroll
{
    public class PayrollDatabase
    {
        private static readonly Hashtable employees = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static Employee GetEmployee(int id)
        {
            return employees[id] as Employee;
        }
    }
}
