using Project_DAL.Data;
using Project_Domain.DTO;
using Project_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL.Repos
{
    public class UserRepo : IUserRepository
    {
        private readonly Restful_Api_Practice_dotnetEntities _context;

        public UserRepo(Restful_Api_Practice_dotnetEntities context)
        {
            _context = context;

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var exists = await _context.Users.FindAsync(user.Id);
            if (exists == null) return null;
            _context.Entry(exists).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return exists;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return false;
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
