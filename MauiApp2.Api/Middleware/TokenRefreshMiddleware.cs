using Microsoft.AspNetCore.Http;
using MauiApp2.Api.Models;
using MauiApp2.Api.Services;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace MauiApp2.Api.Middleware
{
    public class TokenRefreshMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenRefreshMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, AuthService authService)
        {
            // Skip refresh token for auth endpoints
            if (context.Request.Path.StartsWithSegments("/api/auth"))
            {
                await _next(context);
                return;
            }

            // Check if we have a refresh token in a cookie or header
            string? refreshToken = context.Request.Cookies["RefreshToken"] ?? 
                                  context.Request.Headers["X-Refresh-Token"].FirstOrDefault();

            if (!string.IsNullOrEmpty(refreshToken))
            {
                // Only refresh if token is about to expire (for demonstration, always refresh)
                // In a real app, you'd check the JWT expiration time
                var response = await authService.RefreshTokenAsync(refreshToken);
                
                if (response.Success)
                {
                    // Add the new tokens to the response headers
                    context.Response.Headers.Append("X-Access-Token", response.Token);
                    context.Response.Headers.Append("X-Refresh-Token", response.RefreshToken);
                    
                    // Optionally set cookies
                    context.Response.Cookies.Append("AccessToken", response.Token ?? string.Empty, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = response.TokenExpiration
                    });
                    
                    context.Response.Cookies.Append("RefreshToken", response.RefreshToken ?? string.Empty, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(7)
                    });
                }
            }

            await _next(context);
        }
    }

    // Extension method to add the middleware to the request pipeline
    public static class TokenRefreshMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenRefresh(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenRefreshMiddleware>();
        }
    }
}