
using FitnessApp.Model;

namespace FitnessApp.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetById(Guid id);
        Task<bool> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid id);
    }
}