namespace MauiApp2.Api.Models
{
    /// <summary>
    /// Represents a request to refresh an expired JWT token
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// Gets or sets the refresh token used to obtain a new access token
        /// </summary>
        /// <example>rnb0jMf8KHKqMT18hkjwqo7QzpK9v7...</example>
        public string RefreshToken { get; set; } = string.Empty;
    }
}