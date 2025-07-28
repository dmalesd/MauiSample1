namespace MauiApp2.Api.Models
{
    /// <summary>
    /// Represents the response from a login or token refresh operation
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation was successful
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the JWT access token for authenticated requests
        /// </summary>
        /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...</example>
        public string? Token { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used to obtain a new access token
        /// </summary>
        /// <example>rnb0jMf8KHKqMT18hkjwqo7QzpK9v7...</example>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time of the access token
        /// </summary>
        /// <example>2023-07-30T15:30:45Z</example>
        public DateTime? TokenExpiration { get; set; }

        /// <summary>
        /// Gets or sets the error message when the operation fails
        /// </summary>
        /// <example>Invalid username or password</example>
        public string? ErrorMessage { get; set; }
    }
}