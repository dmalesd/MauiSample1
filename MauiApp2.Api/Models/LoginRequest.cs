namespace MauiApp2.Api.Models
{
    /// <summary>
    /// Represents a login request with user credentials
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username for authentication
        /// </summary>
        /// <example>user</example>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for authentication
        /// </summary>
        /// <example>password</example>
        public string Password { get; set; } = string.Empty;
    }
}