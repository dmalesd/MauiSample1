using MauiApp2.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MauiApp2.Api.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        // In a real application, you would retrieve users from a database
        // For demo purposes, we'll use a hard-coded list of users
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "user", Password = "password" },
            new User { Id = 2, Username = "admin", Password = "admin123" }
        };

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LoginResponse> ValidateUserAsync(LoginRequest request)
        {
            // Simulate network delay to mimic a real database lookup
            await Task.Delay(500);
            
            // Check if credentials match any user in our list
            var user = _users.FirstOrDefault(u => 
                u.Username == request.Username && 
                u.Password == request.Password);

            if (user == null)
            {
                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid username or password"
                };
            }

            // Generate access token and refresh token
            var accessToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();
            var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(
                _configuration.GetValue<int>("JwtSettings:RefreshTokenExpirationDays"));

            // Update user with refresh token (in a real app, save to database)
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = refreshTokenExpiryTime;

            return new LoginResponse
            {
                Success = true,
                Token = accessToken,
                RefreshToken = refreshToken,
                TokenExpiration = DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes"))
            };
        }

        public async Task<LoginResponse> RefreshTokenAsync(string refreshToken)
        {
            // Simulate network delay
            await Task.Delay(200);

            // Find user with matching refresh token
            var user = _users.FirstOrDefault(u => u.RefreshToken == refreshToken);

            // Validate user and token
            if (user == null || user.RefreshTokenExpiry <= DateTime.UtcNow)
            {
                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid or expired refresh token"
                };
            }

            // Generate new tokens
            var accessToken = GenerateJwtToken(user);
            var newRefreshToken = GenerateRefreshToken();
            var refreshTokenExpiryTime = DateTime.UtcNow.AddDays(
                _configuration.GetValue<int>("JwtSettings:RefreshTokenExpirationDays"));

            // Update user with new refresh token
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiry = refreshTokenExpiryTime;

            return new LoginResponse
            {
                Success = true,
                Token = accessToken,
                RefreshToken = newRefreshToken,
                TokenExpiration = DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes"))
            };
        }

        private string GenerateJwtToken(User user)
        {
            var secretKey = _configuration["JwtSettings:SecretKey"] ?? throw new InvalidOperationException("JWT secret key is not configured");
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expirationMinutes = _configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}