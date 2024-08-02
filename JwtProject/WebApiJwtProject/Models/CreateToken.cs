using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApiJwtProject.Models
{
    public class CreateToken
    {
        public string TokenGenerate()
        {
            var bytes = Encoding.UTF8.GetBytes("2024JwtProject-For_Learning_Purpose");
            SymmetricSecurityKey symmetricSecurity = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(symmetricSecurity, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
