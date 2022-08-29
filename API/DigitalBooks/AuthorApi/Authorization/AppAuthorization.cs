using System.Security.Claims;

namespace AuthorApi.Authorization
{
    public class AppAuthorization
    {
        internal bool AppAuth(ClaimsIdentity? identity)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Name",identity.FindFirst("Name").Value),
                new Claim("Role",identity.FindFirst("Role").Value),
            };

            if (claims[1].Value.ToString().ToLower() == "author")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
