using System.Collections;
using System.Collections.Generic;

namespace AgileSoftwareDevelopment.Payroll
{
    public class PayrollDatabase
    {
        private static readonly Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        private static readonly Dictionary<int, Employee> unionMembers = new Dictionary<int, Employee>();

        public static void AddEmployee(int id, Employee employee)
        {
            employees.Add(id, employee);
        }

        public static Employee GetEmployee(int id)
        {
            if (employees.ContainsKey(id))
            {
                return employees[id];
            }

            return null;
        }

        public static Dictionary<int, Employee>.KeyCollection GetAllEmployeeIds()
        {
            return employees.Keys;
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
                return unionMembers[id];
            }

            return null;
        }

        public static void RemoveUnionMember(int memberId)
        {
            unionMembers.Remove(memberId);
        }
    }
}
