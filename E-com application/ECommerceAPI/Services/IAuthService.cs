using ECommerceAPI.Models;
using ECommerceAPI.DTOs;

namespace ECommerceAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> Register(RegisterDto registerDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        string GenerateJwtToken(User user);
    }
}
