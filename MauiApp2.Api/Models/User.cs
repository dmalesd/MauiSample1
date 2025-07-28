namespace MauiApp2.Api.Models
{
    /// <summary>
    /// Represents a user in the system
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username for the user
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password for the user
        /// </summary>
        /// <remarks>
        /// In a production environment, this would store a password hash, not plaintext
        /// </remarks>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the refresh token for the user
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time of the refresh token
        /// </summary>
        public DateTime RefreshTokenExpiry { get; set; }
    }
}