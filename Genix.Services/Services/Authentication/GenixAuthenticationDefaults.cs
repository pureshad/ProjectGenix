namespace Genix.Services.Services.Authentication
{
    public static class GenixAuthenticationDefaults
    {
        /// <summary>
        /// The issuer that should be used for any claims that are created
        /// </summary>
        public static string ClaimsIssuer => "Genix";

        /// <summary>
        /// The default value used for authentication scheme
        /// </summary>
        public static string AuthenticationScheme => "Authentication";

    }
}
