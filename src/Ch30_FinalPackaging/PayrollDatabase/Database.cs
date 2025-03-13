using Ch30.PayrollDomain;

namespace Ch30.PayrollDatabase;

public interface Database {
    void AddEmployee(int employeeId, Employee employee);
    void AddUnionMember(int memberId, Employee employee);
    void DeleteEmployee(int employeeId);
    ICollection<int> GetAllEmployeeIds();
    Employee GetEmployee(int employeeId);
    Employee GetUnionMember(int memberId);
    void RemoveUnionMember(int memberId);
}
