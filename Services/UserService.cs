using System.Linq.Expressions;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Entities;
using WebApplication1.Services.Interface;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(InsertUserDto userDto)
        {
            try
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageURL = userDto.ImageURL,
                    RegisterDate = userDto.RegisterDate,
                    IsActive = true
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user: " + ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)

                    throw new NotImplementedException();

                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Deleting user: " + ex.Message);
            }

        }

        public List<GetAllUser> GetAllUser()
        {
            try
            {
                var users = _context.Users.Where(u => u.IsActive).ToList();

                if(users == null)
                throw new Exception("No active users found");

                var result = new List<GetAllUser>();

                foreach(var u in users)               
                {
                    result.Add( new GetAllUser
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Gender = u.Gender,
                         ImageURL = u.ImageURL,
                        RegisterDate = u.RegisterDate,
                    });
                }

                return result;
                
            }
            catch (Exception ex)
            {

            }
        }

        public GetAllUser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Guid id, UpdateUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
