//using DemoASPMVC_DAL.Models;
using GameDAL_EF.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TechniNetGameAPI.Tools
{
    public class TokenManager
    {
        public static string _secretKey = "ùpmosdquib^rcù iopaz'mu(ùça)'(up aczùà(!cèa^'nùpvc(a'çé!(éàuç'('";

        //public TokenManager(IConfiguration config)
        //{
        //    _secretKey = config.GetSection("tokenInfo").GetSection("secretKey").Value;
        //}

        public string GenerateToken(User user)
        {
            //1. Generer la clé de signature

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager._secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //2. Données concernant le token et l'utilisateur
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId == 1 ? "User" : "Admin")

            };

            //Construire le token avec toute les infos utiles
            JwtSecurityToken jwt = new JwtSecurityToken(
                claims : claims,
                signingCredentials : credentials,
                expires : DateTime.Now.AddDays(1),
                issuer : "monserverapi.com",
                audience : "monsite.com"
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(jwt);
        }
    }
}
