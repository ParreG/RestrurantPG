using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;

namespace RestrurantPG.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDBContext context;

        public AdminRepository(AppDBContext _context)
        {
            context = _context;
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            var adminId = await context.Admins.FindAsync(id);

            return adminId;
        }

        public async Task<Admin?> GetByEmailAsync(string email)
        {
            var adminEmail = await context.Admins.FirstOrDefaultAsync(a => a.Email == email);

            return adminEmail;
        }

        public async Task<Admin?> GetByUsernameAsync(string username)
        {
            var adminUsername = await context.Admins.FirstOrDefaultAsync(a => a.UserName == username);

            return adminUsername;
        }

        public async Task AddAsync(Admin admin)
        {
            await context.Admins.AddAsync(admin);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Guid> CreateAdminInvite()
        {
            var newInvite = new AdminInvite();
            newInvite.AdminId_Fk = 1;

            // Om guid koden redan existerar????????

            await context.AdminInvites.AddAsync(newInvite);
            await context.SaveChangesAsync();

            return newInvite.InviteCode;

        }

        public async Task<AdminInvite?> CheckInviteCodeAsync(string code)
        {
            if (!Guid.TryParse(code, out var guidCode))
            {
                return null;
            }

            return await context.AdminInvites.FirstOrDefaultAsync(aI => aI.InviteCode == guidCode);
        }

        public async Task UseInviteAsync(AdminInvite invite)
        {
            invite.IsUsed = true;

            await context.SaveChangesAsync();
        }



    }
}
