using Domain.Dtos.Filters;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetAllEmployees(EmployeeFilteringParams param);
        EmployeeResponse AddEmployee(EmployeeRequest empRequest);
        EmployeeResponse UpdateEmployee(EmployeeRequest empRequest, string empId);
        void DeleteEmployee(string empId);
        string UpdateEmployeeImage(IFormFile image, string empId);

    }
}
