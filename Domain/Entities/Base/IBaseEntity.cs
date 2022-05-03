
namespace Domain.Entities.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
