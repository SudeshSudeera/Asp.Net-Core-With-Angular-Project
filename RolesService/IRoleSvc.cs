using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolesService
{
    public interface IRoleSvc
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<bool> AddToRolesAsync(IFormCollection formData);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<bool> UpdateRoleAsync(IFormCollection formData);
        Task<bool> AddRolePermissionAsync(string rolePermissionName);
        Task<IEnumerable<RolePermission>> GetAllRolePermissionsAsync();
        Task<bool> DeleteRolePermissionAsync(int rolePermissionId);
        Task<IEnumerable<PermissionType>> GetAllRolePermissionsTypesAsync();
    }
}
