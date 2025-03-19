using AgilePrinciples.Payroll.Domain;

namespace AgilePrinciples.Payroll;

public interface PayrollDatabase {
    void AddEmployee(Employee employee);
    Employee? GetEmployee(int id);
    void DeleteEmployee(int id);
    void AddUnionMember(int id, Employee e);
    Employee? GetUnionMember(int id);
    void RemoveUnionMember(int memberId);
    ICollection<int> GetAllEmployeeIds();
    ICollection<Employee> GetAllEmployees();
}
