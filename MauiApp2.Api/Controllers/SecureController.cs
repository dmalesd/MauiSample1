using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MauiApp2.Api.Controllers
{
    /// <summary>
    /// Controller for accessing secured resources that require authentication
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // This controller requires authentication
    public class SecureController : ControllerBase
    {
        /// <summary>
        /// Gets secure data for the authenticated user
        /// </summary>
        /// <returns>Secure data including user information and timestamp</returns>
        /// <response code="200">Returns the secure data for the authenticated user</response>
        /// <response code="401">If the user is not authenticated</response>
        [HttpGet("data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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