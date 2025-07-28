using MauiApp2.Api.Models;

namespace MauiApp2.Api.Services
{
    public class AuthService
    {
        // In a real application, you would retrieve users from a database
        // For demo purposes, we'll use a hard-coded list of users
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "user", Password = "password" },
            new User { Id = 2, Username = "admin", Password = "admin123" }
        };

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

            // In a real app, you would generate a JWT token here
            return new LoginResponse
            {
                Success = true,
                Token = $"demo-token-{Guid.NewGuid():N}"
            };
        }
    }
}