using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BusinessLayer
{
    public class UserService
    {
        BuyLocalContext _db = null;
        public UserService()
        {
            _db = new BuyLocalContext();
        }

        public async Task<User> GetUserAsync(Guid userID)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserID == userID).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<FarmerViewModel> GetFarmerAsync(Guid userID)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserID == userID)
                .Select(x=> new FarmerViewModel() 
                {
                    ID= x.UserID,
                    UserName = x.UserName,
                    DisplayName = x.Person.FirstName,
                    Contact = x.Person.Contact.Phone1,
                    Address = x.Person.Address.AddressLine1
                })
                .FirstOrDefaultAsync();
        }

        public async Task<FarmerViewModel> GetFarmerAsync(string userName)
        {
            return await _db.Users.Where(x => x.IsActive && x.UserName == userName)
                .Select(x => new FarmerViewModel()
                {
                    ID = x.UserID,
                    UserName = x.UserName,
                    DisplayName = x.Person.FirstName,
                    Contact = x.Person.Contact.Phone1,
                    Address = x.Person.Address.AddressLine1
                })
                .FirstOrDefaultAsync();
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
