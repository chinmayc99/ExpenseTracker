using Core.Entities;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<UserPorfileModel> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserPorfileModel>> GetUsersByFamilyIdAsync(int familyId);
        Task AddUserAsync(UserPorfileModel user);
        Task UpdateUserAsync(UserPorfileModel user);
        Task DeleteUserAsync(int userId);

        Task<FamilyMemberModel> GetFamilyByIdAsync(int familyId);
        Task<IEnumerable<FamilyModel>> GetAllFamiliesAsync();
        Task AddFamilyAsync(FamilyModel family);
        Task UpdateFamilyAsync(FamilyModel family);
        Task DeleteFamilyAsync(int familyId);
    }
}
