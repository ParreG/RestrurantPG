using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestrurantPG.DTOs.AuthDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IJwtTokenService jwtTokenService;

        public AuthService(IAdminRepository _adminrepository, IJwtTokenService _jwtTokenService)
        {
            adminRepository = _adminrepository;
            jwtTokenService = _jwtTokenService;
        }

        public async Task<(bool Success, string? Token, string? Message)> LoginAsync(AdminLoginDTO dto)
        {
            var admin = await adminRepository.GetByUsernameAsync(dto.Username);
            if (admin == null)
            {
                return (false, null, "wrong username or password!");
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, admin.PasswordHash))
            {
                return (false, null, "wrong username or password!");
            }

            var token = jwtTokenService.GenerateJwtToken(admin);
            return (true, token, null);
        }


        public async Task<(bool Success, Admin? Admin, string? Message)> RegisterAsync(AdminRegisterDTO adminRegisterDTO)
        {
            var existing = await adminRepository.GetByEmailAsync(adminRegisterDTO.Email);

            if (existing != null)
            {
                return (false, null, "email adress used already.");
            }

            var inviteCode = adminRegisterDTO.RegistrationCode;

            var invite = await adminRepository.CheckInviteCodeAsync(inviteCode);

            if (invite == null)
            {
                return (false, null, "didnt find the invitation code!");
            }
            else if (invite.IsUsed)
            {
                return (false, null, "the invitation code is already in use!! Contact the adminstrator to get a new code!!");
            }
            else if (invite.ExpiresAt < DateTime.Now)
            {
                return (false, null, "the invitation code is out of date. Contact the adminstrator to get a new code!!");
            }

            await adminRepository.UseInviteAsync(invite);

                var newAdmin = new Admin
                {
                    UserName = adminRegisterDTO.UserName,
                    Email = adminRegisterDTO.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminRegisterDTO.Password)
                };

            await adminRepository.AddAsync(newAdmin);
            await adminRepository.SaveChangesAsync();

            return (true, newAdmin, "Admin är nu skapad!");
        }
    }
}
