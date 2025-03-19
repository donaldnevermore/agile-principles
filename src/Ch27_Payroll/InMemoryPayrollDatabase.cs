using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll;

public class InMemoryPayrollDatabase : PayrollDatabase {
    private static readonly Dictionary<int, Employee> employees = new();
    private static readonly Dictionary<int, Employee> unionMembers = new();

    public void AddEmployee(Employee employee) {
        employees.Add(employee.EmpId, employee);
    }

    public Employee GetEmployee(int id) {
        if (employees.ContainsKey(id)) {
            return employees[id];
        }

        return null;
    }

    public void DeleteEmployee(int id) {
        employees.Remove(id);
    }

    public void AddUnionMember(int id, Employee employee) {
        unionMembers.Add(id, employee);
    }

    public Employee GetUnionMember(int id) {
        if (unionMembers.ContainsKey(id)) {
            return unionMembers[id];
        }

        return null;
    }

    public void RemoveUnionMember(int memberId) {
        unionMembers.Remove(memberId);
    }

    public ICollection<int> GetAllEmployeeIds() {
        return employees.Keys;
    }

    public ICollection<Employee> GetAllEmployees() {
        return employees.Values;
    }

    public void Clear() {
        employees.Clear();
        unionMembers.Clear();
    }
}
