using FitnessApp.Data;
using FitnessApp.DTO;
using FitnessApp.Interfaces;
using FitnessApp.Model;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Service
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDto)
        {
            var exists = await _context.Users.AnyAsync(t => t.Id == userDto.Id);
            if (exists)
            {
                throw new ArgumentNullException("User already exists");
            }
            var user = new User
            {
                Id = userDto.Id,
                Email = userDto.Email,
                ProfilePictures = userDto.ProfilePicture,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return userDto;
        }

        public async Task<UserDTO> GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            var getUser = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePictures
            };

            return getUser;
        }

        public async Task<UserDTO> UpdateUser(UserDTO UpdateuserDto)
        {
            var userDto = await _context.Users.FindAsync(UpdateuserDto.Id);
            if (userDto == null)
            {
                return null;
            }

            userDto.FirstName = UpdateuserDto.FirstName;
            userDto.LastName = UpdateuserDto.LastName;
            userDto.ProfilePictures = UpdateuserDto.ProfilePicture;

            await _context.SaveChangesAsync();
            return UpdateuserDto;
        }
 

        public async Task<bool> DeleteUser(Guid Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
