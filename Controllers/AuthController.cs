using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestrurantPG.Data;
using RestrurantPG.DTOs.AuthDTOs;
using RestrurantPG.Models;
using RestrurantPG.Repositories.Interfaces;
using RestrurantPG.Services.Interfaces;

namespace RestrurantPG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext context;
        private readonly IJwtTokenService jwtTokenService;
        private readonly IAuthService authService;
        private readonly IAdminRepository adminRepository;

        public AuthController(AppDBContext _context, IJwtTokenService _jwtTokenService, IAuthService _authService, IAdminRepository _adminRepository)
        {
            context = _context;
            jwtTokenService = _jwtTokenService;
            authService = _authService;
            adminRepository = _adminRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AdminLoginDTO dto)
        {
            var result = await authService.LoginAsync(dto);
            if (!result.Success)
            {
                return Unauthorized(result.Message);
            }

            return Ok(new {token = result.Token });
        }

        [HttpPost("CreateInvite")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreatInviteCode()
        {
            var newInvte = await adminRepository.CreateAdminInvite();
            return Ok(newInvte);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AdminRegisterDTO adminRegisterDTO)
        {
            var result = await authService.RegisterAsync(adminRegisterDTO);
           
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result.Admin);
        }

    }
}
