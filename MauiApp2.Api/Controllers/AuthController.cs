using MauiApp2.Api.Models;
using MauiApp2.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace MauiApp2.Api.Controllers
{
    /// <summary>
    /// Controller for handling authentication and token management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class
        /// </summary>
        /// <param name="authService">The authentication service</param>
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates a user and generates JWT tokens
        /// </summary>
        /// <param name="request">The login credentials</param>
        /// <returns>A response containing JWT token and refresh token if successful</returns>
        /// <response code="200">Returns the JWT token when login is successful</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="401">If the credentials are invalid</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Username and password are required"
                });
            }

            var response = await _authService.ValidateUserAsync(request);
            
            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// Refreshes an expired JWT token using a refresh token
        /// </summary>
        /// <param name="request">The refresh token request</param>
        /// <returns>A new JWT token and refresh token</returns>
        /// <response code="200">Returns new tokens when refresh is successful</response>
        /// <response code="400">If the request is invalid</response>
        /// <response code="401">If the refresh token is invalid or expired</response>
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> RefreshToken(RefreshTokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    ErrorMessage = "Refresh token is required"
                });
            }

            var response = await _authService.RefreshTokenAsync(request.RefreshToken);
            
            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}