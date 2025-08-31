using RestrurantPG.Models;

namespace RestrurantPG.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin?> GetByIdAsync(int id);
        Task<Admin?> GetByEmailAsync(string email);
        Task<Admin?> GetByUsernameAsync(string username);
        Task AddAsync(Admin admin);
        Task SaveChangesAsync();
        Task<Guid> CreateAdminInvite();
        public Task<AdminInvite> CheckInviteCodeAsync(string code);
        Task UseInviteAsync(AdminInvite invite);
    }
}
