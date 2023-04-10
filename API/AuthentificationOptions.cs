using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthOptions
{ // TODO: заполни поля
    public const string ISSUER = "MyAuthServer"; 
    public const string AUDIENCE = "MyAuthClient";
    const string KEY = "TaskManagerDiplomXxx228"; 
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}