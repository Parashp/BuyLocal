using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService
    {
        BuyLocalContext _db = null;
        public UserService(BuyLocalContext db)
        {
            _db = db;
        }
        public async Task<User> GetUserAsync(Guid userID)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserID == userID).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users
                     .Where(x => x.IsActive)
                     .ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _ = await _db.Users.AddAsync(user);
            _ = await _db.SaveChangesAsync();
        }
    }
}
