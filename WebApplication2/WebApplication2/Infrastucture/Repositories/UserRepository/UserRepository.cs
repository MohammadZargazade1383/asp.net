using Microsoft.EntityFrameworkCore;
using WebApplication2.Application.Interfaces.Repositories;
using WebApplication2.Domain.Entities.User;
using WebApplication2.Infrastucture.ApplicationDd;

namespace WebApplication2.Infrastucture.Repositories.userRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext _dbcontext)
        {
            _context = _dbcontext;
        }
        public async Task<User> Create(User user)
        {
            var creatuser = await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return creatuser.Entity;
        }
        public async Task<bool> Delete(User user)
        {
            if (user is not null) 
            {
                user.AppAction = Domain.Enum.AddAction.AddAction.Deleted; 
                await _context.SaveChangesAsync();
                return true;
            }


            else { return false; }
            
        }
        public async Task<User> Update(User user)
        {
            if(user is not null) 
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
        public async Task<User> GetById(int id)
        {
            var Finduser = await _context.users.SingleOrDefaultAsync(u => u.Id == id);
            return Finduser;
        }
        public  IQueryable<User> GetAll()
        {
            var users = _context.users.Where(x => x.AppAction == Domain.Enum.AddAction.AddAction.Active);
            return users;
        }
       


    }
}
