using RestrurantPG.DTOs.AdminDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }

        public async Task<(bool Success, List<AdminInvite> invites, string Massange)> GetAllInvitesAsync()
        {
            var invites = await adminRepository.GetAllInvitesAsync();

            if (invites.Count == 0)
            {
                return (false, [], "Inga inbjudningar hittades!");
            }

            return (true, invites, "Listar alla inbjudningar!");
        }

        public async Task<(bool Success, List<Admin> admins, string Massange)> GetAllAdminsAsync()
        {
            var admins = await adminRepository.GetAllAdminsAsync();

            if (admins.Count == 0)
            {
                return (false, [], "Inga admins hittades!");
            }

            return (true, admins, "listar alla admins");
        }

        public async Task<(bool Success, Admin? admin, string Massange)> UpdateAdminAsync(Admin admin)
        {
            var oldAdmin = await adminRepository.GetByIdAsync(admin.Admin_Id);
            if (oldAdmin == null)
            {
                return (false, null, "Hittade inte aktuell admin! Testa igen!");
            }

            var ExistingEmail = await adminRepository.GetByEmailAsync(admin.Email);
            var ExistingUsername = await adminRepository.GetByUsernameAsync(admin.UserName);

            if (ExistingEmail != null && ExistingEmail.Admin_Id != admin.Admin_Id)
            {
                return (false, null, "Email används redan av en annan admin!");
            }

            if (ExistingUsername != null && ExistingUsername.Admin_Id != admin.Admin_Id)
            {
                return (false, null, "Användarnamnet är redan upptaget!");
            }

            var updatedAdmin = await adminRepository.UpdateAdminAsync(admin);

            if (updatedAdmin == null)
            {
                return (false, null, "Admin kunde inte uppdateras!");
            }

            return (true, updatedAdmin, "Admin är uppdaterad!");
        }

        //public async Task<(bool Success, AdminInvite? adminInvite, string Massange)> UpdateAdminInviteAsync(int id, AdminInviteDTO inviteDTO)
        //{
        //    var oldAdmin = await adminRepository.GetByIdAsync(id);

        //}
    }
}
