using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Filters;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetEmployees(EmployeeFilteringParams param);
        EmployeeResponse AddEmployee(EmployeeRequest empRequest);
        EmployeeResponse UpdateEmployee(EmployeeRequest empRequest, Guid empId);
        void DeleteEmployee(Guid empId);

    }
}
