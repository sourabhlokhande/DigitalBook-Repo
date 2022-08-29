using Microsoft.IdentityModel.Tokens;
using ModelService.Data;
using ModelService.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationDbContext _dbContext;
        public TokenService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Author ValidateUser(Author author)
        {
            Author authorObj = _dbContext.AuthorTbl.FirstOrDefault(u => u.AuthorName == author.AuthorName && u.Password == author.Password);
            if (authorObj != null)
            {
                return authorObj;
            }
            else
            {
                return null;
            }
        }

        private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, Author author)
        {
            var claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim("Name", author.AuthorName),
                new Claim("Role", author.UserType)
            };

            //claims.Add(new Claim("given_name", userName));
            //claims.Add(new Claim("user_type", "author"));

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
