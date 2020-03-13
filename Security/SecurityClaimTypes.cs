using System.Security.Claims;

namespace Patlus.Common.UseCase.Security
{
    public static class SecurityClaimTypes
    {
        public const string TokenId = "jti";
        public const string Audience = "aud";
        public const string Issuer = "iss";
        public const string Version = ClaimTypes.Version;
        public const string Subject = ClaimTypes.NameIdentifier;
        public const string Pool = "pool";
        public const string Organization = "org";
    }
}
