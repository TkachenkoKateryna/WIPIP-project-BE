using Domain.Dtos;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
    }
}
