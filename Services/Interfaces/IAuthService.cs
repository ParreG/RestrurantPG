using RestrurantPG.DTOs.AuthDTOs;
using RestrurantPG.Models;

namespace RestrurantPG.Services.Interfaces
{
    public interface IAuthService
    {
        Task<(bool Success, string? Token, string? Message)> LoginAsync(AdminLoginDTO dto);
        Task<(bool Success, Admin? Admin, string? Message)> RegisterAsync(AdminRegisterDTO dto);
    }
}
