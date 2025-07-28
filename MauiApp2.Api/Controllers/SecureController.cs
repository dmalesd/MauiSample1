using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MauiApp2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // This controller requires authentication
    public class SecureController : ControllerBase
    {
        [HttpGet("data")]
        public IActionResult GetSecureData()
        {
            // Get the current user's ID from claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok(new 
            {
                Message = $"This is secure data for user {username}",
                UserId = userId,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}