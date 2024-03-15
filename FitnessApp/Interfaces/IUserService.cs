using FitnessApp.DTO;

namespace FitnessApp.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(Guid id);
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> UpdateUser(UserDTO UpdateuserDto);
        Task<bool> DeleteUser(Guid id);
    }
}