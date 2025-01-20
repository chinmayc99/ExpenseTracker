using Core.Entities;
using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // UserProfile related methods
        public async Task<UserPorfileModel> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return user != null ? MapToUserProfileModel(user) : null;
        }

        public async Task<IEnumerable<UserPorfileModel>> GetUsersByFamilyIdAsync(int familyId)
        {
            var users = await _userRepository.GetUsersByFamilyIdAsync(familyId);
            return users.Select(MapToUserProfileModel).ToList();
        }

        public async Task AddUserAsync(UserPorfileModel userModel)
        {
            var user = MapToUserProfileEntity(userModel);
            await _userRepository.AddUserAsync(user);
            userModel.UserId = user.UserId; // Return the new UserId
        }

        public async Task UpdateUserAsync(UserPorfileModel userModel)
        {
            var user = MapToUserProfileEntity(userModel);
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        // Family related methods
        public async Task<FamilyMemberModel> GetFamilyByIdAsync(int familyId)
        {
            var family = await _userRepository.GetFamilyByIdAsync(familyId);
            if (family == null) return null;

            var familyMembers = await _userRepository.GetUsersByFamilyIdAsync(familyId);
            return new FamilyMemberModel
            {
                FamilyId = family.FamilyId,
                FamilyName = family.FamilyName,
                FamilyMembers = familyMembers.Select(MapToUserProfileModel).ToList()
            };
        }

        public async Task<IEnumerable<FamilyModel>> GetAllFamiliesAsync()
        {
            var families = await _userRepository.GetAllFamiliesAsync();
            return families.Select(f => new FamilyModel
            {
                FamilyId = f.FamilyId,
                FamilyName = f.FamilyName
            }).ToList();
        }

        public async Task AddFamilyAsync(FamilyModel familyModel)
        {
            var family = new Family
            {
                FamilyName = familyModel.FamilyName
            };
            await _userRepository.AddFamilyAsync(family);
            familyModel.FamilyId = family.FamilyId;
        }

        public async Task UpdateFamilyAsync(FamilyModel familyModel)
        {
            var family = new Family
            {
                FamilyId = familyModel.FamilyId,
                FamilyName = familyModel.FamilyName
            };
            await _userRepository.UpdateFamilyAsync(family);
        }

        public async Task DeleteFamilyAsync(int familyId)
        {
            await _userRepository.DeleteFamilyAsync(familyId);
        }

        // Mapping methods
        private UserPorfileModel MapToUserProfileModel(UserProfile user)
        {
            return new UserPorfileModel
            {
                UserId = user.UserId,
                DisplayName = user.DisplayName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                AdObjId = user.AdObjId,
                FamilyId = user.FamilyId
            };
        }

        private UserProfile MapToUserProfileEntity(UserPorfileModel userModel)
        {
            var userProfile = new UserProfile
            {
                UserId = userModel.UserId,
                DisplayName = userModel.DisplayName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                AdObjId = userModel.AdObjId
            };

            if (userModel.FamilyId != null && userModel?.FamilyId > 0)
            {
                userProfile.FamilyId = userModel.FamilyId;
            }
            return userProfile;
        }
    }
}
