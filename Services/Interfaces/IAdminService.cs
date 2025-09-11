using RestrurantPG.DTOs.AdminDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IAdminService
    {
        Task<(bool Success, List<AdminInvite> invites, string Massange)> GetAllInvitesAsync();
        Task<(bool Success, List<Admin> admins, string Massange)> GetAllAdminsAsync();
        Task<(bool Success, Admin? admin, string Massange)> UpdateAdminAsync(Admin admin);
        //Task<AdminInvite?> UpdateAdminInviteAsync(int id, AdminInviteDTO inviteDTO);
    }

}
