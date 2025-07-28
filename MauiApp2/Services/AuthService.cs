using MauiApp2.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace MauiApp2.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public AuthService()
        {
            _httpClient = new HttpClient();
            
            // In a real app, this would come from app config
            // For Android emulator, use 10.0.2.2 instead of localhost to access the host machine
#if ANDROID
            _baseUrl = DeviceInfo.Platform == DevicePlatform.Android 
                ? "https://10.0.2.2:7184/api/auth" 
                : "https://localhost:7184/api/auth";
#else
            _baseUrl = "https://localhost:7184/api/auth";
#endif
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            try
            {
                // Ignore SSL certificate validation issues in development
#if DEBUG
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };
                using var client = new HttpClient(handler);
#else
                using var client = new HttpClient();
#endif

                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var response = await client.PostAsJsonAsync($"{_baseUrl}/login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return loginResponse ?? new LoginResponse { Success = false, ErrorMessage = "Failed to parse response" };
                }
                
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    return errorResponse ?? new LoginResponse { Success = false, ErrorMessage = "Invalid username or password" };
                }

                return new LoginResponse 
                { 
                    Success = false, 
                    ErrorMessage = $"Error: {response.StatusCode}" 
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse 
                { 
                    Success = false, 
                    ErrorMessage = $"Error: {ex.Message}" 
                };
            }
        }
    }
}