using System.Collections;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class PayrollDatabase
    {
        private static readonly Dictionary<int, object> employees = new Dictionary<int, object>();
        private static readonly Dictionary<int, object> unionMembers = new Dictionary<int, object>();

        public static void AddEmployee(int id, Employee employee)
        {
            employees.Add(id, employee);
        }

        public static Employee GetEmployee(int id)
        {
            if (employees.ContainsKey(id))
            {
                return employees[id] as Employee;
            }

            return null;
        }

        public static void DeleteEmployee(int id)
        {
            employees.Remove(id);
        }

        public static void AddUnionMember(int id, Employee employee)
        {
            unionMembers.Add(id, employee);
        }

        public static Employee GetUnionMember(int id)
        {
            if (unionMembers.ContainsKey(id))
            {
                return unionMembers[id] as Employee;
            }

            return null;
        }

        public static void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }
    }
}
