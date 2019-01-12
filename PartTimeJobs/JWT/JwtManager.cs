using Microsoft.IdentityModel.Tokens;
using PartTimeJobs.App_Settings;
using PartTimeJobs.BLL.Services;
using PartTimeJobs.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PartTimeJobs.JWT
{
    public static class JwtManager
    {
        private static Dictionary<UserType, string> userTypeToRole = new Dictionary<UserType, string>();
        private static UserService _userService = new UserService();

        static JwtManager()
        {
            userTypeToRole.Add(UserType.Client, Settings.Client);
            userTypeToRole.Add(UserType.Provider, Settings.Provider);
        }

        private const int expireMinutes = 60 * 1;
        public static string GenerateToken(User user)
        {            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(new Claim[]
            {
                new Claim(Settings.EmailClaimKey, user.Email),
                new Claim(Settings.UserTypeClaimKey, GetRole(user.UserType))
            });

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);
            return tokenString;
        }

        private static string GetRole(UserType userType)
        {
            return userTypeToRole[userType];
        }

        public static bool ValidateToken(string tokenString)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenString);
                var payload = token.Payload;
                object email, type;
                if (!payload.TryGetValue(Settings.EmailClaimKey, out email) || !payload.TryGetValue(Settings.UserTypeClaimKey, out type))
                {
                    return false;
                }
                return _userService.UserExists(email.ToString());
            }
            catch
            {
                return false;
            }
        }

        public static string DecryptBase64(string value)
        {
            byte[] data = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(data);
        }

        public static string GetEmailFromToken(string tokenString)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenString);
                var payload = token.Payload;
                object email;
                if (!payload.TryGetValue(Settings.EmailClaimKey, out email))
                {
                    return "";
                }
                return email.ToString();
            }
            catch
            {
                return "";
            }

        }
    }   
}