using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeeLineApi.Service
{
    public class JwtService : IJwtService
    {
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtService(TokenValidationParameters tokenValidationParameters,
            JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _tokenValidationParameters = tokenValidationParameters;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public string GenerateToken(IdentityUser user)
        {
            var credentials = new SigningCredentials(_tokenValidationParameters.IssuerSigningKey,
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Aud, "beeline"),
                    new Claim(JwtRegisteredClaimNames.Iss, "beeline"),
                    new Claim(ClaimTypes.Name, user.UserName)
                ]),
                Expires = DateTime.UtcNow.AddMinutes(35),
                SigningCredentials = credentials
            };

            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = _jwtSecurityTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
