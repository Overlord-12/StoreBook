using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StoreBookWebApi.Token
{
    public class AuthOptions
    {
        public const string ISSUER = "Danila"; // издатель токена
        public const string AUDIENCE = "Client"; // потребитель токена
        const string KEY = "this is my custom Secret key for authnetication";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
