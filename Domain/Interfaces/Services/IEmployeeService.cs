using Domain.Models.Constants;
using Domain.Models.Filters;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetAllEmployees(EmployeeFilteringParams param);
        EmployeeResponse AddEmployee(EmployeeRequest empRequest);
        EmployeeResponse UpdateEmployee(EmployeeRequest empRequest, string empId);
        void DeleteEmployee(string empId);

    }
}
