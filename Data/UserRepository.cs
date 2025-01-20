using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerContext _dbcontext;

        public UserRepository(ExpenseTrackerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddFamilyAsync(Family family)
        {
            _dbcontext.Families.Add(family);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task AddUserAsync(UserProfile user)
        {
            _dbcontext.UserProfiles.Add(user);
            await _dbcontext.SaveChangesAsync(); 
        }

        public async Task DeleteFamilyAsync(int familyId)
        {
            var family = await _dbcontext.Families.FindAsync(familyId);
            if (family != null)
            {
                _dbcontext.Families.Remove(family);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dbcontext.UserProfiles.FindAsync(userId);
            if (user != null)
            {
                _dbcontext.UserProfiles.Remove(user);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Family>> GetAllFamiliesAsync()
        {
            return await _dbcontext.Families.ToListAsync();
        }

        public async Task<Family> GetFamilyByIdAsync(int familyId)
        {
            return await _dbcontext.Families.FindAsync(familyId);
        }

        public async Task<UserProfile> GetUserByIdAsync(int userId)
        {
            return  await _dbcontext.UserProfiles.FindAsync(userId);
            
        }

        public async Task<IEnumerable<UserProfile>> GetUsersByFamilyIdAsync(int familyId)
        {
            return await _dbcontext.UserProfiles.Where(x => x.FamilyId == familyId).ToListAsync();
        }

        public async Task UpdateFamilyAsync(Family family)
        {
            _dbcontext.Families.Update(family);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserProfile user)
        {
            _dbcontext.UserProfiles.Update(user);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
