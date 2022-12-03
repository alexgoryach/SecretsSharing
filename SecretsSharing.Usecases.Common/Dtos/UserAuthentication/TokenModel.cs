namespace SecretsSharing.Usecases.Common.Dtos.UserAuthentication
{
    /// <summary>
    /// Token model.
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token expiration in seconds.
        /// </summary>
        public long ExpiresIn { get; set; }
    }
}